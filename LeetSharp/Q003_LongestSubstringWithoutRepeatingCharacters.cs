using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Given a string, find the length of the longest substring without repeating characters. 
// For example, the longest substring without repeating letters for "abcabcbb" is "abc", which the length is 3. 
// For "bbbbb" the longest substring is "b", with the length of 1.

namespace LeetSharp
{
    [TestClass]
    public class Q003_LongestSubstringWithoutRepeatingCharacters
    {
        int LengthOfLongestSubstring(string s)
        {
            int maxLength = 0;

            int start = 0, end = 0;
            HashSet<char> set = new HashSet<char>();

            while (end < s.Length)
            {
                if (!set.Add(s[end]))
                {
                    while (start <= end && s[start] != s[end])
                    {
                        set.Remove(s[start]);
                        start++;
                    }
                    start++;
                }
                
                end++;
                maxLength = Math.Max(maxLength, end - start);
            }

            return maxLength;
        }

        public string SolveQuestion(string input)
        {
            return LengthOfLongestSubstring(input.Deserialize()).ToString();
        }

        [TestMethod]
        public void Q003_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q003_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
