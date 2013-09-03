using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given a string s1, we may represent it as a binary tree by partitioning it to two non-empty substrings recursively.

// Below is one possible representation of s1 = "great":

//     great
//    /    \
//   gr    eat
//  / \    /  \
// g   r  e   at
//            / \
//           a   t
// To scramble the string, we may choose any non-leaf node and swap its two children.

// For example, if we choose the node "gr" and swap its two children, it produces a scrambled string "rgeat".

//     rgeat
//    /    \
//   rg    eat
//  / \    /  \
// r   g  e   at
//            / \
//           a   t
// We say that "rgeat" is a scrambled string of "great".

// Similarly, if we continue to swap the children of nodes "eat" and "at", it produces a scrambled string "rgtae".

//     rgtae
//    /    \
//   rg    tae
//  / \    /  \
// r   g  ta  e
//        / \
//       t   a
// We say that "rgtae" is a scrambled string of "great".

// Given two strings s1 and s2 of the same length, determine if s2 is a scrambled string of s1.

namespace LeetSharp
{
    [TestClass]
    public class Q087_ScrambleString
    {
        public bool IsScramble(string s1, string s2)
        {
            if (s1 == s2)
                return true;
            if (s1.Length != s2.Length)
                return false;

            if (new string(s1.OrderBy(c => c).ToArray()) != new string(s2.OrderBy(c => c).ToArray()))
                return false;

            for (int leftLength = 1; leftLength < s1.Length; leftLength++)
            {
                if (IsScramble(s1.Substring(0, leftLength), s2.Substring(0, leftLength)) &&
                    IsScramble(s1.Substring(leftLength), s2.Substring(leftLength)))
                    return true;

                if (IsScramble(s1.Substring(0, leftLength), s2.Substring(s1.Length - leftLength)) &&
                    IsScramble(s1.Substring(leftLength), s2.Substring(0, s1.Length - leftLength)))
                    return true;
            }

            return false;
        }


        public bool IsScramble2(string s1, string s2)
        {
            if (s1.Length != s2.Length)
                return false;

            Dictionary<string, bool> cache = new Dictionary<string, bool>();
            return IsScrambleRecursive(s1, s2, 0, s1.Length - 1, 0, s2.Length - 1, cache);
        }

        private bool IsScrambleRecursive(string s1, string s2, int s1Left, int s1Right, int s2Left, int s2Right,
            Dictionary<string, bool> cache)
        {

            string s = s1Left + ":" + s1Right + ":" + s2Left + ":" + s2Right;
            if (!cache.ContainsKey(s))
            {

                if (s1Left == s1Right)
                {
                    cache[s] = s1[s1Left] == s2[s2Left];
                }
                else if (s1Right - s1Left == 1)
                {
                    cache[s] = (s1[s1Left] == s2[s2Left] && s1[s1Right] == s2[s2Right])
                        || (s1[s1Left] == s2[s2Right] && s1[s1Right] == s2[s2Left]);
                }
                else
                {
                    string s1New = new string(s1.Substring(s1Left, s1Right - s1Left + 1).OrderBy(c => c).ToArray());
                    string s2New = new string(s2.Substring(s2Left, s2Right - s2Left + 1).OrderBy(c => c).ToArray());
                    if (s1New != s2New)
                    {
                        cache[s] = false;
                    }
                    else
                    {
                        for (int i = s1Left; i < s1Right; i++)
                        {
                            cache[s] = (IsScrambleRecursive(s1, s2, s1Left, i, s2Left, s2Left + i - s1Left, cache)
                                && IsScrambleRecursive(s1, s2, i + 1, s1Right, s2Left + i + 1 - s1Left, s2Right, cache))
                                || (IsScrambleRecursive(s1, s2, s1Left, i, s2Right - i + s1Left, s2Right, cache)
                                && IsScrambleRecursive(s1, s2, i + 1, s1Right, s2Left, s2Left + s1Right - i - 1, cache));

                            if (cache[s] == true)
                                break;
                        }
                    }
                }
            }

            return cache[s];
        }

        public string SolveQuestion(string input)
        {
            return IsScramble(input.GetToken(0).Deserialize(), input.GetToken(1).Deserialize()).ToString().ToLower();
        }

        [TestMethod]
        public void Q087_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q087_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
