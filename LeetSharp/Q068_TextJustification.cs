using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given an array of words and a length L, 
// format the text such that each line has exactly L characters and is fully (left and right) justified.

// You should pack your words in a greedy approach; 
// that is, pack as many words as you can in each line. Pad extra spaces ' ' when necessary 
// so that each line has exactly L characters.

// Extra spaces between words should be distributed as evenly as possible. 
// If the number of spaces on a line do not divide evenly between words, 
// the empty slots on the left will be assigned more spaces than the slots on the right.

// For the last line of text, it should be left justified and no extra space is inserted between words.

// For example,
// words: ["This", "is", "an", "example", "of", "text", "justification."]
// L: 16.

// Return the formatted lines as:
// [
//   "This    is    an",
//   "example  of text",
//   "justification.  "
// ]
// Note: Each word is guaranteed not to exceed L in length.
// Corner Cases:
//   A line other than the last line might contain only one word. What should you do in this case?
//   In this case, that line should be left-justified.

namespace LeetSharp
{
    [TestClass]
    public class Q068_TextJustification
    {
        public string[] FullJustify(string[] words, int length)
        {
            return null;
        }

        public string SolveQuestion(string input)
        {
            return TestHelper.Serialize(FullJustify(input.GetToken(0).ToStringArray(), input.GetToken(1).ToInt()));
        }

        [TestMethod]
        public void Q068_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q068_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
