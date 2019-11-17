using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace apex
{
    class Threads
    {
        public static void EntityUpdate()
        {
            while (true)
            {
                Thread.Sleep(1);

                ulong entitylist = G.baseaddr + 0x0;
            }
        }
    }
}
