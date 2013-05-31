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
            // get the length of listnode
            var tmp = head;
            int length = 0;
            while (tmp != null)
            {
                length++;
                tmp = tmp.Next;
            }
            return SortedListToBST(ref head, length);
        }

        private BinaryTree SortedListToBST(ref ListNode<int> head, int length)
        {
            if (length == 0)
            {
                return null;
            }
            int leftLength = length / 2;
            BinaryTree leftChild = SortedListToBST(ref head, leftLength);
            BinaryTree root = new BinaryTree(head.Val);
            head = head.Next; // move forward
            root.Left = leftChild;
            root.Right = SortedListToBST(ref head, length - 1 - leftLength);
            return root;
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
