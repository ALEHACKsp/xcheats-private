#pragma once

#define TRUE 1
#define FALSE 0

// Change to FALSE if building for release
// Disables logging and debug features
#define BUILD_DEBUG TRUE

struct CopyMemory 
{
	INT handled; // true (1) if the driver has already done it's job

	INT dpid;
	ULONGLONG daddr;

	INT spid;
	ULONGLONG saddr;

	INT size;

	char buffer[1024];
};