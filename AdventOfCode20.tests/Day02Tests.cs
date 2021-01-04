using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AdventOfCode20.tests
{
    public class Day02Tests
    {
        private Day02 _day02;

        public Day02Tests()
        {
            _day02 = new Day02();
        }

        [Fact]
        public void Day02_part1()
        {
            var passwordRows = _day02.ReadFile();
            var result = _day02.CountNumberOfValidPasswords(passwordRows);
            Assert.Equal(510, result);
        }

        [Fact]
        public void Day02_part2()
        {
            var passwordRows = _day02.ReadFile();
            var result = _day02.CountNumberOfValidPasswordPositions(passwordRows);
            Assert.Equal(510, result);
        }

        [Theory]
        [InlineData("1-3 a: abcde")]
        [InlineData("2-9 c: ccccccccc")]
        public void Should_get_valid_passwords(string password)
        {
            var result = _day02.CheckIfPasswordIsValid(password);
            Assert.True(result);
        }

        [Theory]
        [InlineData("1-3 b: cdefg")]
        public void Should_get_invalid_passwords(string password)
        {
            var result = _day02.CheckIfPasswordIsValid(password);
            Assert.False(result);
        }

        [Fact]
        public void Should_get_two_valid_passwords()
        {
            var passwords = new List<string> { "1-3 a: abcde", "1-3 b: cdefg", "2-9 c: ccccccccc" };
            var result = _day02.CountNumberOfValidPasswords(passwords);
            Assert.Equal(2, result);
        }

        [Theory]
        [InlineData("1-3 a: abcde")]
        public void Should_get_valid_password_position(string password)
        {
            var result = _day02.CheckIfPasswordPositionIsValid(password);
            Assert.True(result);
        }

        [Theory]
        //[InlineData("1-3 b: cdefg")]
        [InlineData("2-9 c: ccccccccc")]
        public void Should_get_invalid_password_position(string password)
        {
            var result = _day02.CheckIfPasswordPositionIsValid(password);
            Assert.False(result);
        }

        [Fact]
        public void Should_get_one_valid_password_position()
        {
            var passwords = new List<string> { "1-3 a: abcde", "1-3 b: cdefg", "2-9 c: ccccccccc" };
            var result = _day02.CountNumberOfValidPasswordPositions(passwords);
            Assert.Equal(1, result);
        }

    }
}
