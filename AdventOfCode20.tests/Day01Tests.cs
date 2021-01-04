using System;
using System.Collections.Generic;
using Xunit;

namespace AdventOfCode20.tests
{
    public class Day01Tests
    {
        private Day01 _day01;
        public Day01Tests()
        {
            _day01 = new Day01();
        }

        [Fact]
        public void Day1_part1()
        {
            var expenseReport = _day01.ReadFile();
            var values = _day01.GetTwoValuesThatEqualsSum(expenseReport, 2020);
            var result = _day01.Multiply(values);
            Assert.Equal(510, result);
        }

        [Fact]
        public void Day1_part2()
        {
            var expenseReport = _day01.ReadFile();
            var values = _day01.GetThreeValuesThatEqualsSum(expenseReport, 2020);
            var result = _day01.Multiply(values);
            Assert.Equal(510, result);
        }

        [Fact]
        public void Should_get_two_values_with_sum_2020()
        {
            var array = new List<int> { 1721, 979, 366, 299, 675, 1456 };
            
            var result = _day01.GetTwoValuesThatEqualsSum(array, 2020);

            Assert.Equal(1721, result[0]);
            Assert.Equal(299, result[1]);
        }

        [Fact]
        public void Should_get_three_values_with_sum_2020()
        {
            var array = new List<int> { 1721, 979, 366, 299, 675, 1456 };

            var result = _day01.GetThreeValuesThatEqualsSum(array, 2020);

            Assert.Equal(979, result[0]);
            Assert.Equal(366, result[1]);
            Assert.Equal(675, result[2]);
        }

        [Fact]
        public void Should_multiply_two_values_and_return_product()
        {
            var array = new List<int> { 1721, 979, 366, 299, 675, 1456 };

            var result = _day01.GetTwoValuesThatEqualsSum(array, 2020);
            var product = _day01.Multiply(result);

            Assert.Equal(514579, product);
        }

        [Fact]
        public void Should_multiply_three_values_and_return_product()
        {
            var array = new List<int> { 1721, 979, 366, 299, 675, 1456 };

            var result = _day01.GetThreeValuesThatEqualsSum(array, 2020);
            var product = _day01.Multiply(result);

            Assert.Equal(241861950, product);
        }
    }
}
