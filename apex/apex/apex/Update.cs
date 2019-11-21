using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace apex
{
    class Update
    {      
        public static Thread RunThread(int start, int end, int number)
        {
            Thread th = new Thread(() => AimUpdate(start, end, number));
            th.Start();
            return th;
        }
        
        public static void AimUpdate(int start, int end, int number)
        {
            ulong entitylist = G.entitylist;
            if (entitylist == 0)
            {
                return;
            }

            ulong localent = 0;
            if (number == 3)
            {
                localent = Driver.Helper4.Read<ulong>(G.baseaddr + Offsets.locale);
            }
            if (number == 4)
            {
                localent = Driver.Helper5.Read<ulong>(G.baseaddr + Offsets.locale);
            }
            if (number == 5)
            {
                localent = Driver.Helper6.Read<ulong>(G.baseaddr + Offsets.locale);
            }
            if (number == 6)
            {
                localent = Driver.Helper7.Read<ulong>(G.baseaddr + Offsets.locale);
            }
            
            Vector3 LocalCamera = SDK.GetCamPos(localent, number);
            Vector3 ViewAngles = SDK.GetViewAngles(localent, number);

            for (int i = start; i <= end; i++)
            {
                ulong centity = 0;
                if (number == 3)
                {
                    centity = Driver.Helper4.Read<ulong>(entitylist + ((ulong)i << 5));
                }
                if (number == 4)
                {
                    centity = Driver.Helper5.Read<ulong>(entitylist + ((ulong)i << 5));
                }
                if (number == 5)
                {
                    centity = Driver.Helper6.Read<ulong>(entitylist + ((ulong)i << 5));
                }
                if (number == 6)
                {
                    centity = Driver.Helper7.Read<ulong>(entitylist + ((ulong)i << 5));
                }
                if (centity == 0)
                    continue;

                ulong name = 0;
                if (number == 3)
                {
                    name = Driver.Helper4.Read<ulong>(centity + Offsets.name);
                }
                if (number == 4)
                {
                    name = Driver.Helper5.Read<ulong>(centity + Offsets.name);
                }
                if (number == 5)
                {
                    name = Driver.Helper6.Read<ulong>(centity + Offsets.name);
                }
                if (number == 6)
                {
                    name = Driver.Helper7.Read<ulong>(centity + Offsets.name);
                }
                if (name != 125780153691248)  // "player.."
                {
                    continue;
                }

                if (localent == centity)
                {
                    continue;
                }

                Vector3 FeetPosition = SDK.GetEntityBasePosition(centity, number);
                Vector3 HeadPosition = SDK.GetEntityBonePosition(centity, 8, FeetPosition, number);
                Vector3 CalculatedAngles = SDK.CalcAngle(LocalCamera, HeadPosition);
                //Vector3 Delta = (CalculatedAngles - ViewAngles);

                float fov = SDK.GetFov(ViewAngles, CalculatedAngles);

                if (fov < G.max && fov < G.s.FOV)
                {
                    G.max = fov;
                    G.aime = centity;
                }
            }
        }
    }
}
