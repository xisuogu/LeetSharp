using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given a sorted linked list, delete all duplicates such that each element appear only once.

// For example,
// Given 1->1->2, return 1->2.
// Given 1->1->2->3->3, return 1->2->3.

namespace LeetSharp
{
    [TestClass]
    public class Q083_RemoveDuplicatesfromSortedList
    {
        public ListNode<int> DeleteDuplicates(ListNode<int> head)
        {
            ListNode<int> dummy = new ListNode<int>(0);
            var write = dummy;
            while (head != null)
            {
                write.Next = head;
                write = write.Next;
                // move head to different value
                int currentValue = head.Val;
                head = head.Next;
                while (head != null)
                {
                    if (head.Val != currentValue)
                    {
                        break;
                    }
                    head = head.Next;
                }
            }
            write.Next = null;
            return dummy.Next;
        }

        public string SolveQuestion(string input)
        {
            return DeleteDuplicates(input.ToListNode<int>()).SerializeListNode();
        }

        [TestMethod]
        public void Q083_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q083_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
