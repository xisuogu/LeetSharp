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
            return -1;
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
