using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode20.tests
{
    internal class Day02
    {
        public Day02()
        {
        }

        public List<string> ReadFile()
        {
            var passwordRows = new List<string>();
            try
            {
                var path = @"C:\dev\repos\advent-of-code\AdventOfCode20\Days\Day02\Day02.txt";
                var formatedTextLine = File.ReadAllText(path).Replace("\n", "&").Replace("\r", String.Empty);
                var txtLines = formatedTextLine.Split('&');
                
                foreach (var txtLine in txtLines)
                {
                    passwordRows.Add(txtLine);
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e);
            }
            return passwordRows;
        }

        public bool CheckIfPasswordIsValid(string passwordRow)
        {
            var policy = passwordRow.Split(':')[0];
            var policyRule = policy.Split(' ')[0];
            var min = policyRule.Split('-')[0];
            var max = policyRule.Split('-')[1];
            var policyLetter = policy.Split(' ')[1][0];

            var password = passwordRow.Split(':')[1];

            var counter = 0;
            foreach (var letter in password)
            {
                if (letter == policyLetter)
                {
                    counter++;
                }
            }

            return (counter >= int.Parse(min) && counter <= int.Parse(max));


        }

        public bool CheckIfPasswordPositionIsValid(string passwordRow)
        {
            var policy = passwordRow.Split(':')[0];
            var policyRule = policy.Split(' ')[0];
            var p1 = int.Parse(policyRule.Split('-')[0]);
            var p2 = int.Parse(policyRule.Split('-')[1]);
            var policyLetter = char.Parse(policy.Split(' ')[1]);

            var password = passwordRow.Split(':')[1].Trim(' ');

            var counter = 0;
            for (int i = 0; i < password.Length; i++)
            {
                if (password[i] == policyLetter && (i+1 == p1 || i+1 == p2))
                {
                    counter++;
                }
            }
            return counter == 1;
        }

        public int CountNumberOfValidPasswordPositions(List<string> passwords)
        {
            var counter = 0;
            foreach (var passwordRow in passwords)
            {
                if (CheckIfPasswordPositionIsValid(passwordRow))
                {
                    counter++;
                }
            }
            return counter;
        }

        public int CountNumberOfValidPasswords(List<string> passwords)
        {
            var counter = 0;
            foreach (var passwordRow in passwords)
            {
                if (CheckIfPasswordIsValid(passwordRow))
                {
                    counter++;
                }
            }
            return counter;
        }
    }
}