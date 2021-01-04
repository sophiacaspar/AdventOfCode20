using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode20.tests
{
    internal class Day06
    {
        public Day06()
        {
        }

        public List<string> ReadFile()
        {
            var yesAnswers = new List<string>();
            try
            {
                var path = @"C:\dev\repos\advent-of-code\AdventOfCode20\Days\Day06\Day06.txt";
                var formatedTextLine = File.ReadAllText(path).Replace("\r\n\r\n", "&").Replace("\r\n", " ");
                var txtLines = formatedTextLine.Split('&');

                foreach (var txtLine in txtLines)
                {
                    yesAnswers.Add(txtLine);
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e);
            }
            return yesAnswers;
        }

        public int CountUniqueYesAnswers(string yesAnswers)
        {
            return yesAnswers.Distinct().Count();
        }

        public int CountSameYesAnswers(string yesAnswers)
        {
            var answers = yesAnswers.Split(' ');
            if(answers.Length == 1)
            {
                return answers[0].Distinct().Count();
            }

            var firstAnswer = answers[0];
            for (int i = 1; i < answers.Length; i++)
            {
                for (int j = 0; j < answers[0].Length; j++)
                {
                    if(firstAnswer.Length == 0)
                    {
                        return 0;
                    }
                    if (!answers[i].Contains(answers[0][j]))
                    {
                        firstAnswer = firstAnswer.Replace(answers[0][j].ToString(), string.Empty);
                    }
                }
            }
            
            return firstAnswer.Distinct().Count();
        }

        public int GetSumOfYesAnswersAnyone(List<string> yesAnswers)
        {
            var sum = 0;
            foreach (var yesAnswer in yesAnswers)
            {
                sum += CountUniqueYesAnswers(yesAnswer.Replace(" ", string.Empty));
            }
            return sum;
        }

        public int GetSumOfYesAnswersEveryone(List<string> yesAnswers)
        {
            var sum = 0;
            foreach (var yesAnswer in yesAnswers)
            {
                sum += CountSameYesAnswers(yesAnswer);
            }
            return sum;
        }
    }
}