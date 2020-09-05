using System;

namespace Comparable
{
    class Program
    {
        static void Main(string[] args)
        {
            // BasicEssentials.PrintMessage.ShowTitle("Years");
            // OYears primer = new OYears(20);
            // OYears segundo = new OYears(10);
            //
            // Console.WriteLine("Sos igual? " + primer.sosIgual(segundo));
            // Console.WriteLine("Sos menor? " + primer.sosMenor(segundo));
            // Console.WriteLine("Sos mayor? " + primer.sosMayor(segundo));
            //
            //
            // BasicEssentials.PrintMessage.ShowTitle("Years");
            // Keys tercer = new Keys("day");
            // Keys cuarto = new Keys("one");
            //
            // // == 0 ; != -1 ;
            // Console.WriteLine("Compare? " + tercer.CompareTo(cuarto));
            RunOutParam();
        }
        static void RunOutParam()
        {
            int argNumber;
            string argMessage, argDefault;
            
            Method(out argNumber, out argMessage, out argDefault);
            Console.WriteLine(argNumber);
            Console.WriteLine(argMessage);
            Console.WriteLine(argDefault == null);
            
            string numberAsString = "1640";

            if (Int32.TryParse(numberAsString, out int number))
                Console.WriteLine($"Converted '{numberAsString}' to {number}");
            else
                Console.WriteLine($"Unable to convert '{numberAsString}'");
        }
        static void Method(out int answer, out string message, out string stillNull)
        {
            answer = 44;
            message = "I've been returned";
            stillNull = null;
        }
    }
}
