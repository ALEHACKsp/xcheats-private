#include <ntifs.h>
#include "Log.h"
#include "Defines.h"
#include "Memory.h"

void Wait(int milliseconds) 
{
	LARGE_INTEGER delay;
	delay.QuadPart = RELATIVE(MILLISECONDS(milliseconds));
	
	NTSTATUS status = KeDelayExecutionThread(KernelMode, FALSE, &delay);

	if (!NT_SUCCESS(status)) 
	{
		Log("Wait failed");
	}
}

ULONGLONG GetAddress(int number) 
{
	ULONGLONG offset = g_Base + (number * sizeof(CopyStruct));
	return offset;
}

NTSTATUS CheckClient(PEPROCESS* client)
{
	NTSTATUS status = PsLookupProcessByProcessId(g_PID, client);
	if (!NT_SUCCESS(status))
	{
		Log("Client is not running anymore");
		g_Exit = 1;
	}
	return status;
}

void ProcessAddress(ULONGLONG address)
{
	PEPROCESS cclient = { 0 };
	PRKAPC_STATE state = ExAllocatePool(NonPagedPool, sizeof(KAPC_STATE));
	NTSTATUS status = CheckClient(&cclient);
	if (!NT_SUCCESS(status)) return;

	KeStackAttachProcess(cclient, state);
	
	CopyStruct* cs = ExAllocatePool(NonPagedPool, sizeof(CopyStruct));
	
	RtlCopyMemory((PVOID)cs, (PVOID)address, sizeof(CopyStruct));

	if (!cs->handled) 
	{
		PEPROCESS sourcepe = { 0 };
		status = PsLookupProcessByProcessId((HANDLE)cs->spid, &sourcepe);
		if (!NT_SUCCESS(status))
		{
			Log("Source process is not running anymore or invalid PID");
			KeUnstackDetachProcess(state);
			return;
		}
		PEPROCESS destpe = { 0 };
		status = PsLookupProcessByProcessId((HANDLE)cs->dpid, &destpe);
		if (!NT_SUCCESS(status))
		{
			Log("Destination process is not running anymore or invalid PID");
			KeUnstackDetachProcess(state);
			return;
		}
		
		DbgPrintEx(0, 0, "DADDR: %llx", cs->daddr);
		DbgPrintEx(0, 0, "SADDR: %llx", cs->saddr);
		DbgPrintEx(0, 0, "SPID: %i", cs->spid);
		DbgPrintEx(0, 0, "DPID: %i", cs->dpid);
		DbgPrintEx(0, 0, "SIZE: %i", cs->size);

		status = CopyVirtualMemory(sourcepe, destpe, (PVOID)cs->saddr, (PVOID)cs->daddr, cs->size);
		if (!NT_SUCCESS(status))
		{
			Log("Copy memory failed");
		}

		cs->handled = 1;
		RtlCopyMemory((PVOID)address, (PVOID)cs, sizeof(CopyStruct));
	}

	KeUnstackDetachProcess(state);
}

int filterException(int code, PEXCEPTION_POINTERS ex) 
{
	UNREFERENCED_PARAMETER(ex);
	DbgPrintEx(0, 0, "[xcheats.cc] Ex: %x", code);
	return EXCEPTION_EXECUTE_HANDLER;
}

void MainThread(PVOID blank) 
{
	UNREFERENCED_PARAMETER(blank);

	Log("Main thread started");
	g_Exit = 0;

	while (!g_PID || !g_Base)
	{
		Log("Client not connected");
		Wait(1000);
	}

	Log("Waiting for client to initialize...");
	Wait(5000);

	while (!g_Exit) 
	{
		Wait(1);

		for (int i = 0; i < BUILD_THREADS; i++) 
		{
			__try 
			{
				ProcessAddress(GetAddress(i));
			}
			__except (filterException(GetExceptionCode(), GetExceptionInformation()))
			{
				Log("Exception in processing");
			}		
		}
		g_Exit = 1;
	}
}