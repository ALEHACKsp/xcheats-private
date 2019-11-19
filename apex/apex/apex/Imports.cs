using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace apex.Driver
{
    class Imports
    {
        const string DllName = "client64.dll";

        [DllImport(DllName, EntryPoint = "connectsocket", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr Connect(int port);

        [DllImport(DllName, EntryPoint = "disconnect", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr Disconnect(IntPtr socket);

        [DllImport(DllName, EntryPoint = "initialize", CallingConvention = CallingConvention.StdCall)]
        public static extern void Initialize();

        [DllImport(DllName, EntryPoint = "deinitialize", CallingConvention = CallingConvention.StdCall)]
        public static extern void Deinitialize();

        [DllImport(DllName, EntryPoint = "read_memory", CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 ReadMemory(IntPtr connection, UInt32 process_id, ulong address, UIntPtr buffer, int size);

        [DllImport(DllName, EntryPoint = "write_memory", CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 WriteMemory(IntPtr connection, UInt32 process_id, ulong address, UIntPtr buffer, int size);

        [DllImport(DllName, EntryPoint = "get_process_base_address", CallingConvention = CallingConvention.StdCall)]
        public static extern UInt64 GetBase(IntPtr connection, UInt32 process_id);

        [DllImport(DllName, EntryPoint = "get_pid", CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 GetPID();
    }
}
