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
            return null;
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
