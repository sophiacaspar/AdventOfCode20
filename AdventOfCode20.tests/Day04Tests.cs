using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AdventOfCode20.tests
{
    public class Day04Tests
    {
        private Day04 _day04;

        public Day04Tests()
        {
            _day04 = new Day04();
        }

        [Fact]
        public void Day04_part1()
        {
            var passports = _day04.ReadFile();
            var result = _day04.CountValidPassports(passports);
            Assert.Equal(250, result);
        }

        [Fact]
        public void Day04_part2()
        {
            var passports = _day04.ReadFile();
            var result = _day04.CountValidPassports(passports);
            Assert.Equal(2, result);
        }

        [Fact]
        public void Should_get_birth_year()
        {
            var passport = "ecl:gry pid:860033327 eyr:2020 hcl:#fffffd byr:1937 iyr:2017 cid:147 hgt:183cm";
            var result = _day04.GetBirthYear(passport);
            Assert.Equal(1937, result);
        }

        [Fact]
        public void Should_get_issue_year()
        {
            var passport = "ecl:gry pid:860033327 eyr:2020 hcl:#fffffd byr:1937 iyr:2017 cid:147 hgt:183cm";
            var result = _day04.GetIssueYear(passport);
            Assert.Equal(2017, result);
        }

        [Fact]
        public void Should_get_expiration_year()
        {
            var passport = "ecl:gry pid:860033327 eyr:2020 hcl:#fffffd byr:1937 iyr:2017 cid:147 hgt:183cm";
            var result = _day04.GetExpirationYear(passport);
            Assert.Equal(2020, result);
        }

        [Fact]
        public void Should_get_height()
        {
            var passport = "ecl:gry pid:860033327 eyr:2020 hcl:#fffffd byr:1937 iyr:2017 cid:147 hgt:183cm";
            var result = _day04.GetHeight(passport);
            Assert.Equal("183cm", result);
        }

        [Fact]
        public void Should_get_hair_color()
        {
            var passport = "ecl:gry pid:860033327 eyr:2020 hcl:#fffffd byr:1937 iyr:2017 cid:147 hgt:183cm";
            var result = _day04.GetHairColor(passport);
            Assert.Equal("#fffffd", result);
        }

        [Fact]
        public void Should_get_eye_color()
        {
            var passport = "ecl:gry pid:860033327 eyr:2020 hcl:#fffffd byr:1937 iyr:2017 cid:147 hgt:183cm";
            var result = _day04.GetEyeColor(passport);
            Assert.Equal("gry", result);
        }

        [Fact]
        public void Should_get_password_id()
        {
            var passport = "ecl:gry pid:860033327 eyr:2020 hcl:#fffffd byr:1937 iyr:2017 cid:147 hgt:183cm";
            var result = _day04.GetPassportId(passport);
            Assert.Equal("860033327", result);
        }

        [Fact]
        public void Should_get_country_id()
        {
            var passport = "ecl:gry pid:860033327 eyr:2020 hcl:#fffffd byr:1937 iyr:2017 cid:147 hgt:183cm";
            var result = _day04.GetCountryId(passport);
            Assert.Equal(147, result);
        }

        [Fact]
        public void Should_create_new_passport()
        {
            var passport = "ecl:gry pid:860033327 eyr:2020 hcl:#fffffd byr:1937 iyr:2017 cid:147 hgt:183cm";
            var result = _day04.CreatePassport(passport);
            Assert.Equal(1937, result.BirthYear);
            Assert.Equal(2017, result.IssueYear);
            Assert.Equal(2020, result.ExpirationYear);
            Assert.Equal("183cm", result.Height);
            Assert.Equal("#fffffd", result.HairColor);
            Assert.Equal("gry", result.EyeColor);
            Assert.Equal("860033327", result.PassportId);
            Assert.Equal(147, result.CountryId);
        }

        [Fact]
        public void Passport_should_be_valid()
        {
            var input = "ecl:gry pid:860033327 eyr:2020 hcl:#fffffd byr:1937 iyr:2017 cid:147 hgt:183cm";
            var passport = _day04.CreatePassport(input);
            var result = _day04.CheckIfPassportIsValid(passport);
            Assert.True(result);
        }

        [Fact]
        public void Should_get_two_valid_passports()
        {
            var passports = new List<string> { 
                "ecl:gry pid:860033327 eyr:2020 hcl:#fffffd byr:1937 iyr:2017 cid:147 hgt:183cm",
            "iyr:2013 ecl:amb cid:350 eyr:2023 pid:028048884 hcl:#cfa07d byr:1929",
            "hcl:#ae17e1 iyr:2013 eyr:2024 ecl: brn pid:760753108 byr:1931 hgt:179cm",
            "hcl:#cfa07d eyr:2025 pid:166559648 iyr:2011 ecl:brn hgt:59in"};
            var result = _day04.CountValidPassports(passports);
            Assert.Equal(2, result);
        }
    }
}
