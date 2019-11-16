using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace testproj.Memory
{
    class Driver
    {
        public static int magic = 0xFEED;
        public static int pid;

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

        }

        public static T Read<T>(ulong address)
        {

        }
    }
}
