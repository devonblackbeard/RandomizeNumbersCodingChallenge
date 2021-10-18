using System;
using System.Linq;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using BenchmarkTests;

namespace BenchmarkEfficiencyTests
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Lets Generate Random Numbers!");

            BenchmarkRunner.Run<RandomNumberGeneratorBenchmark>();

            Console.ReadKey();

        }

    }
}
