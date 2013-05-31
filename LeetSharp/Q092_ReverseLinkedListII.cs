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
            if (m == n)
            {
                return head;
            }
            // find pre-changing head
            ListNode<int> dummy = new ListNode<int>(0);
            dummy.Next = head;
            var preChaningHead = dummy;
            int changeLength = n - m;
            while (m-- > 1)
            {
                preChaningHead = preChaningHead.Next;
            }
            var curNode = preChaningHead.Next;
            for (int i = 0; i < changeLength; i++)
            {
                var preNext = preChaningHead.Next;
                var curNext = curNode.Next;
                curNode.Next = curNext.Next;
                preChaningHead.Next = curNext;
                curNext.Next = preNext;
            }
            return dummy.Next;
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
