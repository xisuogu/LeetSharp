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
            return null;
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
