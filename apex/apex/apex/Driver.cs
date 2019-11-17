using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace apex
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
        public static extern int GetPID(int magic);

        [DllImport(dllname)]
        public static extern void CopyDriverMemory(int magic, ref CopyStruct str, int number);

        [StructLayout(LayoutKind.Sequential)]
        public struct CopyStruct
        {
            public int dpid;
            public ulong daddr;

            public int spid;
            public ulong saddr;

            public int size;

            public int handled;
            public int getbase;
            public int shouldexit;
        }

        public static void Initialize(int pid)
        {
            Init(magic, 10);
            dpid = Process.GetCurrentProcess().Id;
            spid = pid;
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
            ics.getbase = 0;

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
            ics.dpid = spid;
            ics.spid = dpid;
            ics.saddr = (ulong)alloc.ToInt64();
            ics.getbase = 0;

            CopyDriverMemory(magic, ref ics, number);

            Marshal.FreeHGlobal(alloc);
        }

        public static ulong GetBase(int PID)
        {
            CopyStruct ics = new CopyStruct();
            ics.handled = 0;
            ics.size = 0;
            ics.daddr = 0;
            ics.dpid = PID;
            ics.spid = 0;
            ics.saddr = 0;
            ics.getbase = 1;

            CopyDriverMemory(magic, ref ics, 0);

            return ics.daddr;
        }

        public static void Exit()
        {
            CopyStruct ics = new CopyStruct();
            ics.handled = 0;
            ics.size = 0;
            ics.daddr = 0;
            ics.dpid = 0;
            ics.spid = 0;
            ics.saddr = 0;
            ics.getbase = 0;
            ics.shouldexit = 1;

            CopyDriverMemory(magic, ref ics, 0);
        }
    }
}
