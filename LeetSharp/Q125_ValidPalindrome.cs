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
            int start = 0, end = s.Length - 1;
            while (start < end)
            {
                while (start < end && !char.IsLetterOrDigit(s[start]))
                {
                    start++;
                }

                while (start < end && !char.IsLetterOrDigit(s[end]))
                {
                    end--;
                }

                if (start < end)
                {
                    if (char.ToLower(s[start]) != char.ToLower(s[end])) 
                        return false;

                    start++;
                    end--;
                }
            }

            return true; 
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
