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
        public string CountAndSay_Recursive(string n)
        {
            string s = string.Empty;
            int currentNum = n[0] - '0', currentCnt = 0;
            foreach (char c in n)
            {
                int temp = c - '0';
                if (currentNum != temp)
                {
                    s += currentCnt.ToString() + currentNum.ToString();
                    currentNum = temp;
                    currentCnt = 1;
                }
                else
                {
                    currentCnt++;
                }
            }
            s += currentCnt.ToString() + currentNum.ToString();
            return s;
        }

        public string CountAndSay(int n)
        {
            string current = "1";
            for (int i = 1; i < n; i++)
            {
                current = CountAndSay_Recursive(current);
            }
            return current;
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
