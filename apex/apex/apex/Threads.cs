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

                ulong entitylist = G.baseaddr + Offsets.entitylist;
                ulong baseent = Driver.Read<ulong>(entitylist, 0);
                if (baseent == 0)
                {
                    continue;
                }

                /* First 100 entities should be all players in game
                 * The issue is that sometimes I saw someone without glow
                 * so I increased it to 150 and it seems like it works now. */
                for (int i = 0; i < 150; i++)
                {
                    ulong centity = Driver.Read<ulong>(entitylist + ((ulong)i << 5), 0);

                    // I am bad at reading strings stfu
                    ulong name = Driver.Read<ulong>(centity + Offsets.name, 0);
                    if (name != 125780153691248)  // "player.."
                    {
                        continue;
                    }

                    int health = Driver.Read<int>(centity + Offsets.health, 0);
                    if (health < 1 || health > 100)
                        continue;

                    int shield = Driver.Read<int>(centity + Offsets.shield, 0);
                    int total = health + shield;

                    float green = 0;
                    float red = 0;
                    float blue = 0;

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

                    Driver.Write<int>(centity + Offsets.glowenable, 1, 0);
                    Driver.Write<int>(centity + Offsets.glowcontext, 1, 0);
                    
                    Driver.Write<float>(centity + Offsets.glowcolors, red, 0);
                    Driver.Write<float>(centity + Offsets.glowcolors + 0x4, green, 0);
                    Driver.Write<float>(centity + Offsets.glowcolors + 0x8, blue, 0);

                    for (ulong offset = 0x2D0; offset <= 0x2E8; offset += 0x4)
                        Driver.Write<float>(centity + offset, float.MaxValue, 0);

                    Driver.Write<float>(centity + Offsets.glowrange, float.MaxValue, 0);
                }
            }
        }
    }
}
