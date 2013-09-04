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
            return BuildTree(inOrder, postOrder, 0, 0, inOrder.Length);
        }

        public BinaryTree BuildTree(int[] inOrder, int[] postOrder, int inOrderStart, int postOrderStart, int length)
        {
            if (length == 0)
                return null;

            int middle = postOrder[postOrderStart + length - 1]; // notice the index is not "length - 1"
            BinaryTree tree = new BinaryTree(middle);

            int i = inOrderStart;
            for (; i < inOrderStart + length; i++) // notice the end condition (inorderStart + length)
            {
                if (inOrder[i] == middle)
                    break;
            }

            // notice how the leftLength & rightLength get calculated
            int leftLength = i - inOrderStart;
            int rightLength = length - leftLength - 1;

            tree.Left = BuildTree(inOrder, postOrder, inOrderStart, postOrderStart, leftLength);
            tree.Right = BuildTree(inOrder, postOrder, inOrderStart + leftLength + 1, postOrderStart + leftLength, rightLength);

            return tree;
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
