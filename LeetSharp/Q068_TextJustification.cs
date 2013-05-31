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
            List<string> result = new List<string>();
            int currentStartIndex = 0;
            int currentEndIndex = 0;
            int remainingLength = length;
            for (int i = 0; i < words.Length; i++)
            {
                remainingLength -= (words[i].Length + 1);
                if (remainingLength < -1) // previous ones push into result
                {
                    result.Add(JustifyLine(words, currentStartIndex, currentEndIndex, length));
                    currentStartIndex = currentEndIndex = i;
                    remainingLength = length - (words[i].Length + 1);
                }
                else if (remainingLength == -1) // this one + previous ones push into result
                {
                    result.Add(JustifyLine(words, currentStartIndex, i, length));
                    currentStartIndex = currentEndIndex = i + 1;
                    remainingLength = length;
                }
                else
                {
                    currentEndIndex = i;
                }
            }
            if (currentStartIndex < words.Length)
            {
                result.Add(JustifyLine(words, currentStartIndex, currentEndIndex, length));
            }
            return result.ToArray();
        }

        private string JustifyLine(string[] words, int start, int end, int length)
        {
            int count = end - start + 1;
            var wordsToProcess = words.Skip(start).Take(count).ToArray();
            if (end == words.Length - 1)
            {
                return String.Join(" ", wordsToProcess).PadRight(length);
            }
            if (count == 1)
            {
                return words[start].PadRight(length); // special case
            }
            int spaceLength = length - wordsToProcess.Sum(w => w.Length);
            int spaceLengthMod = spaceLength % (count - 1);
            int perSpaceLength = spaceLength / (count - 1);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < wordsToProcess.Length - 1; i++)
            {
                sb.Append(wordsToProcess[i]);
                sb.Append(new string(' ', perSpaceLength));
                if (spaceLengthMod-- > 0)
                {
                    sb.Append(' ');
                }
            }
            sb.Append(wordsToProcess.Last());
            return sb.ToString();
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
