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
        public string MinWindow(string src, string target)
        {
            // if S[i, j] is answer, then S[i+1, j] and S[i, j-1] are both not answer
            if (src.Length < target.Length)
            {
                return "";
            }
            Dictionary<char, int> dic = new Dictionary<char, int>();
            for (int i = 0; i < target.Length; i++)
            {
                int existing = dic.ContainsKey(target[i]) ? dic[target[i]] : 0;
                dic[target[i]] = existing + 1;
            }
            int answerLength = int.MaxValue;
            int answerLeft = 0;
            int left = 0;
            int right = 0;
            while (right < src.Length)
            {
                if (dic.ContainsKey(src[right]))
                {
                    dic[src[right]] -= 1;
                    if (dic.Values.All(i => i <= 0)) // left <-> right covers all
                    {
                        // trim left
                        while (left <= right)
                        {
                            if (dic.ContainsKey(src[left]))
                            {
                                dic[src[left]] += 1;
                                if (dic[src[left]] == 1) // left <-> right can be a candidate answer
                                {
                                    if ((right - left + 1) < answerLength)
                                    {
                                        answerLeft = left;
                                        answerLength = right - left + 1;
                                    }
                                    left++; // make it invalide again, then move right forward again to detect
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
            {
                return "";
            }
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
