#include <Windows.h>
#include <TlHelp32.h>
#include <stdio.h>
#include "Client.h"
#include "Defines.h"

static char BaseOffset[1024];

ULONGLONG GetBase(DWORD procId, const wchar_t* modName)
{
	uintptr_t modBaseAddr = 0;
	HANDLE hSnap = CreateToolhelp32Snapshot(TH32CS_SNAPMODULE | TH32CS_SNAPMODULE32, procId);
	if (hSnap != INVALID_HANDLE_VALUE)
	{
		MODULEENTRY32 modEntry;
		modEntry.dwSize = sizeof(modEntry);
		if (Module32First(hSnap, &modEntry))
		{
			do
			{
				if (!_wcsicmp(modEntry.szModule, modName))
				{
					modBaseAddr = (uintptr_t)modEntry.modBaseAddr;
					break;
				}
			} while (Module32Next(hSnap, &modEntry));
		}
	}
	CloseHandle(hSnap);
	return modBaseAddr;
}

EXPORT_INT GetPID(int magic)
{
	if (magic != MAGIC)
		return 0xDEAD;

	wchar_t* gamename = GAME_NAME;
	
	PROCESSENTRY32 processInfo;
	processInfo.dwSize = sizeof(processInfo);

	HANDLE processesSnapshot = CreateToolhelp32Snapshot(TH32CS_SNAPPROCESS, NULL);
	if (processesSnapshot == INVALID_HANDLE_VALUE) {
		return 0;
	}

	Process32First(processesSnapshot, &processInfo);
	if (!wcscmp(gamename, processInfo.szExeFile))
	{
		CloseHandle(processesSnapshot);
		return processInfo.th32ProcessID;
	}

	while (Process32Next(processesSnapshot, &processInfo))
	{
		if (!wcscmp(gamename, processInfo.szExeFile))
		{
			CloseHandle(processesSnapshot);
			return processInfo.th32ProcessID;
		}
	}

	CloseHandle(processesSnapshot);
	return 0;
}

EXPORT_ULONGLONG GetAddress(int magic, int number)
{
	if (magic != MAGIC)
		return 0xDEAD;

	if (number > 10)
		return 0xFFFF;

	//ULONGLONG offset = (ULONGLONG)(&BaseOffset);
	ULONGLONG offset = (ULONGLONG)(&BaseOffset) + (number * sizeof(CopyStruct));
	return offset;
}

EXPORT_INT Init(int magic, int number) 
{
	if (magic != MAGIC)
		return 0xDEAD;

	if (number > 10)
		return 0xFFFF;

	for (int i = 0; i < number; i++) 
	{
		CopyStruct inits = { 0 };
		inits.daddr = 0xFFFF;
		inits.saddr = 0xFFFF;
		inits.dpid = 0xFFFF;
		inits.spid = 0xFFFF;
		inits.size = 0xFFFF;
		inits.handled = 1;
		ULONGLONG offset = GetAddress(MAGIC, i);
		*(CopyStruct*)offset = inits;
	}

	return 1;
}

EXPORT_INT GetOffset(int magic) 
{
	if (magic != MAGIC)
		return 0xDEAD;
	
	ULONGLONG procbase = GetBase(GetCurrentProcessId(), DLL_NAME);

	ULONGLONG offset = &BaseOffset;
	ULONGLONG stat = offset - procbase;

	return stat;
}

EXPORT_VOID CopyDriverMemory(int magic, CopyStruct* str, int number)
{	
	if (magic != MAGIC)
		return;

	*(CopyStruct*)GetAddress(MAGIC, number) = *str;

	while ((*(CopyStruct*)GetAddress(MAGIC, number)).handled != 1) 
	{
		Sleep(1);
	}

	*str = *(CopyStruct*)GetAddress(MAGIC, number);

	return;
}

// TODO: Rename dll because client.dll is in every fking program

/*int main()
{
	ULONGLONG procbase = GetBase(GetCurrentProcessId(), L"client.exe"); // replace for dll build
	printf("Process: %p\n", &procbase);
	
	ULONGLONG offset = &BaseOffset;
	ULONGLONG stat = offset - procbase;
	printf("Base: %p\n", &BaseOffset);
	printf("Static: %llx\n", stat);

	CopyStruct tests = { 0 };
	tests.daddr = 1234;
	tests.saddr = 3333;
	tests.size = 4444;
	tests.spid = 3343;
	tests.dpid = 4334;

	*(CopyStruct*)(offset + 20) = tests;

	printf("Done");

	while (1) 
	{
		Sleep(10);
	}
}*/
