using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given a string s consists of upper/lower-case alphabets and empty space characters ' ', return the length of last word in the string.

// If the last word does not exist, return 0.

// Note: A word is defined as a character sequence consists of non-space characters only.

// For example, 
// Given s = "Hello World",
// return 5.

namespace LeetSharp
{
    [TestClass]
    public class Q058_LengthofLastWord
    {
        public int LengthOfLastWord(string input)
        {
            int endOfLastWord = 0;
            bool inLastWord = false;
            for (int i = input.Length - 1; i >= 0; i--)
            {
                if (input[i] == ' ')
                {
                    if (inLastWord)
                    {
                        return endOfLastWord - i;
                    }
                }
                else
                {
                    if (!inLastWord)
                    {
                        inLastWord = true;
                        endOfLastWord = i;
                    }
                }
            }
            if (inLastWord)
            {
                return endOfLastWord + 1;
            }
            return 0;
        }

        public string SolveQuestion(string input)
        {
            return LengthOfLastWord(input.Deserialize()).ToString();
        }

        [TestMethod]
        public void Q058_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q058_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
