#include "log.h"

extern void NTAPI server_thread(void*);

int g_Thread;
bool g_Failed;

extern "C" NTSTATUS DriverEntry(
	PDRIVER_OBJECT  driver_object,
	PUNICODE_STRING registry_path
)
{
	// These are invalid for mapped drivers.
	UNREFERENCED_PARAMETER(driver_object);
	UNREFERENCED_PARAMETER(registry_path);

	g_Thread = 0;
	g_Failed = false;

	KeEnterGuardedRegion();
	PWORK_QUEUE_ITEM WorkItem = (PWORK_QUEUE_ITEM)ExAllocatePool(NonPagedPool, sizeof(WORK_QUEUE_ITEM));
	if (!WorkItem)
	{
		log("Failed to allocate memory for work item");
	}
	ExInitializeWorkItem(WorkItem, server_thread, WorkItem);
	ExQueueWorkItem(WorkItem, DelayedWorkQueue);
	KeLeaveGuardedRegion();

	/*HANDLE thread_handle = nullptr;

	// Create server thread that will wait for incoming connections.
	const auto status = PsCreateSystemThread(
		&thread_handle,
		GENERIC_ALL,
		nullptr,
		nullptr,
		nullptr,
		server_thread,
		nullptr
	);

	if (!NT_SUCCESS(status))
	{
		log("Failed to create server thread. Status code: %X.", status);
		return STATUS_UNSUCCESSFUL;
	}

	ZwClose(thread_handle);*/

	return STATUS_SUCCESS;
}