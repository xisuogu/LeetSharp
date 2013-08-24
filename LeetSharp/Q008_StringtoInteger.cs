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
            long result = 0;
            int index = 0;
            bool negative = false;
            bool expectDigit = false;

            while (index < str.Length)
            {
                if (str[index] == ' ')
                {
                    if (expectDigit)
                    {
                        break;
                    }

                    index++;
                    continue;
                }
                else if (str[index] == '-' || str[index] == '+')
                {
                    if (expectDigit)
                    {
                        return 0;
                    }

                    expectDigit = true;

                    if (str[index] == '-')
                    {
                        negative = true;
                    }
                    index++;
                }
                else if (str[index] < '0' || str[index] > '9')
                {
                    break;
                }
                else
                {
                    expectDigit = true;

                    long temp = result * 10 + (str[index++] - '0');
                    if (temp > int.MaxValue)
                    {
                        return negative ? int.MinValue : int.MaxValue;
                    }
                    result = temp;
                }
            }

            return negative ? -1 * (int)result : (int)result;
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
