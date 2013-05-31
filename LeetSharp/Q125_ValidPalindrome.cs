using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given a string, determine if it is a palindrome, considering only alphanumeric characters and ignoring cases.

// For example,
// "A man, a plan, a canal: Panama" is a palindrome.
// "race a car" is not a palindrome.

// Note:
// Have you consider that the string might be empty? This is a good question to ask during an interview.

// For the purpose of this problem, we define empty string as valid palindrome.

namespace LeetSharp
{
    [TestClass]
    public class Q125_ValidPalindrome
    {
        public bool IsPalindrome(string s)
        {
            if (s.Length <= 1)
            {
                return true;
            }
            int left = 0;
            int right = s.Length - 1;
            while (left < right)
            {
                while (left <= s.Length - 1 && !char.IsLetterOrDigit(s[left]))
                {
                    left++;
                }
                while (right >= 0 && !char.IsLetterOrDigit(s[right]))
                {
                    right--;
                }
                if (left <= s.Length - 1 && right >= 0)
                {
                    if (char.ToLower(s[left]) == char.ToLower(s[right]))
                    {
                        left++;
                        right--;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return left >= right;
        }

        public string SolveQuestion(string input)
        {
            return IsPalindrome(input.Deserialize()).ToString().ToLower();
        }

        [TestMethod]
        public void Q125_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q125_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
