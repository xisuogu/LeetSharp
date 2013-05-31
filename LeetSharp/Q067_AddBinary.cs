using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given two binary strings, return their sum (also a binary string).

// For example,
// a = "11"
// b = "1"
// Return "100".

namespace LeetSharp
{
    [TestClass]
    public class Q067_AddBinary
    {
        public string AddBinary(string a, string b)
        {
            int newLength = Math.Max(a.Length, b.Length) + 1;
            int[] result = new int[newLength];
            int index = 0;
            for (int i = a.Length - 1; i >= 0; i--)
            {
                if (a[i] == '1')
                {
                    result[index] = 1;
                }
                index++;
            }
            index = 0;
            for (int j = b.Length - 1; j >= 0; j--)
            {
                if (b[j] == '1') // add b[j] to res[index]
                {
                    int carry = 1;
                    int tmpIndex = index;
                    while (carry > 0)
                    {
                        if (result[tmpIndex] == 0)
                        {
                            carry = 0;
                            result[tmpIndex] = 1;
                        }
                        else
                        {
                            result[tmpIndex] = 0;
                        }
                        tmpIndex++;
                    }
                }
                index++;
            }
            string answer = String.Join("", result.Reverse()).TrimStart('0');
            answer = answer.Length == 0 ? "0" : answer;
            return answer;
        }

        public string SolveQuestion(string input)
        {
            return "\"" + AddBinary(input.GetToken(0).Deserialize(), input.GetToken(1).Deserialize()) + "\"";
        }

        [TestMethod]
        public void Q067_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q067_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
