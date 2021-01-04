using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode20.tests
{
    public class Day03
    {
        public Day03()
        {
        }

        public List<string> ReadFile()
        {
            var coordinates = new List<string>();
            try
            {
                var path = @"C:\dev\repos\advent-of-code\AdventOfCode20\Days\Day03\Day03.txt";
                var formatedTextLine = File.ReadAllText(path).Replace("\n", "&").Replace("\r", String.Empty);
                var txtLines = formatedTextLine.Split('&');

                foreach (var txtLine in txtLines)
                {
                    coordinates.Add(txtLine);
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e);
            }
            return coordinates;
        }

        public bool CheckIfTreeOnPosition(string coordinates, int position)
        {
            var loopPosition = position % coordinates.Length;
            return coordinates[loopPosition] == '#';
        }

        public int CountNuberOfTrees(List<string> coordinates, int right, int down)
        {
            var position = right;
            var numberOfTrees = 0;
            for (int i = 0+down; i < coordinates.Count; i+=down)
            {
                if (CheckIfTreeOnPosition(coordinates[i], position))
                {
                    numberOfTrees++;
                }
                position += right;
            }
            return numberOfTrees;
        }
    }

    public class Coordinates
    {
        private int right;
        private int down;

        public Coordinates(int right, int down)
        {
            this.right = right;
            this.down = down;
        }

        public int Right
        {
            get { return right; }
            set { right = value; }
        }

        public int Down
        {
            get { return down; }
            set { down = value; }
        }
    }
}