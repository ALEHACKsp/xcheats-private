using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace apex.Driver
{
    class Helper6
    {
        private static IntPtr socket;
        private static uint PID;

        public static ulong GetBase()
        {
            return Imports.GetBase(socket, PID);
        }

        public static void Init(int port)
        {
            Imports.Initialize();
            socket = Imports.Connect(port);

            PID = (uint)Imports.GetPID();

            if (PID == 0)
            {
                throw new Exception("Apex PID not found!");
            }
        }

        public static void Clean()
        {
            Imports.Disconnect(socket);
            Imports.Deinitialize();
        }

        public static unsafe T Read<T>(ulong address)
        {
            int size = Marshal.SizeOf(typeof(T));

            IntPtr buffer = Marshal.AllocHGlobal(size);
            Imports.ReadMemory(socket, (uint)PID, address, (UIntPtr)buffer.ToPointer(), size);

            T structure = (T)Marshal.PtrToStructure(buffer, typeof(T));
            Marshal.FreeHGlobal(buffer);

            return structure;
        }

        public static unsafe void Write<T>(ulong address, T data)
        {
            int size = Marshal.SizeOf(typeof(T));

            IntPtr buffer = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(data, buffer, true);

            Imports.WriteMemory(socket, (uint)PID, address, (UIntPtr)buffer.ToPointer(), size);

            Marshal.FreeHGlobal(buffer);
        }

        public static unsafe byte[] ReadByte(ulong address, int size)
        {
            IntPtr buffer = Marshal.AllocHGlobal(size);
            Imports.ReadMemory(socket, (uint)PID, address, (UIntPtr)buffer.ToPointer(), size);

            byte[] output = new byte[size];
            Marshal.Copy(buffer, output, 0, size);

            Marshal.FreeHGlobal(buffer);

            return output;
        }
    }
}
