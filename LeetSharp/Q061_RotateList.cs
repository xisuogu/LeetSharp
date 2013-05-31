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
            // calc length first
            int length = 1;
            var tail = head;
            while (tail.Next != null)
            {
                length++;
                tail = tail.Next;
            }
            if (length <= 1)
            {
                return head;
            }
            n = n % length;
            if (n == 0)
            {
                return head;
            }
            var newTail = head;
            for (int i = 0; i < length - 1 - n; i++)
            {
                newTail = newTail.Next;
            }
            tail.Next = head;
            head = newTail.Next;
            newTail.Next = null;
            return head;
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
