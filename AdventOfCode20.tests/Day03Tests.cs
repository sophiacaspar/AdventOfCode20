using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AdventOfCode20.tests
{
    public class Day03Tests
    {
        private Day03 _day03;

        public Day03Tests()
        {
            _day03 = new Day03();
        }

        [Fact]
        public void Day03_part1()
        {
            var coordinates = _day03.ReadFile();
            var right = 3;
            var down = 1;
            var result = _day03.CountNuberOfTrees(coordinates, right, down);
            Assert.Equal(257, result);
        }

        [Fact]
        public void Day03_part2()
        {
            var coordinates = _day03.ReadFile();
   
            var steps = new List<Coordinates>();
            steps.Add(new Coordinates(1, 1));
            steps.Add(new Coordinates(3, 1));
            steps.Add(new Coordinates(5, 1));
            steps.Add(new Coordinates(7, 1));
            steps.Add(new Coordinates(1, 2));

            var product = 1;
            foreach (var step in steps)
            {
                product *= _day03.CountNuberOfTrees(coordinates, step.Right, step.Down);
            }
            Assert.Equal(1744787392, product);
        }

        [Fact]
        public void Should_find_tree()
        {
            var coordinates = ".#....#..#..#....#..#..#....#..#..#....#..#..#....#..#..#....#..#.";
            var position = 6;
            var result = _day03.CheckIfTreeOnPosition(coordinates, position);
            Assert.True(result);
        }

        [Fact]
        public void Should_find_tree_using_circular_lookup()
        {
            var coordinates = ".#..#...#.#";
            var position = 30;
            var result = _day03.CheckIfTreeOnPosition(coordinates, position);
            Assert.True(result);
        }

        [Fact]
        public void Should_not_find_tree()
        {
            var coordinates = "#...#...#..#...#...#..#...#...#..#...#...#..#...#...#..#...#...#..";
            var position = 3;
            var result = _day03.CheckIfTreeOnPosition(coordinates, position);
            Assert.False(result);
        }

        [Fact]
        public void Should_find_one_tree()
        {
            var coordinates = new List<string> { 
                "..##.........##.........##.........##.........##.........##.......", 
                "#...#...#..#...#...#..#...#...#..#...#...#..#...#...#..#...#...#..", 
                ".#....#..#..#....#..#..#....#..#..#....#..#..#....#..#..#....#..#." 
            };
            var right = 3;
            var down = 1;
            var result = _day03.CountNuberOfTrees(coordinates, right, down);
            Assert.Equal(1, result);  
        }

        [Fact]
        public void Should_find_seven_trees()
        {
            var coordinates = new List<string> {
                "..##.........##.........##.........##.........##.........##.......",
                "#...#...#..#...#...#..#...#...#..#...#...#..#...#...#..#...#...#..",
                ".#....#..#..#....#..#..#....#..#..#....#..#..#....#..#..#....#..#.",
                "..#.#...#.#..#.#...#.#..#.#...#.#..#.#...#.#..#.#...#.#..#.#...#.#",
                ".#...##..#..#...##..#..#...##..#..#...##..#..#...##..#..#...##..#.",
                "..#.##.......#.##.......#.##.......#.##.......#.##.......#.##.....",
                ".#.#.#....#.#.#.#....#.#.#.#....#.#.#.#....#.#.#.#....#.#.#.#....#",
                ".#........#.#........#.#........#.#........#.#........#.#........#",
                "#.##...#...#.##...#...#.##...#...#.##...#...#.##...#...#.##...#...",
                "#...##....##...##....##...##....##...##....##...##....##...##....#",
                ".#..#...#.#.#..#...#.#.#..#...#.#.#..#...#.#.#..#...#.#.#..#...#.#"
            };
            var right = 3;
            var down = 1;
            var result = _day03.CountNuberOfTrees(coordinates, right, down);
            Assert.Equal(7, result);
        }

        [Fact]
        public void Should_multiply_number_of_trees_and_get_336()
        {
            var coordinates = new List<string> {
                "..##.......",
                "#...#...#..",
                ".#....#..#.",
                "..#.#...#.#",
                ".#...##..#.",
                "..#.##.....",
                ".#.#.#....#",
                ".#........#",
                "#.##...#...",
                "#...##....#",
                ".#..#...#.#"
            };
            var steps = new List<Coordinates>();
            steps.Add(new Coordinates(1, 1));
            steps.Add(new Coordinates(3, 1));
            steps.Add(new Coordinates(5, 1));
            steps.Add(new Coordinates(7, 1));
            steps.Add(new Coordinates(1, 2));

            var product = 1;
            foreach (var step in steps)
            {
                product *= _day03.CountNuberOfTrees(coordinates, step.Right, step.Down);
            }
            Assert.Equal(336, product);
        }
    }


}
