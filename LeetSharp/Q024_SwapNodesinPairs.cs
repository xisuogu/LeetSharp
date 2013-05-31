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
            {
                return head;
            }
            ListNode<int> preResult = new ListNode<int>(-9999); // helper node
            var pre = preResult;
            var n1 = head;
            var n2 = head.Next;
            var post = n2.Next;
            while (true)
            {
                pre.Next = n2;
                n2.Next = n1;
                n1.Next = post;
                if (post == null || post.Next == null)
                {
                    break;
                }
                pre = n1;
                n1 = post;
                n2 = n1.Next;
                post = n2.Next;
            }

            return preResult.Next;
        }

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
