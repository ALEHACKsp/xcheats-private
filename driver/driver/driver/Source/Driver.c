#include <ntddk.h>
#include "Main.h"
#include "Log.h"
#include "Defines.h"

ULONGLONG g_Base;
HANDLE g_PID;
BOOLEAN g_Exit;

void PloadImageNotifyRoutine(PUNICODE_STRING FullImageName, HANDLE ProcessId, PIMAGE_INFO ImageInfo)
{
	if (!wcsstr(FullImageName->Buffer, L"client.dll")) return;

	Log("Base found");

	ULONGLONG ibase = (ULONGLONG)ImageInfo->ImageBase;
	g_Base = ibase + STATIC_ADDR;
	g_PID = ProcessId;
}

DRIVER_INITIALIZE DriverEntry;
NTSTATUS DriverEntry(_In_ PDRIVER_OBJECT DriverObject, _In_ PUNICODE_STRING RegistryPath)
{
	UNREFERENCED_PARAMETER(DriverObject);
	UNREFERENCED_PARAMETER(RegistryPath);

	NTSTATUS status = STATUS_SUCCESS;

	Log("Driver was loaded");
	g_PID = 0;
	g_Base = 0;

	KeEnterGuardedRegion();
	PWORK_QUEUE_ITEM WorkItem = (PWORK_QUEUE_ITEM)ExAllocatePool(NonPagedPool, sizeof(WORK_QUEUE_ITEM));
	if (!WorkItem) 
	{
		Log("Failed to allocate memory for work item");
	}
	ExInitializeWorkItem(WorkItem, MainThread, WorkItem);
	ExQueueWorkItem(WorkItem, DelayedWorkQueue);
	KeLeaveGuardedRegion();

	status = PsSetLoadImageNotifyRoutine(PloadImageNotifyRoutine);
	if (!NT_SUCCESS(status)) 
	{
		Log("Failed to register image load notify routine");
	}

	return status;
}