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
        public string IntToRoman(int num)
        {
            // thousands -> hundreds -> tens -> ones
            int thousands = num / 1000;
            int hundreds = (num / 100) % 10;
            int tens = (num / 10) % 10;
            int ones = num % 10;
            StringBuilder sb = new StringBuilder();
            if (thousands > 0)
            {
                sb.Append(new string('M', thousands));
            }
            if (hundreds > 0)
            {
                sb.Append(GetRomanPart(hundreds, 'C', 'D', 'M'));
            }
            if (tens > 0)
            {
                sb.Append(GetRomanPart(tens, 'X', 'L', 'C'));
            }
            if (ones > 0)
            {
                sb.Append(GetRomanPart(ones, 'I', 'V', 'X'));
            }
            return sb.ToString();
        }

        string GetRomanPart(int number, char pre, char mid, char post)
        {
            // number = 1-9
            if (number <= 3)
            {
                return new string(pre, number);
            }
            else if (number == 4)
            {
                return new string(new[] { pre, mid });
            }
            else if (number == 5)
            {
                return mid.ToString();
            }
            else if (number <= 8)
            {
                return mid.ToString() + new string(pre, number - 5);
            }
            else
            {
                return new string(new[] { pre, post });
            }
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
