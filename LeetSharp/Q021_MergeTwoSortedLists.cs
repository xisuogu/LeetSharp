using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Merge two sorted linked lists and return it as a new list. 
// The new list should be made by splicing together the nodes of the first two lists.

namespace LeetSharp
{
    [TestClass]
    public class Q021_MergeTwoSortedLists
    {
        public ListNode<int> MergeTwoLists(ListNode<int> l1, ListNode<int> l2)
        {
            if (l1 == null)
            {
                return l2;
            }
            if (l2 == null)
            {
                return l1;
            }
            var result = l1.Val <= l2.Val ? l1 : l2;
            var small = l1.Val <= l2.Val ? l1 : l2;
            var large = l1.Val <= l2.Val ? l2 : l1;
            while (small != null && large != null)
            {
                // move small pointer forward
                while (small.Val <= large.Val)
                {
                    if (small.Next == null || small.Next.Val > large.Val)
                    {
                        break;
                    }
                    small = small.Next;
                }
                var smallNext = small.Next;
                small.Next = large;
                if (smallNext == null)
                {
                    break;
                }
                // move large pointer forward, then merge
                while (large.Next != null && smallNext.Val > large.Next.Val)
                {
                    large = large.Next;
                }
                //if (large != null)
                {
                    var temp = large.Next;
                    large.Next = smallNext;
                    large = temp;
                }
                small = smallNext;
            }

            return result;
        }

        public string SolveQuestion(string input)
        {
            return MergeTwoLists(input.GetToken(0).ToListNode<int>(), input.GetToken(1).ToListNode<int>())
                .SerializeListNode();
        }

        [TestMethod]
        public void Q021_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q021_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
