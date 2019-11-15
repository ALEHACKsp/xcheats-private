#include <ntddk.h>
#include "Memory.h"

NTSTATUS CopyVirtualMemory(PEPROCESS SourceProcess, PEPROCESS TargetProcess, PVOID SourceAddress, PVOID TargetAddress, SIZE_T Size)
{
	PSIZE_T Bytes = 0;
	if (NT_SUCCESS(MmCopyVirtualMemory(SourceProcess, SourceAddress, TargetProcess,
		TargetAddress, Size, KernelMode, Bytes)))
		return STATUS_SUCCESS;
	else
		return STATUS_ACCESS_DENIED;
}