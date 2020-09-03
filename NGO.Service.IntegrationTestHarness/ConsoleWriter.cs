using System;

namespace NGO.Service.IntegrationTestHarness
{
    public static class ConsoleWriter
    {
        public static void Init()
        {
            Console.WindowHeight = 40;
            Console.WindowWidth = 150;
            Console.Title = "Serice layer integration test";
        }

        public static void WriteInfo(string message)
        {
            Console.Write(message);
        }

        public static void WriteInfoLine(string message)
        {
            Console.WriteLine(message);
        }

        public static void WriteSuccess(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public static void WriteFailure(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public static void WriteWarning(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public static void WriteTask(string message)
        {
            Console.WriteLine(Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
