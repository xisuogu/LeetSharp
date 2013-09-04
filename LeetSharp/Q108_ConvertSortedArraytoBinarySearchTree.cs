using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given an array where elements are sorted in ascending order, convert it to a height balanced BST.

namespace LeetSharp
{
    [TestClass]
    public class Q108_ConvertSortedArraytoBinarySearchTree
    {
        public BinaryTree SortedArrayToBST(int[] num)
        {
            return SortedArrayToBST(num, 0, num.Length - 1);
        }

        private BinaryTree SortedArrayToBST(int[] num, int start, int end)
        {
            if (start > end) 
                return null;

            int middle = (start + end + 1) / 2;
            BinaryTree tree = new BinaryTree(num[middle]);

            tree.Left = SortedArrayToBST(num, start, middle - 1);
            tree.Right = SortedArrayToBST(num, middle + 1, end);
            return tree;
        }

        public string SolveQuestion(string input)
        {
            return SortedArrayToBST(input.ToIntArray()).SerializeBinaryTree();
        }

        [TestMethod]
        public void Q108_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q108_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
