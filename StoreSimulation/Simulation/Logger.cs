using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoreSimulation
{
    static class Logger
    {
        static System.IO.TextWriter output = new System.IO.StreamWriter("log.txt", true);

        public static void Output(string message)
        {
            Logger.output.WriteLine(message);
        }
        public static void Info(string message)
        {
            Logger.output.WriteLine("INFO: " + message);;
        }

        public static void Event(string message)
        {
            Logger.output.WriteLine("EVENT: " + message);
        }

        public static void Error(string message)
        {
            Logger.output.WriteLine("ERROR: " + message);
        }

        public static void changeOutput(System.IO.TextWriter newOut)
        {
            Logger.output.Close();
            Logger.output = newOut;
        }

        public static void close()
        {
            Logger.output.Close();
        }
    }
}
