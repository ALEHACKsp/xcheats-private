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
            Log.Title();

            Log.Info("Initialiting...");

            Log.Debug("Getting game PID...");
            G.PID = Driver.GetPID(Driver.magic);
            if (G.PID == 0)
            {
                Log.Error("Could not find game PID. Is the game running?");
                ErrExit();
            }
            Log.Debug("Game PID is " + G.PID);

            Log.Debug("Allocating memory for driver communication...");
            Driver.Initialize(G.PID);

            Log.Debug("Getting game base...");
            G.baseaddr = Driver.GetBase(G.PID);
            if (G.baseaddr == 0)
            {
                Log.Error("Failed to get game base address!");
                ErrExit();
            }
            Log.Debug("Game base address is " + G.baseaddr.ToString("X"));

            Log.Info("Running threads...");
            
            Log.Debug("Entity update thread...");
            Thread t1 = new Thread(Threads.EntityUpdate);
            t1.Start();

            Console.WriteLine("The cheat is running now. Press any key to safely exit the driver.");
            Console.ReadKey();

            Log.Info("Safe exiting driver...");
            Driver.Exit();
            Thread.Sleep(1000);
            Log.Success("Driver exited");

            Console.ReadKey();
        }
    }
}
