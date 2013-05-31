using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given a binary tree, return the level order traversal of its nodes' values. (ie, from left to right, level by level).

// For example:
// Given binary tree {3,9,20,#,#,15,7},

//    3
//   / \
//  9  20
//    /  \
//   15   7
// return its level order traversal as:

// [
//  [3],
//  [9,20],
//  [15,7]
// ]

namespace LeetSharp
{
    [TestClass]
    public class Q102_BinaryTreeLevelOrderTraversal
    {
        public int[][] LevelOrder(BinaryTree root)
        {
            return null;
        }

        public string SolveQuestion(string input)
        {
            return TestHelper.Serialize(LevelOrder(input.ToBinaryTree()));
        }

        [TestMethod]
        public void Q102_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q102_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
