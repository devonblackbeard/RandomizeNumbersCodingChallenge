using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenchmarkTests
{
    public class RandomNumberGenerator
    {
        public List<int> GetRandomNumberYates()
        {
            int numberIterations = 10000;
            Random random = new Random();
            List<int> listOfInt = Enumerable.Range(1, numberIterations).ToList();

            int count = listOfInt.Count;

            for (int i = 0; i < count - 1; i++)
            {
                int index = i + random.Next(count - i);
                int temp = listOfInt[index];

                listOfInt[i] = temp;
                listOfInt[index] = listOfInt[i];
            }

            return listOfInt;
        }

        public List<int> GetRandomNumberLinq()
        {
            Random random = new Random();
            int numberIterations = 10000;
            var randomList = Enumerable.Range(1, numberIterations).OrderBy(e => random.Next()).ToList();
            return randomList;
        }

        public List<int> GetRandomNumberDoubleLoop()
        {
            Random random = new Random();
            int numberIterations = 10000;
            var randomList = new List<int>();

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
