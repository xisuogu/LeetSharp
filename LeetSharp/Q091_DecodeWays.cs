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
            if (string.IsNullOrEmpty(s))
                return 0;

            int[] answer = new int[s.Length + 1];
            answer[s.Length] = 1;
            answer[s.Length - 1] = s[s.Length - 1] == '0' ? 0 : 1;

            for (int i = s.Length - 2; i >= 0; i--)
            {
                if (s[i + 1] == '0')
                {
                    if (s[i] == '1' || s[i] == '2')
                    {
                        answer[i] = answer[i + 2];
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    if (s[i] == '0')
                    {
                        answer[i] = 0;
                    }
                    else if (s[i] == '1')
                    {
                        answer[i] = answer[i + 1] + answer[i + 2];
                    }
                    else if (s[i] == '2')
                    {
                        if (s[i + 1] == '7' || s[i + 1] == '8' || s[i + 1] == '9')
                        {
                            answer[i] = answer[i + 1];
                        }
                        else
                        {
                            answer[i] = answer[i + 1] + answer[i + 2];
                        }
                    }
                    else
                    {
                        answer[i] = answer[i + 1];
                    }
                }
            }
            return answer[0];
        }

        /*
        private bool IsValid(string s)
        {
            int number = -1;
            bool flag = int.TryParse(s, out number);

            if (!flag)
                return false;

            if (s.Length == 1)
                return number >= 1 && number <= 9;
            if (s.Length == 2)
                return number >= 10 && number <= 26;

            return false;
        }

        public int NumDecodings(string s)
        {
            if (string.IsNullOrEmpty(s))
                return 0;

            Dictionary<string, int> cache = new Dictionary<string, int>();
            return NumDecodings(s, cache);
        }

        private int NumDecodings(string s, Dictionary<string, int> cache)
        {
            if (s == string.Empty)
                return 1;

            if (cache.ContainsKey(s))
                return cache[s];

            int result = 0;
            if (IsValid(s.Substring(0, 1)))
            {
                result += NumDecodings(s.Substring(1), cache);
            }
            if (s.Length > 1 && IsValid(s.Substring(0, 2)))
            {
                result += NumDecodings(s.Substring(2), cache);
            }
            cache[s] = result;
            return result;   
        }
         */

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
