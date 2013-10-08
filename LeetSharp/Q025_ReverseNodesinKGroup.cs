using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given a linked list, reverse the nodes of a linked list k at a time and return its modified list.
// If the number of nodes is not a multiple of k then left-out nodes in the end should remain as it is.
// You may not alter the values in the nodes, only nodes itself may be changed.

// Only constant memory is allowed.

// For example,
// Given this linked list: 1->2->3->4->5
// For k = 2, you should return: 2->1->4->3->5
// For k = 3, you should return: 3->2->1->4->5

namespace LeetSharp
{
    [TestClass]
    public class Q025_ReverseNodesinKGroup
    {
        public ListNode<int> ReverseKGroup(ListNode<int> head, int k)
        {
            if (head == null)
                return null;

            ListNode<int> newHead = new ListNode<int>(-1);
            ListNode<int> oldlast = newHead; 
            while (head != null)
            {
                ListNode<int> newList = new ListNode<int>(-1);

                ListNode<int> newLast = newList;
                ListNode<int> oldHead = head;
                
                int i = 0;
                for (; head != null && i < k; i++)
                {
                    newList.Val = head.Val;
                    ListNode<int> temp = new ListNode<int>(-1);
                    temp.Next = newList;
                    newList = temp;
                    head = head.Next;
                }

                if (i == k)
                {
                    oldlast.Next = newList.Next;
                    oldlast = newLast;
                }
                else
                {
                    oldlast.Next = oldHead;
                }
            }

            return newHead.Next;
        }

        public string SolveQuestion(string input)
        {
            return ReverseKGroup(input.GetToken(0).ToListNode<int>(), input.GetToken(1).ToInt()).SerializeListNode();
        }

        [TestMethod]
        public void Q025_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q025_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
