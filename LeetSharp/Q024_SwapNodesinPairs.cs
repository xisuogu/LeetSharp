using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given a linked list, swap every two adjacent nodes and return its head.

// For example,
// Given 1->2->3->4, you should return the list as 2->1->4->3.

// Your algorithm should use only constant space. You may not modify the values in the list, only nodes itself can be changed.

namespace LeetSharp
{
    [TestClass]
    public class Q024_SwapNodesinPairs
    {
        public ListNode<int> SwapPairs(ListNode<int> head)
        {
            if (head == null || head.Next == null)
                return head;

            ListNode<int> newHead = head.Next;
            ListNode<int> tail = new ListNode<int>(0);

            while (head != null && head.Next != null)
            {
                ListNode<int> temp = head.Next.Next;
                tail.Next = head.Next;
                tail.Next.Next = head;
                tail = head;
                tail.Next = null;
                head = temp;
            }

            tail.Next = head;
            return newHead;
        }

        /*
         * 
        public ListNode<int> SwapPairs(ListNode<int> head)
        {
            if (head == null)
                return null;

            return SwapPairsRecursive(head);
        }

        public ListNode<int> SwapPairsRecursive(ListNode<int> head)
        {
            ListNode<int> ret = null;
            if (head.Next != null && head.Next.Next != null)
                ret = SwapPairsRecursive(head.Next.Next);

            ListNode<int> newHead = head;
            if (head.Next != null)
            {
                newHead = head.Next;
                newHead.Next = head;
                head.Next = ret;
            }

            return newHead;
        }
         */

        public string SolveQuestion(string input)
        {
            return SwapPairs(input.ToListNode<int>()).SerializeListNode();
        }

        [TestMethod]
        public void Q024_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q024_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
