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
            return BuildTreeRec(inOrder, postOrder, 0, inOrder.Length - 1, 0, postOrder.Length - 1);
        }

        private BinaryTree BuildTreeRec(int[] inOrder, int[] postOrder, int startInOrder, int endInOrder,
            int startPostOrder, int endPostOrder)
        {
            if (startPostOrder > endPostOrder)
            {
                return null;
            }
            if (startPostOrder == endPostOrder)
            {
                return new BinaryTree(postOrder[endPostOrder]);
            }
            int rootValue = postOrder[endPostOrder];
            BinaryTree root = new BinaryTree(rootValue);

            int indexInInOrder = startInOrder;
            for (; indexInInOrder <= endInOrder; indexInInOrder++)
            {
                if (rootValue == inOrder[indexInInOrder])
                {
                    break;
                }
            }
            int leftLength = indexInInOrder - startInOrder;
            root.Left = BuildTreeRec(inOrder, postOrder, startInOrder, indexInInOrder - 1,
                startPostOrder, startPostOrder + leftLength - 1);
            root.Right = BuildTreeRec(inOrder, postOrder, indexInInOrder + 1, endInOrder,
                startPostOrder + leftLength, endPostOrder - 1);
            return root;
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
