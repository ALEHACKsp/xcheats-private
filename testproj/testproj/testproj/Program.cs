using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace testproj
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadKey();
            
            long baseaddr = Process.GetCurrentProcess().MainModule.BaseAddress.ToInt64();
            Console.WriteLine("Base: " + baseaddr.ToString("X"));
            
            int ini = Memory.Driver.Init(Memory.Driver.magic, 10);
            Console.WriteLine("Init: " + ini.ToString("X"));
            
            int offset = Memory.Driver.GetOffset(Memory.Driver.magic);
            Console.WriteLine("Static: " + offset.ToString("x"));

            IntPtr alloc = Marshal.AllocHGlobal(64);
            Console.WriteLine("Alloc: " + alloc.ToString("X"));

            Memory.Driver.CopyStruct ics = new Memory.Driver.CopyStruct();
            ics.handled = 0;
            ics.size = 64;
            ics.daddr = (ulong)alloc.ToInt64();
            ics.dpid = Process.GetCurrentProcess().Id;
            ics.spid = Process.GetProcessesByName("ProcessHacker")[0].Id;
            ics.saddr = (ulong)Process.GetProcessesByName("ProcessHacker")[0].MainModule.BaseAddress.ToInt64();
            Memory.Driver.CopyDriverMemory(Memory.Driver.magic, ref ics, 2);

            Console.WriteLine("Dpid: " + ics.dpid.ToString("X"));
            Console.WriteLine("Spid: " + ics.spid.ToString("X"));
            Console.WriteLine("Saddr: " + ics.saddr.ToString("X"));
            Console.WriteLine("Handled: " + ics.handled.ToString("X"));

            Console.ReadKey();
        }
    }
}
