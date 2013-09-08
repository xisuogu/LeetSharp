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
            int[] result = new int[num1.Length + num2.Length];
            for (int i = num1.Length - 1; i >= 0; i--)
            {
                int carry = 0;
                for (int j = num2.Length - 1; j >= 0; j--)
                {
                    int resIndex = i + j + 1; // num1.Length - 1 - i + num2.Length - 1 - j;
                    int temp = result[resIndex] + (num1[i] - '0') * (num2[j] - '0') + carry;
                    result[resIndex] = temp % 10;
                    carry = temp / 10;
                }
                if (carry > 0)
                {
                    result[i] += carry; // carryIndex : num1.Length - 1 - i + num2.Length;
                }
            }

            string answer = string.Join("", result).TrimStart('0');
            return (answer == string.Empty) ? "0" : answer;
        }

        #region Version1
        private string Add(string num1, string num2)
        {
            if (num2 == string.Empty)
                return num1;

            char[] result = new char[Math.Max(num1.Length, num2.Length) + 1];
            for (int c = 0; c < result.Length; c++)
                result[c] = '0';

            int carry = 0;
            int i = num1.Length - 1, j = num2.Length - 1;
            int index = result.Length - 1;
            while (i >= 0 || j >= 0 || carry > 0)
            {
                int temp = carry;
                if (i >= 0)
                    temp += num1[i--] - '0';
                if (j >= 0)
                    temp += num2[j--] - '0';

                result[index--] = (char)(temp % 10 + '0');
                carry = temp / 10;
            }
            return new string(result);
        }

        private string Multiply(string num1, int num2)
        {
            char[] result = new char[num1.Length + 1];
            for (int c = 0; c < result.Length; c++)
                result[c] = '0';

            int carry = 0;
            int index = result.Length - 1, i = num1.Length - 1;
            while (i >= 0 || carry > 0)
            {
                int temp = carry;
                if (i >= 0)
                    temp += (num1[i--] - '0') * num2;

                result[index--] = (char)(temp % 10 + '0');
                carry = temp / 10;
            }
            return new string(result);
        }

        public string Multiply2(string num1, string num2)
        {
            string result = string.Empty;

            for (int j = num2.Length - 1; j >= 0; j--)
            {
                string temp = Multiply(num1, num2[j] - '0');
                temp += new string('0', num2.Length - 1 - j);
                result = Add(temp, result);
            }

            int startIndex = 0;
            while (startIndex < result.Length - 1 && result[startIndex] == '0')
                startIndex++;
            return result.Substring(startIndex);
        }
        #endregion

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
