using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given a linked list and a value x, 
// partition it such that all nodes less than x come before nodes greater than or equal to x.

// You should preserve the original relative order of the nodes in each of the two partitions.

// For example,
// Given 1->4->3->2->5->2 and x = 3,
// return 1->2->2->4->3->5.

namespace LeetSharp
{
    [TestClass]
    public class Q086_PartitionList
    {
        public ListNode<int> Partition(ListNode<int> head, int x)
        {
            ListNode<int> dummy = new ListNode<int>(0);
            dummy.Next = head;
            ListNode<int> smallPart = dummy;
            while (smallPart != null && smallPart.Next != null)
            {
                while (smallPart != null && smallPart.Next != null && smallPart.Next.Val < x)
                {
                    smallPart = smallPart.Next;
                } // smallPart is smaller than x, its next is GE x
                var bigPart = smallPart.Next;
                while (bigPart != null && bigPart.Next != null && bigPart.Next.Val >= x)
                {
                    bigPart = bigPart.Next;
                }
                if (bigPart != null && bigPart.Next != null) // bigPart.Next should be moved before
                {
                    var nextToBig = bigPart.Next;
                    bigPart.Next = nextToBig.Next;
                    nextToBig.Next = smallPart.Next;
                    smallPart.Next = nextToBig;
                }
                smallPart = smallPart.Next;
            }
            return dummy.Next;
        }

        public string SolveQuestion(string input)
        {
            return Partition(input.GetToken(0).ToListNode<int>(), input.GetToken(1).ToInt()).SerializeListNode();
        }

        [TestMethod]
        public void Q086_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q086_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
