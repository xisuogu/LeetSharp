using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given n pairs of parentheses, write a function to generate all combinations of well-formed parentheses.

// For example, given n = 3, a solution set is:

// "((()))", "(()())", "(())()", "()(())", "()()()"

namespace LeetSharp
{
    [TestClass]
    public class Q022_GenerateParentheses
    {
        public string[] GenerateParenthesis(int n)
        {
            List<string> results = new List<string>();
            string current = string.Empty;
            GenerateParenthesis(n, n, current, results);
            return results.ToArray();
        }

        public void GenerateParenthesis(int left, int right, string current, List<string> results)
        {
            if (left == 0 && right == 0)
            {
                results.Add(current);
                return;
            }

            if (left > 0)
            {
                GenerateParenthesis(left - 1, right, current + "(", results);

            }
            if (right > left)
            {
                GenerateParenthesis(left, right - 1, current + ")", results);
            }
        }

        public string SolveQuestion(string input)
        {
            return TestHelper.Serialize(GenerateParenthesis(input.ToInt()));
        }

        [TestMethod]
        public void Q022_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q022_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
