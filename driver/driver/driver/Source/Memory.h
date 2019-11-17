#pragma once

NTSTATUS NTAPI MmCopyVirtualMemory
(
	PEPROCESS SourceProcess,
	PVOID SourceAddress,
	PEPROCESS TargetProcess,
	PVOID TargetAddress,
	SIZE_T BufferSize,
	KPROCESSOR_MODE PreviousMode,
	PSIZE_T ReturnSize
);

NTKERNELAPI PVOID PsGetProcessSectionBaseAddress(
	IN PEPROCESS		Process
);

NTSTATUS CopyVirtualMemory(PEPROCESS SourceProcess, PEPROCESS TargetProcess, PVOID SourceAddress, PVOID TargetAddress, SIZE_T Size);