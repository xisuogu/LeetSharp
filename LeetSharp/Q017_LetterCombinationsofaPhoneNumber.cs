using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given a digit string, return all possible letter combinations that the number could represent.

// A mapping of digit to letters (just like on the telephone buttons) is given below.

// Input:Digit string "23"
// Output: ["ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf"].

namespace LeetSharp
{
    [TestClass]
    public class Q017_LetterCombinationsofaPhoneNumber
    {
        private Dictionary<char, char[]> mapping = new Dictionary<char, char[]>()
        {
            {'2', new [] {'a', 'b', 'c'} },
            {'3', new [] {'d', 'e', 'f'} },
            {'4', new [] {'g', 'h', 'i'} },
            {'5', new [] {'j', 'k', 'l'} },
            {'6', new [] {'m', 'n', 'o'} },
            {'7', new [] {'p', 'q', 'r', 's'} },
            {'8', new [] {'t', 'u', 'v'} },
            {'9', new [] {'w', 'x', 'y', 'z'} },
        };

        public string[] LetterCombinations(string digits)
        {
            List<string> tmp = new List<string>() { "" };
            int length = digits.Length;
            List<char[]> keys = new List<char[]>();
            digits.ToList().ForEach(c => keys.Add(mapping[c]));
            for (int i = 0; i < keys.Count; i++)
            {
                List<string> newTmp = new List<string>();
                foreach (var s in tmp)
                {
                    foreach (var c in keys[i])
                    {
                        newTmp.Add(s + c);
                    }
                }
                tmp = newTmp;
            }
            return tmp.ToArray();
        }

        public string SolveQuestion(string input)
        {
            return TestHelper.Serialize(LetterCombinations(input.Deserialize()));
        }

        [TestMethod]
        public void Q017_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q017_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
