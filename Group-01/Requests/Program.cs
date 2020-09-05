using System;

namespace Requests
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            Console.WriteLine("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            Console.WriteLine("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            Console.WriteLine("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            Console.WriteLine("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            
            try
            {
                DoSomethingThatMightFail();
            }
            catch (Exception ex)
            {
                Log(ex, "An error occurred");
                throw;
            }
        }
	
        public static void DoSomethingThatMightFail()
        {
            // This will always throw a DivideByZero exception
            var x = 42;
            var y = 0;
            int z = x / y;
        }
	
        static bool Log(Exception ex, string message, params object[] args)
        {
            Console.WriteLine(message, args);
            return false;
        }
    }
}