using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// You are given a string, S, and a list of words, L, that are all of the same length. 
// Find all starting indices of substring(s) in S that is a concatenation 
// of each word in L exactly once and without any intervening characters.

// For example, given:
// S: "barfoothefoobarman"
// L: ["foo", "bar"]

// You should return the indices: [0,9].
// (order does not matter).

namespace LeetSharp
{
    [TestClass]
    public class Q030_SubstringwithConcatenationofAllWords
    {
        // permute L then compare works, but would generate too many string[], and out of memory
        // note: in L, all the words have same length!
        // so for every detetion, string can be split into l.Lenght parts

        public int[] FindSubstring(string s, string[] l)
        {
            // build word count from L first, dup words can be handled like this
            Dictionary<string, int> wordCount = new Dictionary<string, int>();
            l.ToList().ForEach(w => wordCount[w] = wordCount.ContainsKey(w) ? wordCount[w] + 1 : 1);
            int slotLength = l[0].Length;
            int totalpartLenght = l.Sum(p => p.Length);

            var answer = new List<int>();
            for (int i = 0; i <= slotLength - 1; i++)
            {
                Dictionary<string, int> currentRemaing = new Dictionary<string, int>(wordCount);
                for (int j = i + slotLength; j <= s.Length; j += slotLength)
                {
                    int remainingCount = l.Length;
                    string newInSlot = s.Substring(j - slotLength, slotLength);
                    if (currentRemaing.ContainsKey(newInSlot))
                    {
                        currentRemaing[newInSlot] -= 1;
                    }
                    if (j - i > totalpartLenght) // offset previous slot before current detection area
                    {
                        string preSlot = s.Substring(j - totalpartLenght - slotLength, slotLength);
                        if (currentRemaing.ContainsKey(preSlot))
                        {
                            currentRemaing[preSlot] += 1;
                        }
                    }
                    if (currentRemaing.Values.All(n => n == 0)) // all the word captured, must hit answer
                    {
                        answer.Add(j - totalpartLenght);
                    }
                }
            }
            return answer.OrderBy(a => a).ToArray();
        }

        public string SolveQuestion(string input)
        {
            return TestHelper.Serialize(
                FindSubstring(input.GetToken(0).Deserialize(), input.GetToken(1).ToStringArray()));
        }

        [TestMethod]
        public void Q030_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q030_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
