using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace apex
{
    class G
    {
        public static ulong baseaddr;

        public static ulong aimentity;
        public static ulong entitylist;

        public static long entloop;
        public static long aimloop;
        public static long lockloop;

        public static float max = 999.0f;
        public static float random = 0.0f;
        public static ulong aime = 0;

        public static Settings s;

        public static Thread t1;
        public static Thread t2;
        public static Thread t3;
        public static Thread t4;

        public static bool lockent;
    }
}
