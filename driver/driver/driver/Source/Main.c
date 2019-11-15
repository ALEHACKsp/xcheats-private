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

	DbgPrintEx(0, 0, "Addr: %llx", cs->daddr);

	cs->saddr = 0xFFEE;
	cs->handled = 1;

	RtlCopyMemory((PVOID)address, (PVOID)cs, sizeof(CopyStruct));

	Wait(1000);

	KeUnstackDetachProcess(state);

	UNREFERENCED_PARAMETER(address);
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