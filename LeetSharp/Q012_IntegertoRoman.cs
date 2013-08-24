using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given an integer, convert it to a roman numeral.

// Input is guaranteed to be within the range from 1 to 3999.

namespace LeetSharp
{
    [TestClass]
    public class Q012_IntegertoRoman
    {
        private string GetRomanStringFromPattern(int digit, char one, char five, char ten)
        {
            if (digit == 0)
            {
                return string.Empty;
            }
            else if (digit <= 3)
            {
                return new string(one, digit);
            }
            else if (digit == 4)
            {
                return new string(new[] { one, five });
            }
            else if (digit == 5)
            {
                return new string(five, 1);
            }
            else if (digit <= 8)
            {
                return five.ToString() + new string(one, digit - 5);
            }
            else
            {
                return new string(new[] { one, ten });
            }
        }

        private string GetRomanStringFromPattern(int digit, int power)
        {
            if (power == 0)
            {
                return GetRomanStringFromPattern(digit, 'I', 'V', 'X');
            }
            else if (power == 1)
            {
                return GetRomanStringFromPattern(digit, 'X', 'L', 'C');
            }
            else if (power == 2)
            {
                return GetRomanStringFromPattern(digit, 'C', 'D', 'M');
            }
            else
            {
                return GetRomanStringFromPattern(digit, 'M', 'Z' /*invalid*/, 'Z' /*invalid*/);
            }
        }

        public string IntToRoman(int num)
        {
            int power = 3;
            string result = string.Empty;
            while (num >= 0 && power >= 0)
            {
                int digit = num / (int)Math.Pow(10, power);
                result += GetRomanStringFromPattern(digit, power);
                num %= (int)Math.Pow(10, power--);
            }
            return result;
        }

        public string SolveQuestion(string input)
        {
            return "\"" + IntToRoman(input.ToInt()) + "\"";
        }

        [TestMethod]
        public void Q012_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q012_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
