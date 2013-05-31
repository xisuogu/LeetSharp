using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given a binary tree, return the zigzag level order traversal of its nodes' values.
// (ie, from left to right, then right to left for the next level and alternate between).

// For example:
// Given binary tree {3,9,20,#,#,15,7},

//    3
//   / \
//  9  20
//    /  \
//   15   7
// return its zigzag level order traversal as:

// [
//  [3],
//  [20,9],
//  [15,7]
// ]

namespace LeetSharp
{
    [TestClass]
    public class Q103_BinaryTreeZigzagLevelOrderTraversal
    {
        public int[][] ZigzagLevelOrder(BinaryTree root)
        {
            return null;
        }

        public string SolveQuestion(string input)
        {
            return TestHelper.Serialize(ZigzagLevelOrder(input.ToBinaryTree()));
        }

        [TestMethod]
        public void Q103_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q103_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
