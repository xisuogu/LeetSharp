using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given preorder and inorder traversal of a tree, construct the binary tree.

// Note:
// You may assume that duplicates do not exist in the tree.

namespace LeetSharp
{
    [TestClass]
    public class Q105_ConstructBinaryTreefromPreorderandInorderTraversal
    {
        public BinaryTree BuildTree(int[] preorder, int[] inorder)
        {
            return null;
        }

        public string SolveQuestion(string input)
        {
            return BuildTree(input.GetToken(0).ToIntArray(), input.GetToken(1).ToIntArray()).SerializeBinaryTree();
        }

        [TestMethod]
        public void Q105_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q105_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
