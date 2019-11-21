using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace apex
{
    class Threads
    {
        public static void InfoThread()
        {
            Thread.Sleep(1000);

            Console.ForegroundColor = ConsoleColor.Cyan;

            while (true)
            {
                Thread.Sleep(100);
                Console.Write($"\rAim Loop: {G.aimloop}ms Entity Loop: {G.entloop}ms              ");
            }         
        }
        
        public static void AimThread()
        {
            while (true)
            {
                Thread.Sleep(1);

                if (G.aimentity == 0)
                    continue;

                if (!Convert.ToBoolean(Native.GetKeyState((Native.VirtualKeyStates)(G.s.Aimkey)) & 0x8000))
                    continue;

                ulong localent = Driver.Helper2.Read<ulong>(G.baseaddr + Offsets.locale);

                Vector3 LocalCamera = SDK.GetCamPos(localent, 1);
                Vector3 ViewAngles = SDK.GetViewAngles(localent, 1);
                Vector3 FeetPosition = SDK.GetEntityBasePosition(G.aimentity, 1);
                Vector3 HeadPosition = SDK.GetEntityBonePosition(G.aimentity, 8, FeetPosition, 1);
                Vector3 CalculatedAngles = SDK.CalcAngle(LocalCamera, HeadPosition);

                Vector3 Delta = new Vector3();
                if (G.s.SmoothAim)
                {
                    Delta = (CalculatedAngles - ViewAngles) / ((float)G.s.SmoothDivider / 100);
                } else
                {
                    Delta = (CalculatedAngles - ViewAngles);
                }

                Vector3 SmoothedAngles = ViewAngles + Delta;

                if (G.s.NoRecoil)
                {
                    Vector3 RecoilVec = Driver.Helper2.Read<Vector3>(localent + Offsets.aimpunch);

                    RecoilVec = RecoilVec / ((float)G.s.RecoilDivider / 100);
                    if (RecoilVec.X != 0 || RecoilVec.Y != 0)
                    {
                        SmoothedAngles -= RecoilVec;
                    }
                }


                SDK.SetViewAngles(localent, SmoothedAngles, 1);
            }
        }

        public static void AimUpdate()
        {
            while (true)
            {
                Thread.Sleep(1);

                var watch = Stopwatch.StartNew();

                ulong entitylist = G.entitylist;
                if (entitylist == 0)
                {
                    continue;
                }

                Thread th1 = Update.RunThread(0, 25, 3);
                Thread th2 = Update.RunThread(25, 50, 4);
                Thread th3 = Update.RunThread(50, 75, 5);
                Thread th4 = Update.RunThread(75, 100, 6);
                th1.Join();
                th2.Join();
                th3.Join();
                th4.Join();

                G.aimentity = G.aime;

                G.aime = 0;
                G.max = 999.9f;

                watch.Stop();
                G.aimloop = watch.ElapsedMilliseconds;
            }
        }
        
        public static void EntityUpdate()
        {
            G.aimentity = 0;
            
            while (true)
            {
                Thread.Sleep(1);

                var watch = Stopwatch.StartNew();

                ulong entitylist = G.baseaddr + Offsets.entitylist;
                ulong baseent = Driver.Helper1.Read<ulong>(G.entitylist);
                if (baseent == 0)
                {
                    G.entitylist = 0;
                    continue;
                }
                G.entitylist = entitylist;

                for (int i = 0; i < 100; i++)
                {
                    ulong centity = Driver.Helper1.Read<ulong>(G.entitylist + ((ulong)i << 5));
                    if (centity == 0) // potato driver fix
                        continue;

                    // I am bad at reading strings stfu
                    ulong name = Driver.Helper1.Read<ulong>(centity + Offsets.name);
                    if (name != 125780153691248)  // "player.."
                    {
                        continue;
                    }

                    int health = Driver.Helper1.Read<int>(centity + Offsets.health);
                    if (health < 1 || health > 100)
                        continue;

                    int shield = Driver.Helper1.Read<int>(centity + Offsets.shield);
                    int total = health + shield;

                    float green = 0;
                    float red = 0;
                    float blue = 0;

                    if (!G.s.Glow)
                        continue;

                    if (G.s.Health)
                    {
                        green = (float)health / 100.0f;
                        red = (100.0f - (float)health) / 100.0f;
                    } else if (G.s.Shields)
                    {
                        if (total > 100)
                        {
                            total -= 100;
                            blue = (float)total / 125.0f;
                            green = (125.0f - (float)total) / 125.0f;
                        }
                        else
                        {
                            green = (float)total / 100.0f;
                            red = (100.0f - (float)total) / 100.0f;
                        }
                    }

                    Driver.Helper1.Write<int>(centity + Offsets.glowenable, 1);
                    Driver.Helper1.Write<int>(centity + Offsets.glowcontext, 1);

                    Driver.Helper1.Write<float>(centity + Offsets.glowcolors, red);
                    Driver.Helper1.Write<float>(centity + Offsets.glowcolors + 0x4, green);
                    Driver.Helper1.Write<float>(centity + Offsets.glowcolors + 0x8, blue);

                    for (ulong offset = 0x2D0; offset <= 0x2E8; offset += 0x4)
                        Driver.Helper1.Write<float>(centity + offset, float.MaxValue);

                    Driver.Helper1.Write<float>(centity + Offsets.glowrange, float.MaxValue);
                }

                watch.Stop();
                G.entloop = watch.ElapsedMilliseconds;
            }
        }
    }
}
