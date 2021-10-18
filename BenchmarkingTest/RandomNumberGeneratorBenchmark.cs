using BenchmarkDotNet.Attributes;
using System.Collections.Generic;

namespace BenchmarkTests
{
    [MemoryDiagnoser]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class RandomNumberGeneratorBenchmark
    {

        [Benchmark(Baseline = true)]
        public List<int> GetRandomNumberFisherYates()
        {
            RandomNumberGenerator generator = new RandomNumberGenerator();
            var randomList = generator.GetRandomNumberYates();
            return randomList;
        }

        [Benchmark]
        public List<int> GetRandomNumberDoubleLoop()
        {
            RandomNumberGenerator generator = new RandomNumberGenerator();
            var randomList = generator.GetRandomNumberDoubleLoop();
            return randomList;
        }

        [Benchmark]
        public List<int> GetRandomNumberLinq()
        {
            RandomNumberGenerator generator = new RandomNumberGenerator();
            var randomList = generator.GetRandomNumberLinq();
            return randomList;
        }

    }
}
