using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Reverse a linked list from position m to n. Do it in-place and in one-pass.

// For example:
// Given 1->2->3->4->5->NULL, m = 2 and n = 4,

// return 1->4->3->2->5->NULL.

// Note:
// Given m, n satisfy the following condition:
// 1 <= m <= n <= length of list.

namespace LeetSharp
{
    [TestClass]
    public class Q092_ReverseLinkedListII
    {
        public ListNode<int> ReverseBetween(ListNode<int> head, int m, int n)
        {
            ListNode<int> newHead = new ListNode<int>(-1);
            newHead.Next = head;

            ListNode<int> preTail = newHead;

            int index = 1;
            while (index++ < m)
            {
                preTail = preTail.Next;
            }

            var curNode = preTail.Next;
            for (int i = 0; i < n - m; i++)
            {
                var preNext = preTail.Next;
                var curNext = curNode.Next;
                curNode.Next = curNext.Next;
                preTail.Next = curNext;
                curNext.Next = preNext;
            }
            return newHead.Next;
        }

        public ListNode<int> ReverseBetween2(ListNode<int> head, int m, int n)
        {
            ListNode<int> newHead = new ListNode<int>(-1);
            newHead.Next = head;

            ListNode<int> preTail = newHead;

            int index = 1;
            while (index < m)
            {
                preTail = head;
                head = head.Next;
                index++;
            }

            ListNode<int> reversedHead = new ListNode<int>(-1);
            ListNode<int> reversedTail = reversedHead;
            while (index <= n)
            {
                reversedHead.Val = head.Val;
                ListNode<int> temp = new ListNode<int>(-1);
                temp.Next = reversedHead;
                reversedHead = temp;

                head = head.Next;
                index++;
            }
            reversedTail.Next = head;
            preTail.Next = reversedHead.Next;

            return newHead.Next;
        }

        public string SolveQuestion(string input)
        {
            return ReverseBetween(input.GetToken(0).ToListNode<int>(), input.GetToken(1).ToInt(),
                input.GetToken(2).ToInt()).SerializeListNode();
        }

        [TestMethod]
        public void Q092_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q092_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
