using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given a binary tree, return the bottom-up level order traversal of its nodes' values. 
// (ie, from left to right, level by level from leaf to root).

// For example:
// Given binary tree {3,9,20,#,#,15,7},

//     3
//    / \
//   9  20
//     /  \
//    15   7
// return its bottom-up level order traversal as:

// [
//   [15,7]
//   [9,20],
//   [3],
// ]

namespace LeetSharp
{
    [TestClass]
    public class Q107_BinaryTreeLevelOrderTraversalII
    {
        public int[][] LevelOrderBottomII(BinaryTree root)
        {
            return null;
        }

        public string SolveQuestion(string input)
        {
            return TestHelper.Serialize(LevelOrderBottomII(input.ToBinaryTree()));
        }

        [TestMethod]
        public void Q107_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q107_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
