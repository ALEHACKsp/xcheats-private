using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace apex
{
    class SDK
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct Vector
        {
            float x;
            float y;
            float z;
        }
    }
}
