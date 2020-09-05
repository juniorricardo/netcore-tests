using System;
using BasicEssentials;

namespace Runner
{
    class Program
    {
        static void Main(string[] args)
        {

            var client = new ClientHttp();
            // client.GetRestSharp();

            client.GetSmp();
            Console.WriteLine("Hello World!");
        }
    }
}