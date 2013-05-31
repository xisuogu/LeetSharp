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
            if (string.IsNullOrWhiteSpace(s))
            {
                return 0;
            }
            HashSet<char> charSet = new HashSet<char>();
            int answer = 1;
            var charArr = s.ToCharArray();
            charSet.Add(charArr[0]);
            int left = 0; int right = 1;
            while (right < s.Length)
            {
                if (charSet.Add(charArr[right])) // new char
                {
                    int newAnswer = right - left + 1;
                    answer = newAnswer > answer ? newAnswer : answer;
                }
                else
                {
                    while (left < right && charArr[left] != charArr[right])
                    {
                        charSet.Remove(charArr[left]);
                        left++;
                    }
                    if (left < right)
                    {
                        left++;
                    }
                }
                right++;
            }
            return answer;
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
