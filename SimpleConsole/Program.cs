using System;

namespace SimpleConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "1.2";

            int number = Int32.Parse(input);
            Console.WriteLine("Hello World!", number);
        }
    }
}