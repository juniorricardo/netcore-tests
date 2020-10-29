using System;
using BenchmarkDotNet.Running;

namespace Pattern.Benchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<OperacionesMatematicasBenchmark>();
            Console.Read();
        }
    }
}
