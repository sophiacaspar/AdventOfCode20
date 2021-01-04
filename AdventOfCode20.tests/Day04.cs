using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text.RegularExpressions;

namespace AdventOfCode20.tests
{
    public class Day04
    {
        public Day04()
        {
        }

        public List<string> ReadFile()
        {
            var passports = new List<string>();
            try
            {
                var path = @"C:\dev\repos\advent-of-code\AdventOfCode20\Days\Day04\Day04.txt";
                var formatedTextLine = File.ReadAllText(path).Replace("\r\n\r\n", "&").Replace("\r\n", " ");
                var txtLines = formatedTextLine.Split('&');

                foreach (var txtLine in txtLines)
                {
                    passports.Add(txtLine);
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e);
            }
            return passports;
        }

        public bool CheckIfPassportIsValid(Passport passport)
        {
            return BirthYearIsValid(passport.BirthYear) && IssueYearIsValid(passport.IssueYear) &&
                ExpirationYearIsValid(passport.ExpirationYear) &&
                HeightIsValid(passport.Height) && HairColorIsValid(passport.HairColor) && 
                EyeColorIsValid(passport.EyeColor)  && PassportIdIsValid(passport.PassportId);
        }

        public Passport CreatePassport(string passport)
        {
            return new Passport(GetBirthYear(passport), GetIssueYear(passport), GetExpirationYear(passport),
                GetHeight(passport), GetHairColor(passport), GetEyeColor(passport),
                GetPassportId(passport), GetCountryId(passport));
        }

        public int CountValidPassports(List<string> passports)
        {
            var validPassportCount = 0;
            foreach(var passport in passports)
            {
                if (CheckIfPassportIsValid(CreatePassport(passport)))
                {
                    validPassportCount++;
                }
            }
            return validPassportCount;
        }

        public int GetBirthYear(string passport)
        {
            foreach(var prop in passport.Split(' '))
            {
                if (prop.Contains("byr"))
                {
                    return int.Parse(prop.Split(':')[1]);
                }
            }
            return 0;
        }

        public int GetIssueYear(string passport)
        {
            foreach (var prop in passport.Split(' '))
            {
                if (prop.Contains("iyr"))
                {
                    return int.Parse(prop.Split(':')[1]);
                }
            }
            return 0;
        }

        public int GetExpirationYear(string passport)
        {
            foreach (var prop in passport.Split(' '))
            {
                if (prop.Contains("eyr"))
                {
                    return int.Parse(prop.Split(':')[1]);
                }
            }
            return 0;
        }

        public string GetHeight(string passport)
        {
            foreach (var prop in passport.Split(' '))
            {
                if (prop.Contains("hgt"))
                {
                    return prop.Split(':')[1];
                }
            }
            return null;
        }

        public string GetHairColor(string passport)
        {
            foreach (var prop in passport.Split(' '))
            {
                if (prop.Contains("hcl"))
                {
                    return prop.Split(':')[1];
                }
            }
            return null;
        }

        public string GetEyeColor(string passport)
        {
            foreach (var prop in passport.Split(' '))
            {
                if (prop.Contains("ecl"))
                {
                    return prop.Split(':')[1];
                }
            }
            return null;
        }

        public string GetPassportId(string passport)
        {
            foreach (var prop in passport.Split(' '))
            {
                if (prop.Contains("pid"))
                {
                    return prop.Split(':')[1];
                }
            }
            return null;
        }

        public int GetCountryId(string passport)
        {
            foreach (var prop in passport.Split(' '))
            {
                if (prop.Contains("cid"))
                {
                    return int.Parse(prop.Split(':')[1]);
                }
            }
            return 0;
        }

        public bool BirthYearIsValid(int birthYear)
        {
            return birthYear >= 1920 && birthYear <= 2002;
        }
        public bool IssueYearIsValid(int issueYear)
        {
            return issueYear >= 2010 && issueYear <= 2020;
        }
        public bool ExpirationYearIsValid(int expirationYear)
        {
            return expirationYear >= 2020 && expirationYear <= 2030;
        }
        public bool HeightIsValid(string height)
        {
            if (height.Contains("in"))
            {
                var h = height.Split('i');
                return int.TryParse(h[0], out int result) && result >= 59 && result <= 76;
            }
            else if (height.Contains("cm"))
            {
                var h = height.Split('c');
                return int.TryParse(h[0], out int result) && result >= 150 && result <= 193;
            }
            return false;
        }
        public bool HairColorIsValid(string haircolor)
        {
            if(haircolor != null && haircolor[0] == '#')
            {
                return Regex.IsMatch(haircolor.Substring(1), @"^[a-fA-F0-9]+$"); 
            }
            return false;
        }
        public bool EyeColorIsValid(string eyecolor)
        {
            return eyecolor != null && eyecolor == "amb" || eyecolor == "blu" ||
                eyecolor == "brn" || eyecolor == "gry" ||
                eyecolor == "grn" || eyecolor == "hzl" || eyecolor == "oth";
        }
        public bool PassportIdIsValid(string passportId)
        {
            return passportId != null &&  Regex.IsMatch(passportId, @"^[0-9]+$") && passportId.Length == 9;
        }
    }


    public class Passport
    {
        private int birthYear, issueYear, expirationYear, countryId;
        private string height, hairColor, eyeColor, passportId;
        

        public Passport(int birthYear, int issueYear, int expirationYear, 
            string height, string hairColor, string eyeColor, string passportId, int countryId)
        {
            this.birthYear = birthYear;
            this.issueYear = issueYear;
            this.expirationYear = expirationYear;
            this.height = height;
            this.hairColor = hairColor;
            this.eyeColor = eyeColor;
            this.passportId = passportId;
            this.countryId = countryId;
        }

        public int BirthYear
        {
            get { return birthYear; }
            set { birthYear = value; }
        }

        public int IssueYear
        {
            get { return issueYear; }
            set { issueYear = value; }
        }

        public int ExpirationYear
        {
            get { return expirationYear; }
            set { expirationYear = value; }
        }

        public string Height
        {
            get { return height; }
            set { height = value; }
        }

        public string HairColor
        {
            get { return hairColor; }
            set { hairColor = value; }
        }
        public string EyeColor
        {
            get { return eyeColor; }
            set { eyeColor = value; }
        }

        public string PassportId
        {
            get { return passportId; }
            set { passportId = value; }
        }
        public int CountryId
        {
            get { return countryId; }
            set { countryId = value; }
        }
    }
}