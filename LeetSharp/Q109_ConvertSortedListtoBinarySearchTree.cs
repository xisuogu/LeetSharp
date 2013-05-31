using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given a singly linked list where elements are sorted in ascending order, convert it to a height balanced BST.

namespace LeetSharp
{
    [TestClass]
    public class Q109_ConvertSortedListtoBinarySearchTree
    {
        public BinaryTree SortedListToBST(ListNode<int> head)
        {
            return null;
        }

        public string SolveQuestion(string input)
        {
            return SortedListToBST(input.ToListNode<int>()).SerializeBinaryTree();
        }

        [TestMethod]
        public void Q109_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q109_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
