using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AdventOfCode20.tests
{
    public class Day05Tests
    {
        private Day05 _day05;

        public Day05Tests()
        {
            _day05 = new Day05();
        }

        [Fact]
        public void Day05_part1()
        {
            var boardingPasses = _day05.ReadFile();
            var highest = _day05.GetHigestSeatingId(boardingPasses);
            Assert.Equal(892, highest);
        }

        [Fact]
        public void Day05_part2()
        {
            var boardingPasses = _day05.ReadFile();
            var missingSeatId = _day05.GetMissingSeatingId(boardingPasses);
            Assert.Equal(625, missingSeatId);
        }

        [Theory]
        [InlineData("FBFBBFFRLR", 44)]
        [InlineData("BFFFBBFRRR", 70)]
        [InlineData("FFFBBBFRRR", 14)]
        [InlineData("BBFFBBFRLL", 102)]
        public void Should_find_row(string boardingPass, int expectedRow)
        {
            var result = _day05.GetSeatingRow(boardingPass);
            Assert.Equal(expectedRow, result);
        }

        [Theory]
        [InlineData("FBFBBFFRLR", 5)]
        [InlineData("BFFFBBFRRR", 7)]
        [InlineData("FFFBBBFRRR", 7)]
        [InlineData("BBFFBBFRLL", 4)]
        public void Should_find_column(string boardingPass, int expectedColumn)
        {
            var result = _day05.GetSeatingColumn(boardingPass);
            Assert.Equal(expectedColumn, result);
        }

        [Theory]
        [InlineData("FBFBBFFRLR", 357)]
        [InlineData("BFFFBBFRRR", 567)]
        [InlineData("FFFBBBFRRR", 119)]
        [InlineData("BBFFBBFRLL", 820)]
        public void Should_find_seat_id(string boardingPass, int expectedSeatId)
        {
            var result = _day05.GetSeatingId(boardingPass);
            Assert.Equal(expectedSeatId, result);
        }

        [Fact]
        public void Should_find_highest_seat_id()
        {
            var boardingPasses = new List<string> {
                "FBFBBFFRLR", "BFFFBBFRRR", "FFFBBBFRRR", "BBFFBBFRLL"
            };
            var result = _day05.GetHigestSeatingId(boardingPasses);
            Assert.Equal(820, result);
        }
    }
}
