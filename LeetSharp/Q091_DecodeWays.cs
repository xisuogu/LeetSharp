using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// A message containing letters from A-Z is being encoded to numbers using the following mapping:

// 'A' -> 1
// 'B' -> 2
// ...
// 'Z' -> 26
// Given an encoded message containing digits, determine the total number of ways to decode it.

// For example,
// Given encoded message "12", it could be decoded as "AB" (1 2) or "L" (12).

// The number of ways decoding "12" is 2.

namespace LeetSharp
{
    [TestClass]
    public class Q091_DecodeWays
    {
        public int NumDecodings(string s)
        {
            if (String.IsNullOrWhiteSpace(s))
            {
                return 0;
            }

            int[] answers = new int[s.Length + 1];
            answers[s.Length] = 1;
            answers[s.Length -1] = s[s.Length -1] == '0' ? 0:1;
            for (int i = s.Length - 2; i >= 0; i--)
            {
                if (s[i + 1] == '0')
                {
                    if (s[i] != '1' && s[i] != '2')
                    {
                        return 0; // invalid
                    }
                    answers[i] = answers[i + 2]; // take current and next, 10 or 20
                }
                else
                {
                    if (s[i] == '1')
                    {
                        answers[i] = answers[i + 1] + answers[i + 2];
                    }
                    else if (s[i] == '2')
                    {
                        if (s[i + 1] == '7' || s[i + 1] == '8' || s[i + 1] == '9')
                        {
                            answers[i] = answers[i + 1];
                        }
                        else
                        {
                            answers[i] = answers[i + 1] + answers[i + 2];
                        }
                    }
                    else if (s[i] == '0')
                    {
                        answers[i] = 0;
                    }
                    else
                    {
                        answers[i] = answers[i + 1];
                    }
                }
            }
            return answers[0];
        }

        public string SolveQuestion(string input)
        {
            return NumDecodings(input.Deserialize()).ToString();
        }

        [TestMethod]
        public void Q091_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q091_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
