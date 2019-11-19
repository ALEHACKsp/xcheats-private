#pragma once
#include <WinSock2.h>
#include <cstdint>

/*void	initialize();
void	deinitialize();

SOCKET	connect();
void	disconnect(SOCKET connection);*/

/*uint32_t read_memory(SOCKET connection, uint32_t process_id, uintptr_t address, uintptr_t buffer, size_t size);
uint32_t write_memory(SOCKET connection, uint32_t process_id, uintptr_t address, uintptr_t buffer, size_t size);
uint64_t get_process_base_address(SOCKET connection, uint32_t process_id);*/

extern "C"
{
	typedef __int32 int32_t;
	typedef unsigned __int32 uint32_t;
		
	__declspec(dllexport) uint32_t __stdcall read_memory(SOCKET connection, uint32_t process_id, uintptr_t address, uintptr_t buffer, size_t size);
	__declspec(dllexport) uint32_t __stdcall write_memory(SOCKET connection, uint32_t process_id, uintptr_t address, uintptr_t buffer, size_t size);
	__declspec(dllexport) uint64_t __stdcall get_process_base_address(SOCKET connection, uint32_t process_id);
		
	__declspec(dllexport) void	__stdcall initialize();
	__declspec(dllexport) void	__stdcall deinitialize();

	__declspec(dllexport) SOCKET __stdcall connectsocket(int port);
	__declspec(dllexport) void __stdcall disconnect(SOCKET connection);

	__declspec(dllexport) int __stdcall get_pid();
}

template <typename T>
T read(const SOCKET connection, const uint32_t process_id, const uintptr_t address)
{
	T buffer{ };
	read_memory(connection, process_id, address, uint64_t(&buffer), sizeof(T));

	return buffer;
}

template <typename T>
void write(const SOCKET connection, const uint32_t process_id, const uintptr_t address, const T& buffer)
{
	write_memory(connection, process_id, address, uint64_t(&buffer), sizeof(T));
}
