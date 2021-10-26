using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RandomizeNumbers.Controllers;


namespace BenchmarkTests
{
    public class RandomNumberGenerator
    {
        public List<int> GetRandomNumberYates(int n)
        {
            List<int> shuffledList = HomeController.GetShuffledListYates(n);
            return shuffledList;
        }

        public List<int> GetRandomNumberLinq()
        {
            Random random = new Random();
            int numberIterations = 10000;
            List<int> randomList = Enumerable.Range(1, numberIterations).OrderBy(e => random.Next()).ToList();
            return randomList;
        }

        public List<int> GetRandomNumberDoubleLoop()
        {
            Random random = new Random();
            int numberIterations = 10000;
            List<int> randomList = new List<int>();

            for (int i = 0; i < numberIterations;)
            {
                int num = random.Next(1, numberIterations);
                while (randomList.Contains(num))
                {
                    num = random.Next(1, numberIterations + 1);
                }
                randomList.Add(num);
                i++;
            }

            return randomList;
        }
    }
}
