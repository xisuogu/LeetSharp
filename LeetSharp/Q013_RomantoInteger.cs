using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given a roman numeral, convert it to an integer.

// Input is guaranteed to be within the range from 1 to 3999.

namespace LeetSharp
{
    [TestClass]
    public class Q013_RomantoInteger
    {
        int RomanToInt(string s)
        {
            int result = 0, i = 0;

            RomanToInt(s, ref i, ref result, 3);
            RomanToInt(s, ref i, ref result, 2);
            RomanToInt(s, ref i, ref result, 1);
            RomanToInt(s, ref i, ref result, 0);

            return result;
        }

        private Dictionary<int, char[]> mapping = new Dictionary<int, char[]>()
        {
            { 0, new char[] { 'I', 'V', 'X' } }, 
            { 1, new char[] { 'X', 'L', 'C' } }, 
            { 2, new char[] { 'C', 'D', 'M' } }, 
            { 3, new char[] { 'M', 'Z', 'Z' } }, 
        };

        void RomanToInt(string s, ref int i, ref int result, int power)
        {
            int mul = (int)Math.Pow(10, power);

            char[] c = mapping[power];
            char one = c[0], five = c[1], ten = c[2];

            while (i < s.Length)
            {
                if (s[i] == one)
                {
                    if (i < s.Length - 1 &&
                        (s[i + 1] == ten || s[i + 1] == five))
                    {
                        result -= mul;
                    }
                    else
                    {
                        result += mul;
                    }
                }
                else if (s[i] == five)
                {
                    result += 5 * mul;
                }
                else if (s[i] == ten)
                {
                    result += 10 * mul;
                }
                else break;

                i++;
            }

            /*
             * 
            if (i < s.Length && s[i] == one)
            {
                if (i < s.Length - 1 && s[i + 1] == ten)
                {
                    result += 9 * mul;
                    i += 2;
                }
                else if (i < s.Length - 1 && s[i + 1] == five)
                {
                    result += 4 * mul;
                    i += 2;
                }
                while (i < s.Length && s[i] == one)
                {
                    result += mul;
                    i++;
                }
            }

            if (i < s.Length && s[i] == five)
            {
                result += 5 * mul;
                i++;

                while (i < s.Length && s[i] == one)
                {
                    result += mul;
                    i++;
                }
            }
             */
        }

        public string SolveQuestion(string input)
        {
            return RomanToInt(input.Deserialize()).ToString();
        }

        [TestMethod]
        public void Q013_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q013_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
