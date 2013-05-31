using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// '?' Matches any single character.
// '*' Matches any sequence of characters (including the empty sequence).

// The matching should cover the entire input string (not partial).

// The function prototype should be:
// bool isMatch(const char *s, const char *p)

// Some examples:
// isMatch("aa","a") ? false
// isMatch("aa","aa") ? true
// isMatch("aaa","aa") ? false
// isMatch("aa", "*") ? true
// isMatch("aa", "a*") ? true
// isMatch("ab", "?*") ? true
// isMatch("aab", "c*a*b") ? false

namespace LeetSharp
{
    [TestClass]
    public class Q044_WildcardMatching
    {
        // recursive does not work, will stackoverflow or timeout
        public bool IsMatch(string input, string pattern)
        {
            return IsMatch(input.ToCharArray(), pattern.ToCharArray());
        }

        // non-recursive way, tricky enough, to recite!
        private bool IsMatch(char[] input, char[] pattern)
        {
            int inputIndex = 0;
            int patternIndex = 0;
            int starDetectionInputIndex = -1;
            int starDetectionPatternIndex = -1;
            while (inputIndex < input.Length)
            {
                if (patternIndex >= pattern.Length) // used all the patterns, still have input
                {
                    if (starDetectionInputIndex >= 0)
                    {
                        inputIndex = ++starDetectionInputIndex;
                        patternIndex = starDetectionPatternIndex;
                    }
                    else
                    {
                        return false; // no star beforehand, must be mismatch
                    }
                }

                char currentPattern = pattern[patternIndex];
                if (currentPattern == '?' || currentPattern == input[inputIndex])
                {
                    inputIndex++;
                    patternIndex++;
                }
                else if (currentPattern == '*')
                {
                    starDetectionInputIndex = inputIndex;
                    while (++patternIndex < pattern.Length)
                    {
                        if (pattern[patternIndex] != '*')
                        {
                            break;
                        }
                    }
                    if (patternIndex == pattern.Length)
                    {
                        return true; // current -> end, all *, match
                    }
                    starDetectionPatternIndex = patternIndex;
                }
                else // current position does not match, try from starDetectionInputIndex + 1 and starDetectionPatternIndex again
                {
                    if (starDetectionInputIndex >= 0)
                    {
                        inputIndex = ++starDetectionInputIndex;
                        patternIndex = starDetectionPatternIndex;
                    }
                    else
                    {
                        return false; // no star beforehand, must be mismatch
                    }
                }
            }
            return !pattern.Skip(patternIndex).Any(c => c != '*'); // remaining pattern must all be *
        }

        public string SolveQuestion(string input)
        {
            return IsMatch(input.GetToken(0).Deserialize(), input.GetToken(1).Deserialize()).ToString().ToLower();
        }

        [TestMethod]
        public void Q044_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q044_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
