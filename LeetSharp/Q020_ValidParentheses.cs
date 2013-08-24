using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given a string containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.

// The brackets must close in the correct order, "()" and "()[]{}" are all valid but "(]" and "([)]" are not.

namespace LeetSharp
{
    [TestClass]
    public class Q020_ValidParentheses
    {
        public bool IsLeft(char c)
        {
            return c == '(' || c == '[' || c == '{';
        }

        public bool IsMatch(char left, char right)
        {
            return (left == '(' && right == ')')
                || (left == '[' && right == ']')
                || (left == '{' && right == '}');
        }

        public bool IsValid(string s)
        {
            if (s.Length % 2 != 0)
                return false;

            Stack<char> stack = new Stack<char>();
            for (int i = 0; i < s.Length; i++)
            {
                if (IsLeft(s[i]))
                {
                    stack.Push(s[i]);
                }
                else
                {
                    if (stack.Count == 0)
                        return false;

                    if (IsMatch(stack.Peek(), s[i]))
                    {
                        stack.Pop();
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return stack.Count == 0;
        }

        public string SolveQuestion(string input)
        {
            return IsValid(input.Deserialize()).ToString().ToLower();
        }

        [TestMethod]
        public void Q020_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q020_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
