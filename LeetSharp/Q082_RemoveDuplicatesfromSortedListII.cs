using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given a sorted linked list, delete all nodes that have duplicate numbers, 
// leaving only distinct numbers from the original list.

// For example,
// Given 1->2->3->3->4->4->5, return 1->2->5.
// Given 1->1->1->2->3, return 2->3.

namespace LeetSharp
{
    [TestClass]
    public class Q082_RemoveDuplicatesfromSortedListII
    {
        public ListNode<int> DeleteDuplicatesII(ListNode<int> head)
        {
            ListNode<int> dummy = new ListNode<int>(0);
            var write = dummy;
            while (head != null)
            {
                if (head.Next != null && head.Val == head.Next.Val) // has dup
                {

                }
                else
                {
                    write.Next = head;
                    write = write.Next;
                }
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
            return DeleteDuplicatesII(input.ToListNode<int>()).SerializeListNode();
        }

        [TestMethod]
        public void Q082_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q082_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
