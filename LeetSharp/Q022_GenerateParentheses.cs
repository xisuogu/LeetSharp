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
            List<string> answer = new List<string>();
            GenerateParenthesisRecursive(n, n, answer, "");
            answer.Sort();
            return answer.ToArray();
        }

        private void GenerateParenthesisRecursive(int leftRemaining, int rightRemaining, List<string> answer, string current)
        {
            if (leftRemaining == 0 && rightRemaining == 0)
            {
                answer.Add(current);
            }
            if (leftRemaining < rightRemaining)
            {
                GenerateParenthesisRecursive(leftRemaining, rightRemaining - 1, answer, current + ")");
            }
            if (leftRemaining > 0)
            {
                GenerateParenthesisRecursive(leftRemaining - 1, rightRemaining, answer, current + "(");
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
