#include <ntddk.h>
#include "Main.h"
#include "Log.h"
#include "Defines.h"

void PloadImageNotifyRoutine(PUNICODE_STRING FullImageName, HANDLE ProcessId, PIMAGE_INFO ImageInfo)
{
	//if (!wcsstr(FullImageName->Buffer, L"\\csgo\\bin\\client.dll")) return;
	
	UNREFERENCED_PARAMETER(ImageInfo);

	DbgPrintEx(0, 0, "Loaded Name: %ls \n", FullImageName->Buffer);
	DbgPrintEx(0, 0, "Loaded To Process: %d \n", ProcessId);
}

DRIVER_INITIALIZE DriverEntry;
NTSTATUS DriverEntry(_In_ PDRIVER_OBJECT DriverObject, _In_ PUNICODE_STRING RegistryPath)
{
	UNREFERENCED_PARAMETER(DriverObject);
	UNREFERENCED_PARAMETER(RegistryPath);

	NTSTATUS status = STATUS_SUCCESS;

	Log("Driver was loaded");

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