#include <ntddk.h>
#include "Defines.h"

void Log(char* text) 
{
	if (!BUILD_DEBUG) return;
	DbgPrintEx(0, 0, "[xcheats.cc] %s", text);
}