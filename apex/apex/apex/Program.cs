using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

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

            Log.Debug("Initialiting...");
            
            Settings settings = new Settings();
            settings.Aimbot = true;
            settings.SmoothAim = false;
            settings.NoRecoil = true;
            settings.Glow = true;
            settings.Health = true;
            settings.Shields = true;
            settings.SmoothDivider = 100;
            settings.Aimkey = 0x6;
            settings.FOV = 180;
            G.s = settings;

            Driver.Helper1.Init(27061);
            Driver.Helper2.Init(27062);
            Driver.Helper3.Init(27063);
            Driver.Helper4.Init(27064);
            Driver.Helper5.Init(27065);
            Driver.Helper6.Init(27066);
            Driver.Helper7.Init(27067);

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

            Log.Debug("Info thread...");
            Thread t4 = new Thread(Threads.InfoThread);
            t4.Start();

            Log.Info("Cheat is running now!");

            Application.EnableVisualStyles();
            MainForm mf = new MainForm();
            Application.Run(mf);

            /*while (true)
            {
                Thread.Sleep(5000);
            }*/
        }
    }
}
