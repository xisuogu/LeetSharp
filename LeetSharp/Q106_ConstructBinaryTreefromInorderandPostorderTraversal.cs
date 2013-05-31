using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given inorder and postorder traversal of a tree, construct the binary tree.

// Note:
// You may assume that duplicates do not exist in the tree.

namespace LeetSharp
{
    [TestClass]
    public class Q106_ConstructBinaryTreefromInorderandPostorderTraversal
    {
        public BinaryTree BuildTree(int[] inOrder, int[] postOrder)
        {
            return null;
        }

        public string SolveQuestion(string input)
        {
            return BuildTree(input.GetToken(0).ToIntArray(), input.GetToken(1).ToIntArray()).SerializeBinaryTree();
        }

        [TestMethod]
        public void Q106_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q106_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
