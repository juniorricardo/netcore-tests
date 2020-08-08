using System;

namespace BasicEssentials
{
    public class PrintMessage
    {
        private static string halfDobleLine = "===============";
        private static string blockDoble = "===================================";
        private static string halfSimpleLine = "---------------";
        private static string blockSimple = "-----------------------------------";

        public static void ShowTitle(string title)
        {
            Console.WriteLine($"{blockDoble}\n | : > {title} \n{blockDoble}");
        }
        public static void ShowDobleSeparator() => Console.WriteLine(blockDoble);
        public static void ShowSimpleSeparator() => Console.WriteLine(blockSimple);
    }
}
