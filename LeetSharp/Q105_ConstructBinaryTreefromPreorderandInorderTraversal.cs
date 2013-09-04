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
            return BuildTree(preorder, inorder, 0, 0, preorder.Length);
        }

        public BinaryTree BuildTree(int[] preorder, int[] inorder, int preorderStart, int inorderStart, int length)
        {
            if (length == 0)
                return null;

            int middle = preorder[preorderStart];
            BinaryTree tree = new BinaryTree(middle);

            int i = inorderStart;
            for (; i < inorderStart + length; i++) // notice the end condition (inorderStart + length)
            {
                if (inorder[i] == middle)
                    break;
            }

            // notice how the leftLength & rightLength get calculated
            int leftLength = i - inorderStart;
            int rightLength = length - leftLength - 1;

            tree.Left = BuildTree(preorder, inorder, preorderStart + 1, inorderStart, leftLength);
            tree.Right = BuildTree(preorder, inorder, preorderStart + leftLength + 1, inorderStart + leftLength + 1, rightLength);

            return tree;
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
