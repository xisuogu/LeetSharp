using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given a list, rotate the list to the right by k places, where k is non-negative.

// For example:
// Given 1->2->3->4->5->NULL and k = 2,
// return 4->5->1->2->3->NULL.

namespace LeetSharp
{
    [TestClass]
    public class Q061_RotateList
    {
        public ListNode<int> RotateRight(ListNode<int> head, int n)
        {
            if (head == null)
            {
                return null;
            }

            int totalLength = 1;
            ListNode<int> tail = head;
            while (tail.Next != null)
            {
                totalLength++;
                tail = tail.Next;
            }

            n %= totalLength;

            if (n == 0)
            {
                return head;
            }

            ListNode<int> p = head;
            for (int i = 0; i < totalLength - n - 1; i++)
            {
                p = p.Next;
            }

            ListNode<int> newHead = p.Next;
            p.Next = null;
            tail.Next = head;

            return newHead;
        }

        public string SolveQuestion(string input)
        {
            return RotateRight(input.GetToken(0).ToListNode<int>(), 
                input.GetToken(1).ToInt()).SerializeListNode();
        }

        [TestMethod]
        public void Q061_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q061_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
