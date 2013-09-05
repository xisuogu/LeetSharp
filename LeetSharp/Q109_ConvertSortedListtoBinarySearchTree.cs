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
            int length = 0;
            ListNode<int> p = head;
            while (p != null)
            {
                length++;
                p = p.Next;
            }
            return SortedListToBST(ref head, length);
        }

        private BinaryTree SortedListToBST(ref ListNode<int> head, int length)
        {
            if (length == 0)
                return null;

            int leftLength = length / 2;
            BinaryTree leftTree = SortedListToBST(ref head, leftLength);
            BinaryTree tree = new BinaryTree(head.Val);
            head = head.Next; // the tricky part 
            tree.Left = leftTree;
            tree.Right = SortedListToBST(ref head, length - leftLength - 1);
            return tree;
        }

        public BinaryTree SortedListToBST2(ListNode<int> head)
        {
            if (head == null)
                return null;

            if (head.Next == null)
                return new BinaryTree(head.Val);

            ListNode<int> p1 = head;
            ListNode<int> p2 = head;
            ListNode<int> last = head;

            while (p2 != null && p2.Next != null)
            {
                last = p1;
                p1 = p1.Next;
                p2 = p2.Next.Next;
            }

            BinaryTree tree = new BinaryTree(p1.Val);
            last.Next = null;
            tree.Left = SortedListToBST(head);
            tree.Right = SortedListToBST(p1.Next);

            return tree;
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
