#include "server_shared.h"
#include "sockets.h"
#include "log.h"
#include "imports.h"

extern uint64_t handle_incoming_packet(const Packet& packet);
extern bool		complete_request(SOCKET client_connection, uint64_t result);

#define THREADS 10

struct paramss 
{
	int socketpointer;
};

void Wait(int milliseconds)
{
	LARGE_INTEGER delay;
	delay.QuadPart = RELATIVE(MILLISECONDS(milliseconds));

	NTSTATUS status = KeDelayExecutionThread(KernelMode, FALSE, &delay);

	if (!NT_SUCCESS(status))
	{
		log("Wait failed");
	}
}

void WaitS(int milliseconds)
{
	LARGE_INTEGER delay;
	delay.QuadPart = RELATIVE(MICROSECONDS(milliseconds));

	NTSTATUS status = KeDelayExecutionThread(KernelMode, FALSE, &delay);

	if (!NT_SUCCESS(status))
	{
		log("Short wait failed");
	}
}

void create_thread(PWORKER_THREAD_ROUTINE routine, paramss context)
{
	log("Creating thread for routine %p...", routine);
	KeEnterGuardedRegion();
	
	PWORK_QUEUE_ITEM WorkItem = (PWORK_QUEUE_ITEM)ExAllocatePool(NonPagedPool, sizeof(WORK_QUEUE_ITEM));
	paramss* parameters = (paramss*)ExAllocatePool(PagedPool, sizeof(paramss)); // change to NonPagedPool if shit
	
	if (!WorkItem)
	{
		log("Failed to allocate memory for work item.");
		return;
	}
	if (!WorkItem)
	{
		log("Failed to allocate memory for parameters.");
		return;
	}
	parameters->socketpointer = context.socketpointer;

	ExInitializeWorkItem(WorkItem, routine, (PVOID)parameters);
	ExQueueWorkItem(WorkItem, DelayedWorkQueue);
	KeLeaveGuardedRegion();
}

static SOCKET create_listen_socket(int server_port_intr)
{
	SOCKADDR_IN address{ };

	address.sin_family	= AF_INET;
	address.sin_port	= htons(server_port_intr);

	const auto listen_socket = socket_listen(AF_INET, SOCK_STREAM, 0);
	if (listen_socket == INVALID_SOCKET)
	{
		log("Failed to create listen socket.");
		return INVALID_SOCKET;
	}

	if (bind(listen_socket, (SOCKADDR*)&address, sizeof(address)) == SOCKET_ERROR)
	{
		log("Failed to bind socket.");

		closesocket(listen_socket);
		return INVALID_SOCKET;
	}

	if (listen(listen_socket, 10) == SOCKET_ERROR)
	{
		log("Failed to set socket mode to listening.");

		closesocket(listen_socket);
		return INVALID_SOCKET;
	}

	return listen_socket;
}

// Connection handling thread.
static void NTAPI connection_thread(void* connection_socket)
{	
	paramss* parameters = (paramss*)connection_socket;
	
	/*int test = parameters->socketpointer;
	int test2 = *(int*)connection_socket;
	log("socket_a: %p", connection_socket);
	log("socket_aa: %p", test);
	log("socket_aaa: %p", test2);
	return;*/
	
	const auto client_connection = parameters->socketpointer;
	log("New connection.");

	Packet packet{ };
	while (true)
	{
		WaitS(10);
		
		const auto result = recv(client_connection, (void*)&packet, sizeof(packet), 0);
		if (result <= 0)
			break;

		if (result < sizeof(PacketHeader))
			continue;

		if (packet.header.magic != packet_magic)
			continue;

		const auto packet_result = handle_incoming_packet(packet);
		if (!complete_request(client_connection, packet_result))
			break;
	}

	log("Connection closed.");
	closesocket(client_connection);
}

void NTAPI main_thread(void*)
{	
	int port = server_port + g_Thread;
	log("Initializing on port %d...", port);

	const auto listen_socket = create_listen_socket(port);
	if (listen_socket == INVALID_SOCKET)
	{
		log("Failed to initialize listening socket.");
		g_Failed = true;
		KsDestroy();
		return;
	}

	log("Listening on port %d.", port);

	while (true)
	{
		Wait(20);
		
		sockaddr  socket_addr{ };
		socklen_t socket_length{ };

		const auto client_connection = accept(listen_socket, &socket_addr, &socket_length);
		if (client_connection == INVALID_SOCKET)
		{
			log("Failed to accept client connection.");
			g_Failed = true;
			break;
		}

		/*HANDLE thread_handle = nullptr;

		// Create a thread that will handle connection with client.
		// TODO: Limit number of threads.
		status = PsCreateSystemThread(
			&thread_handle,
			GENERIC_ALL,
			nullptr,
			nullptr,
			nullptr,
			connection_thread,
			(void*)client_connection
		);

		if (!NT_SUCCESS(status))
		{
			log("Failed to create thread for handling client connection.");

			closesocket(client_connection);
			break;
		}

		ZwClose(thread_handle);*/

		paramss parameters = { client_connection };
		create_thread(connection_thread, parameters);
	}

	closesocket(listen_socket);

	// Better not destroy, maybe threads handling client connection are still running.
	// TODO: Fix it
	// KsDestroy();
}

// Main server thread.
void NTAPI server_thread(void*)
{
	auto status = KsInitialize();
	if (!NT_SUCCESS(status))
	{
		log("Failed to initialize KSOCKET. Status code: %X.", status);
		return;
	}
	
	for (int i = 0; i < THREADS; i++) 
	{
		g_Thread += 1;
		Wait(1000);
		
		if (g_Failed) 
		{
			log("Exiting. There was an error.");
			return;
		}


		paramss blank = { 0 };
		create_thread(main_thread, blank);
		Wait(2000);
	}
}