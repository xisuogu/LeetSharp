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

        private BinaryTree SortedArrayToBST(int[] num, int indexStart, int indexEnd)
        {
            if (indexStart == indexEnd)
            {
                return new BinaryTree(num[indexStart]);
            }
            if (indexStart > indexEnd)
            {
                return null;
            }
            int indexMid = (indexStart + indexEnd + 1) / 2;
            var root = new BinaryTree(num[indexMid]);
            root.Left = SortedArrayToBST(num, indexStart, indexMid - 1);
            root.Right = SortedArrayToBST(num, indexMid + 1, indexEnd);
            return root;
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
