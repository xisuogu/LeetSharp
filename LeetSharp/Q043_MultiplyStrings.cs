using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given two numbers represented as strings, return multiplication of the numbers as a string.

// Note: The numbers can be arbitrarily large and are non-negative.

namespace LeetSharp
{
    [TestClass]
    public class Q043_MultiplyStrings
    {
        public string Multiply(string num1, string num2)
        {
            int[] res = new int[num1.Length + num2.Length];
            for (int i = num1.Length - 1; i >= 0; i--)
            {
                int carry = 0;
                for (int j = num2.Length - 1; j >= 0; j--)
                {
                    int index = num1.Length - 1 - i + num2.Length -1 - j;
                    res[index] += (num1[i] - '0') * (num2[j] - '0') + carry;
                    carry = res[index] / 10;
                    res[index] = res[index] % 10;
                }
                int carryIndex = num1.Length - 1 - i + num2.Length;
                while (carry > 0)
                {
                    res[carryIndex] += carry;
                    carry = res[carryIndex] / 10;
                    res[carryIndex] = res[carryIndex] % 10;
                }
            }
            string answer = String.Join("", res.Reverse()).TrimStart('0');
            return answer == String.Empty ? "0" : answer;
        }

        public string SolveQuestion(string input)
        {
            return "\"" + Multiply(input.GetToken(0).Deserialize(), input.GetToken(1).Deserialize()) + "\"";
        }

        [TestMethod]
        public void Q043_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q043_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
