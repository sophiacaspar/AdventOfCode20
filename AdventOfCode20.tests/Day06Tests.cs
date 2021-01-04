using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AdventOfCode20.tests
{
    public class Day06Tests
    {
        private Day06 _day06;

        public Day06Tests()
        {
            _day06 = new Day06();
        }

        [Fact]
        public void Day06_part1()
        {
            var yesAnswers = _day06.ReadFile();
            var result = _day06.GetSumOfYesAnswersAnyone(yesAnswers);
            Assert.Equal(7120, result);
        }

        [Fact]
        public void Day06_part2()
        {
            var yesAnswers = _day06.ReadFile();
            var result = _day06.GetSumOfYesAnswersEveryone(yesAnswers);
            Assert.Equal(3570, result);
        }

        [Fact]
        public void Should_get_three_yes_answers()
        {
            var yesAnswers = "abc";
            var result = _day06.CountUniqueYesAnswers(yesAnswers);
            Assert.Equal(3, result);
        }

        [Fact]
        public void Should_get_sum_yes_answer_anyone_count()
        {
            var yesAnswers = new List<string> { "abc", "abc", "abac", "aaaa", "b" };
            var result = _day06.GetSumOfYesAnswersAnyone(yesAnswers);
            Assert.Equal(11, result);
        }

        [Fact]
        public void Should_get_sum_yes_answer_everyone_count()
        {
            var yesAnswers = new List<string> { "abc", "a b c", "ab ac", "a a a a", "b" };
            var result = _day06.GetSumOfYesAnswersEveryone(yesAnswers);
            Assert.Equal(6, result);
        }
    }
}
