using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given two words (start and end), and a dictionary, 
// find the length of shortest transformation sequence from start to end, such that:

// Only one letter can be changed at a time
// Each intermediate word must exist in the dictionary
// For example,

// Given:
// start = "hit"
// end = "cog"
// dict = ["hot","dot","dog","lot","log"]

// As one shortest transformation is "hit" -> "hot" -> "dot" -> "dog" -> "cog",
// return its length 5.

// Note:

// Return 0 if there is no such transformation sequence.
// All words have the same length.
// All words contain only lowercase alphabetic characters.

namespace LeetSharp
{
    [TestClass]
    public class Q127_WordLadder
    {
        public int LadderLength(string start, string end, string[] dict)
        {
            return -1;
        }

        public string SolveQuestion(string input)
        {
            return LadderLength(input.GetToken(0).Deserialize(), input.GetToken(1).Deserialize(),
                input.GetToken(2).ToStringArray()).ToString();
        }

        [TestMethod]
        public void Q127_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q127_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
