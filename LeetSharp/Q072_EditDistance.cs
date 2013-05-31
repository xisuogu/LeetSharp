using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given two words word1 and word2, find the minimum number of steps required to convert word1 to word2. 
// (each operation is counted as 1 step.)

// You have the following 3 operations permitted on a word:

// a) Insert a character
// b) Delete a character
// c) Replace a character

namespace LeetSharp
{
    [TestClass]
    public class Q072_EditDistance
    {
        public int MinDistance(string word1, string word2)
        {
            return -1;
        }

        public string SolveQuestion(string input)
        {
            return MinDistance(input.GetToken(0).Deserialize(), input.GetToken(1).Deserialize()).ToString();
        }

        [TestMethod]
        public void Q072_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q072_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
