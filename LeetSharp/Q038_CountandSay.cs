using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// The count-and-say sequence is the sequence of integers beginning as follows:
// 1, 11, 21, 1211, 111221, ...

// 1 is read off as "one 1" or 11.
// 11 is read off as "two 1s" or 21.
// 21 is read off as "one 2, then one 1" or 1211.

// Given an integer n, generate the nth sequence.

// Note: The sequence of integers will be represented as a string.

namespace LeetSharp
{
    [TestClass]
    public class Q038_CountandSay
    {
        public string CountAndSay(int n)
        {
            string temp = "1";
            for (int i = 0; i < n - 1; i++)
            {
                temp = ConvertString(temp);
            }
            return temp;
        }

        private string ConvertString(string s)
        {
            int read = 0;
            StringBuilder sb = new StringBuilder();
            while (read < s.Length)
            {
                int readEnd = read;
                while (readEnd < s.Length - 1)
                {
                    if (s[readEnd + 1] != s[read])
                    {
                        break;
                    }
                    readEnd++;
                }
                sb.Append((readEnd - read + 1).ToString());
                sb.Append(s[read]);
                read = readEnd + 1;
            }
            return sb.ToString();
        }

        public string SolveQuestion(string input)
        {
            return "\"" + CountAndSay(input.ToInt()) + "\"";
        }

        [TestMethod]
        public void Q038_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q038_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
