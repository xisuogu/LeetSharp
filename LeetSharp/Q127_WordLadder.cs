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
            HashSet<string> hset = new HashSet<string>(dict);
            HashSet<string> currentStarts = new HashSet<string>() { start };
            int answer = 1;
            while (true)
            {
                hset.RemoveWhere(v => currentStarts.Contains(v));
                HashSet<string> nextStarts = new HashSet<string>();
                foreach (var starting in currentStarts)
                {
                    if (starting == end)
                    {
                        return answer;
                    }
                    GetValidMoves(starting, hset).ToList().ForEach(n => nextStarts.Add(n));
                }
                if (nextStarts.Count > 0)
                {
                    answer++;
                    currentStarts = nextStarts;
                }
                else
                {
                    return 0;
                }
            }
        }

        private string letters = "abcdefghijklmnopqrstuvwxyz";
        private string[] GetValidMoves(string from, HashSet<string> dic)
        {
            List<string> result = new List<string>();
            for (int i = 0; i < from.Length; i++)
            {
                var attempt = from.ToCharArray();
                for (int j = 0; j < 26; j++)
                {
                    attempt[i] = letters[j];
                    string s = new string(attempt);
                    if (dic.Contains(s))
                    {
                        result.Add(s);
                    }
                }
            }
            return result.ToArray();
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
