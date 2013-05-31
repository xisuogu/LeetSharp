using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given n, how many structurally unique BST's (binary search trees) that store values 1...n?

// For example,
// Given n = 3, there are a total of 5 unique BST's.

//   1         3     3      2      1
//    \       /     /      / \      \
//     3     2     1      1   3      2
//    /     /       \                 \
//   2     1         2                 3

namespace LeetSharp
{
    [TestClass]
    public class Q096_UniqueBinarySearchTrees
    {
        public int NumTrees(int n)
        {
            if (n == 1)
            {
                return 1;
            }
            int[] answers = new int[n + 1];
            answers[0] = 1; // 0 node
            answers[1] = 1; // 1 nodes
            answers[2] = 2; // 2 nodes
            for (int i = 3; i <= n; i++) // get answer i: i nodes
            {
                // left part can have 0 - i-1 nodes, if i nodes in all
                for (int left = 0; left <= i - 1; left++)
                {
                    answers[i] += answers[left] * answers[i - left - 1];
                }
            }
            return answers[n];
        }

        public string SolveQuestion(string input)
        {
            return NumTrees(input.ToInt()).ToString();
        }

        [TestMethod]
        public void Q096_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q096_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
