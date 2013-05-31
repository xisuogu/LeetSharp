using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given a binary tree, return the inorder traversal of its nodes' values.

// For example:
// Given binary tree {1,#,2,3},

//    1
//     \
//      2
//     /
//    3
// return [1,3,2].

// Note: Recursive solution is trivial, could you do it iteratively?

namespace LeetSharp
{
    [TestClass]
    public class Q094_BinaryTreeInorderTraversal
    {
        public int[] InorderTraversal(BinaryTree root)
        {
            return null;
        }

        public string SolveQuestion(string input)
        {
            return TestHelper.Serialize(InorderTraversal(input.ToBinaryTree()));
        }

        [TestMethod]
        public void Q094_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q094_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
