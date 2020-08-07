using System;

namespace Comparable
{
    class Program
    {
        static void Main(string[] args)
        {
            BasicEssentials.PrintMessage.ShowTitle("Years");
            OYears primer = new OYears(20);
            OYears segundo = new OYears(10);

            Console.WriteLine("Sos igual? " + primer.sosIgual(segundo));
            Console.WriteLine("Sos menor? " + primer.sosMenor(segundo));
            Console.WriteLine("Sos mayor? " + primer.sosMayor(segundo));
            
            
            BasicEssentials.PrintMessage.ShowTitle("Years");
            Keys tercer = new Keys("day");
            Keys cuarto = new Keys("one");

            // == 0 ; != -1 ;
            Console.WriteLine("Compare? " + tercer.CompareTo(cuarto));

        }
    }
}
