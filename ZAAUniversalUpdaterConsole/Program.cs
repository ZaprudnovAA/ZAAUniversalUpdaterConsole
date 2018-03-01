using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace ZAAUniversalUpdaterConsole
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                var process = args[1].Replace(".exe", "");

                foreach (Process proc in Process.GetProcessesByName(process))
                {
                    Console.WriteLine("Terminate process!");
                    proc.Kill();
                    Thread.Sleep(300);
                }

                if (File.Exists(args[1]))
                {
                    File.Delete(args[1]);
                }

                if (File.Exists(args[0]))
                {
                    File.Move(args[0], args[1]);
                }


                Console.WriteLine("Starting " + args[1]);
                Process.Start(args[1]);
            }
            catch (Exception)
            {
                // ignored
            }
        }
    }
}