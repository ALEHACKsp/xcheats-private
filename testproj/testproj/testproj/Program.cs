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
            int id = Process.GetProcessesByName("ProcessHacker")[0].Id;
            ulong baseaddr = (ulong)Process.GetProcessesByName("ProcessHacker")[0].MainModule.BaseAddress.ToInt64();
            Memory.Driver.Initialize(id);
            Memory.Driver.Read<ulong>(baseaddr, 0);

            Console.ReadKey();
        }
    }
}
