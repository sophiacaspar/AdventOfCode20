using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode20.tests
{
    class Day01
    {
        public List<int> ReadFile()
        {
            var expenseReport = new List<int>();
            try
            {
                var path = @"C:\dev\repos\advent-of-code\AdventOfCode20\Days\Day01\Day01.txt";
                var formatedTextLine = File.ReadAllText(path).Replace("\n", " ").Replace("\r", String.Empty);
                var txtLines = formatedTextLine.Split(' ');

                foreach (var txtLine in txtLines)
                {
                    expenseReport.Add(int.Parse(txtLine));
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e);
            }
            return expenseReport;
        }

        public List<int> GetTwoValuesThatEqualsSum(List<int> array, int wantedSum)
        {
            for (int i = 0; i < array.Count-1; i++)
            {
                for (int j = 0; j < array.Count-1; j++)
                {
                    if(array[i] + array[j] == wantedSum)
                    {
                        return new List<int> { array[i], array[j] };
                    }
                }
            }
            return new List<int>();
        }

        public List<int> GetThreeValuesThatEqualsSum(List<int> array, int wantedSum)
        {
            for (int i = 0; i < array.Count - 1; i++)
            {
                for (int j = 0; j < array.Count - 1; j++)
                {
                    for (int k = 0; k < array.Count; k++)
                    {
                        if (array[i] + array[j] + array[k] == wantedSum)
                        {
                            return new List<int> { array[i], array[j], array[k] };
                        }
                    }

                }
            }
            return new List<int>();
        }

        public int Multiply(List<int> array)
        {
            var product = 1;
            foreach (var val in array)
            {
                product *= val;
            }
            return product;
        }

    }
}