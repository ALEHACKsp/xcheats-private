using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apex
{
    class Debug
    {
        public static void DumpRegion(string path, ulong addr, int size)
        {
            byte[] output = Driver.Helper1.ReadByte(addr, size);
            File.WriteAllBytes(path, output);
        }
    }
}
