using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode20.tests
{
    public class Day05
    {
        public Day05()
        {
        }

        public List<string> ReadFile()
        {
            var boardingPasses = new List<string>();
            try
            {
                var path = @"C:\dev\repos\advent-of-code\AdventOfCode20\Days\Day05\Day05.txt";
                var formatedTextLine = File.ReadAllText(path).Replace("\n", "&").Replace("\r", String.Empty);
                var txtLines = formatedTextLine.Split('&');

                foreach (var txtLine in txtLines)
                {
                    boardingPasses.Add(txtLine);
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e);
            }
            return boardingPasses;
        }

        public int GetSeatingRow(string boardingPass)
        {
            var startRange = 1;
            var endRange = 128;
            for (int i = 0; i < 7; i++)
            {
                if (boardingPass[i] == 'F')
                {
                    endRange = startRange + (endRange - startRange) / 2;
                }
                else if (boardingPass[i] == 'B')
                {
                    startRange += (endRange - startRange) / 2;
                }
            }
            return startRange;
        }

        public int GetSeatingColumn(string boardingPass)
        {
            var startRange = 1;
            var endRange = 8;
            for (int i = 7; i < 10; i++)
            {
                if (boardingPass[i] == 'L')
                {
                    endRange = startRange + (endRange - startRange) / 2;
                }
                else if (boardingPass[i] == 'R')
                {
                    startRange += (endRange - startRange) / 2;
                }
            }
            return startRange;
        }

        public int GetHigestSeatingId(List<string> boardingPasses)
        {
            var seatingIds = new List<int>();
            foreach (var boardingPass in boardingPasses)
            {
                seatingIds.Add(GetSeatingId(boardingPass));
            }
            return seatingIds.Max();
        }

        public int GetMissingSeatingId(List<string> boardingPasses)
        {
            var seatingIds = new List<int>();
            foreach (var boardingPass in boardingPasses)
            {
                seatingIds.Add(GetSeatingId(boardingPass));
            }
            seatingIds = seatingIds.OrderBy(v => v).ToList();

            for (int i = 1; i < seatingIds.Count()-1; i++)
            {
                if(seatingIds[i] - seatingIds[i-1] != 1 && seatingIds[i+1] - seatingIds[i] != 0 &&
                        seatingIds[i] != seatingIds[i-1] && seatingIds[i] != seatingIds[i+1])
                {
                    return seatingIds[i];
                }
            }
            return 0;
        }

        public int GetSeatingId(string boardingPass)
        {
            var seatingRow = GetSeatingRow(boardingPass);
            var seatingColumn = GetSeatingColumn(boardingPass);
            return seatingRow * 8 + seatingColumn;
        }
    }
}