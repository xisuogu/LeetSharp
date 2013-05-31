using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Implement atoi to convert a string to an integer.

namespace LeetSharp
{
    [TestClass]
    public class Q008_StringtoInteger
    {
        public int Atoi(string str)
        {
            var chars = str.ToCharArray();
            bool inDigitState = false;
            bool neg = false;
            long answer = 0;
            foreach (var c in chars)
            {
                if (char.IsDigit(c))
                {
                    inDigitState = true;
                    answer = answer * 10 + int.Parse(c.ToString());
                    if (answer > int.MaxValue)
                    {
                        return neg ? int.MinValue : int.MaxValue;
                    }
                }
                else if (c == '+')
                {
                    if (inDigitState)
                    {
                        break;
                    }
                    else
                    {
                        inDigitState = true;
                    }
                }
                else if (c == '-')
                {
                    if (inDigitState)
                    {
                        break;
                    }
                    else
                    {
                        neg = true;
                        inDigitState = true;
                    }
                }
                else if (c == ' ')
                {
                    if (inDigitState)
                    {
                        break;
                    }
                }
                else // other char, all invalid
                {
                    break;
                }
            }
            return neg ? 0 - (int)answer : (int)answer;
        }

        public string SolveQuestion(string input)
        {
            return Atoi(input.Deserialize()).ToString();
        }

        [TestMethod]
        public void Q008_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q008_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
