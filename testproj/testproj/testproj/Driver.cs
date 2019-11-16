using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace testproj.Memory
{
    class Driver
    {
        public static int magic = 0xFEED;
        public static int dpid;
        public static int spid;

        const string dllname = "client_xcheats.dll";

        [DllImport(dllname)]
        public static extern int Init(int magic, int number);

        [DllImport(dllname)]
        public static extern int GetOffset(int magic);

        [DllImport(dllname)]
        public static extern void CopyDriverMemory(int magic, ref CopyStruct str, int number);

        unsafe public struct CopyStruct
        {
            public int dpid;
            public ulong daddr;

            public int spid;
            public ulong saddr;

            public int size;

            public int handled;
        }

        public static void Initialize()
        {
            Init(magic, 10);
            dpid = Process.GetCurrentProcess().Id;
        }

        public static T Read<T>(ulong address, int number)
        {
            int size = Marshal.SizeOf(typeof(T));
            IntPtr alloc = Marshal.AllocHGlobal(size);

            CopyStruct ics = new CopyStruct();
            ics.handled = 0;
            ics.size = size;
            ics.daddr = (ulong)alloc.ToInt64();
            ics.dpid = dpid;
            ics.spid = spid;
            ics.saddr = address;

            CopyDriverMemory(magic, ref ics, number);

            T rvar = (T)Marshal.PtrToStructure(alloc, typeof(T));

            Marshal.FreeHGlobal(alloc);
            return rvar;
        }

        public static void Write<T>(ulong address, T buffer, int number)
        {
            int size = Marshal.SizeOf(typeof(T));
            IntPtr alloc = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(buffer, alloc, true);

            CopyStruct ics = new CopyStruct();
            ics.handled = 0;
            ics.size = size;
            ics.daddr = address;
            ics.dpid = dpid;
            ics.spid = spid;
            ics.saddr = (ulong)alloc.ToInt64();

            CopyDriverMemory(magic, ref ics, number);

            Marshal.FreeHGlobal(alloc);
        }
    }
}
