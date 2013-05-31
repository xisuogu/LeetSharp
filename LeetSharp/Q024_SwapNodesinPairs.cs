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
            return null;
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
