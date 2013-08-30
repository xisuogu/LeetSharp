using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given a string S and a string T, find the minimum window in S which will contain all the characters in T in complexity O(n).

// For example,
// S = "ADOBECODEBANC"
// T = "ABC"

// Minimum window is "BANC".

// Note:
// If there is no such window in S that covers all characters in T, return the emtpy string "".
// If there are multiple such windows, you are guaranteed that there will always be only one unique minimum window in S.

namespace LeetSharp
{
    [TestClass]
    public class Q076_MinimumWindowSubstring
    {
        // http://leetcode.com/2010/11/finding-minimum-window-in-s-which.html

        public string MinWindow(string src, string target)
        {
            if (src.Length < target.Length)
                return "";

            Dictionary<char, int> mapping = new Dictionary<char, int>();
            foreach (char c in target)
                mapping[c] = mapping.ContainsKey(c) ? mapping[c] + 1 : 1;

            int left = 0, right = 0;
            int answerLeft = 0, answerLength = int.MaxValue;
            while (right < src.Length)
            {
                if (mapping.ContainsKey(src[right]))
                {
                    mapping[src[right]]--;
                    if (mapping.All(s => s.Value <= 0))
                    {
                        while (left <= right)
                        {
                            if (mapping.ContainsKey(src[left]))
                            {
                                mapping[src[left]]++;
                                if (mapping[src[left]] == 1) // left <-> right can be a candidate answer
                                {
                                    if (right - left + 1 < answerLength)
                                    {
                                        answerLeft = left;
                                        answerLength = right - left + 1;
                                    }
                                    left++; // make it invalid again 
                                    break;
                                }
                            }
                            left++;
                        }
                    }
                }
                right++;
            }

            if (answerLength == int.MaxValue)
                return "";

            return src.Substring(answerLeft, answerLength);
        }

        public string SolveQuestion(string input)
        {
            return "\"" + MinWindow(input.GetToken(0).Deserialize(), input.GetToken(1).Deserialize()) + "\"";
        }

        [TestMethod]
        public void Q076_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q076_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
