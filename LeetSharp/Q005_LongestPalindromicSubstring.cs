using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Given a string S, find the longest palindromic substring in S. 
// You may assume that the maximum length of S is 1000, and there exists one unique longest palindromic substring.

namespace LeetSharp
{
    [TestClass]
    public class Q005_LongestPalindromicSubstring
    {
        string LongestPalindrome(string input)
        {
            int retStart = 0, retEnd = 0;

            bool[,] matrix = new bool[input.Length, input.Length];
            
            for (int start = input.Length - 1; start >= 0; start--)
            {
                for (int end = start; end < input.Length; end++)
                {
                    if (input[start] == input[end] &&
                        (end - start <= 2 || matrix[start + 1, end - 1] == true))
                    {
                        matrix[start, end] = true;
                        if (retEnd - retStart < end - start)
                        {
                            retStart = start;
                            retEnd = end;
                        }
                    }
                }
            }

            return input.Substring(retStart, retEnd - retStart + 1);
        }

        string LongestPalindrome_2(string input)
        {
            int start = 0, end = 0; 
            bool[,] matrix = new bool[input.Length, input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                start = end = i;
                matrix[i, i] = true;
            }
            for (int offset = 1; offset < input.Length; offset++)
            {
                for (int i = 0; i < input.Length; i++)
                {
                    int tempStart = i, tempEnd = i + offset;
                    if (tempEnd >= input.Length)
                        break;

                    if (input[tempStart] == input[tempEnd] && 
                        (offset <= 2 || matrix[tempStart + 1, tempEnd - 1]))
                    {
                        matrix[tempStart, tempEnd] = true;
                        if (end - start < tempEnd - tempStart)
                        {
                            start = tempStart;
                            end = tempEnd;
                        }
                    }
                }
            }

            return input.Substring(start, end - start + 1);
        }

        public string SolveQuestion(string input)
        {
            return "\"" + LongestPalindrome(input.Deserialize()) + "\"";
        }

        [TestMethod]
        public void Q005_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q005_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
