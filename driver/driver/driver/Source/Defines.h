#pragma once

#define TRUE 1
#define FALSE 0

#define STATIC_ADDR 0x1c170
#define DLL_NAME L"client_xcheats.dll"

// Change to FALSE if building for release
// Disables logging and debug features
#define BUILD_DEBUG TRUE

// How many "threads" should driver use
#define BUILD_THREADS 9

#define ABSOLUTE(wait) (wait)
#define RELATIVE(wait) (-(wait))

#define NANOSECONDS(nanos) \
(((signed __int64)(nanos)) / 100L)

#define MICROSECONDS(micros) \
(((signed __int64)(micros)) * NANOSECONDS(1000L))

#define MILLISECONDS(milli) \
(((signed __int64)(milli)) * MICROSECONDS(1000L))

#define SECONDS(seconds) \
(((signed __int64)(seconds)) * MILLISECONDS(1000L))

typedef struct _CopyStruct
{
	INT dpid;
	ULONGLONG daddr;

	INT spid;
	ULONGLONG saddr;

	INT size;

	INT handled;  // true (1) if the driver has already done it's job
	INT getbase;
	INT shouldexit;
} CopyStruct;

extern ULONGLONG g_Base; 
extern HANDLE g_PID;

extern BOOLEAN g_Exit;