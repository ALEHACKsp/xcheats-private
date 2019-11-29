using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apex
{
    class Log
    {
        private static string _logfile;
        
        public static void Init(string filename)
        {
            _logfile = filename;
        }

        public static void WriteLine(string text)
        {
            File.AppendAllText(_logfile, text + "\n");
        }
        
        public static void Reset()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }
        
        public static void Title()
        {
            //Reset();
            //Console.Clear();
            //Console.ForegroundColor = ConsoleColor.Green;
            WriteLine("     _   ");
            WriteLine("(||)(/_><");
            WriteLine("  |      ");
            //Console.ForegroundColor = ConsoleColor.DarkYellow;
            WriteLine("Copyright (c) 2019 xcheats.cc - All rights reserved\n");
            //Reset();
        }  

        public static void Print(string text, ConsoleColor c)
        {
            //Console.ForegroundColor = c;
            //Console.WriteLine($"[{DateTime.Now.ToString("HH:mm:ss")}] {text}");
            WriteLine($"[{DateTime.Now.ToString("HH:mm:ss")}] {text}");
            Reset();
        }

        public static void Info(string text)
        {
            Print(text, ConsoleColor.White);
        }

        public static void Debug(string text)
        {
            Print(text, ConsoleColor.DarkGray);
        }

        public static void Error(string text)
        {
            Print(text, ConsoleColor.Red);
        }

        public static void Warning(string text)
        {
            Print(text, ConsoleColor.Yellow);
        }

        public static void Success(string text)
        {
            Print(text, ConsoleColor.Green);
        }
    }
}
