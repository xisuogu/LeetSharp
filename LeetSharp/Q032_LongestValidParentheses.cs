using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given a string containing just the characters '(' and ')', find the length of the longest valid (well-formed) 
// parentheses substring.

// For "(()", the longest valid parentheses substring is "()", which has length = 2.

// Another example is ")()())", where the longest valid parentheses substring is "()()", which has length = 4.

namespace LeetSharp
{
    [TestClass]
    public class Q032_LongestValidParentheses
    {
        public int LongestValidParentheses(string s)
        {
            int maxLength = 0;
            Stack<Tuple<char, int>> stack = new Stack<Tuple<char, int>>();
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ')')
                {
                    if (stack.Count != 0 && stack.Peek().Item1 == '(')
                    {
                        stack.Pop();
                        int start = (stack.Count == 0) ? -1 : stack.Peek().Item2;
                        maxLength = Math.Max(maxLength, i - start);
                    }
                    else
                    {
                        stack.Push(Tuple.Create(')', i));
                    }
                }
                else
                {
                    stack.Push(Tuple.Create('(', i));
                }
            }
            return maxLength;
        }

        public string SolveQuestion(string input)
        {
            return LongestValidParentheses(input.Deserialize()).ToString();
        }

        [TestMethod]
        public void Q032_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q032_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
