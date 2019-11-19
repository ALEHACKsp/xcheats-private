using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace apex
{
    class Program
    {
        static void ErrExit()
        {
            Console.ReadKey();
            Environment.Exit(-1);
        }
        
        static void Main(string[] args)
        {
            // TODO: Check if driver is loaded
            // TODO: Make another thread for aimbot entity scan itself
            
            Log.Title();

            Log.Debug("Initialiting...");

            Driver.Helper1.Init(27061);
            Driver.Helper2.Init(27062);
            Driver.Helper3.Init(27063);

            G.baseaddr = Driver.Helper1.GetBase();
            Log.Debug("Base address: " + G.baseaddr);

            Log.Debug("Entity update thread...");
            Thread t1 = new Thread(Threads.EntityUpdate);
            t1.Start();

            Log.Debug("Aimbot update thread...");
            Thread t2 = new Thread(Threads.AimUpdate);
            t2.Start();

            Log.Debug("Aimbot thread...");
            Thread t3 = new Thread(Threads.AimThread);
            t3.Start();

            Log.Info("Cheat is running now!");

            while (true)
            {
                Thread.Sleep(5000);
            }
        }
    }
}
