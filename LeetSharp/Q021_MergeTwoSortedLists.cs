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
            ListNode<int> current = new ListNode<int>(0);
            ListNode<int> result = current;
            while (l1 != null && l2 != null)
            {
                int currentValue = 0;
                if (l1.Val < l2.Val)
                {
                    currentValue = l1.Val;
                    l1 = l1.Next;
                }
                else
                {
                    currentValue = l2.Val;
                    l2 = l2.Next;
                }
                current.Next = new ListNode<int>(currentValue);
                current = current.Next;
            }

            if (l1 != null)
            {
                current.Next = l1;
            }
            else if (l2 != null)
            {
                current.Next = l2;
            }
            else
            {
                current.Next = null;
            }

            return result.Next;
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
