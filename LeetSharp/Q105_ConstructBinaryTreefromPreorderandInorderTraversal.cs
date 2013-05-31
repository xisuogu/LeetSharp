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
            return BuildTreeRec(preorder, inorder, 0, preorder.Length - 1, 0, inorder.Length - 1);
        }

        private BinaryTree BuildTreeRec(int[] preOrder, int[] inOrder, int startPreOrder, int endPreOrder,
            int startInOrder, int endInOrder)
        {
            if (startInOrder > endInOrder)
            {
                return null;
            }
            int rootValue = preOrder[startPreOrder];
            int indexInInOrder = startInOrder;
            for (; indexInInOrder <= endInOrder; indexInInOrder++)
            {
                if (rootValue == inOrder[indexInInOrder])
                {
                    break;
                }
            }
            BinaryTree root = new BinaryTree(rootValue);
            int leftLength = indexInInOrder - startInOrder;
            root.Left = BuildTreeRec(preOrder, inOrder, startPreOrder + 1, startPreOrder + leftLength,
                startInOrder, indexInInOrder - 1);
            root.Right = BuildTreeRec(preOrder, inOrder, startPreOrder + leftLength + 1, endPreOrder,
                indexInInOrder + 1, endInOrder);
            return root;
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
