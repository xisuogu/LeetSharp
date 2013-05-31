using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Merge k sorted linked lists and return it as one sorted list. Analyze and describe its complexity.

namespace LeetSharp
{
    [TestClass]
    public class Q023_MergekSortedLists
    {
        public ListNode<int> MergeKLists(ListNode<int>[] lists)
        {
            return null;
        }

        public string SolveQuestion(string input)
        {
            return MergeKLists(input.ToListNodeArray<int>()).SerializeListNode();
        }

        [TestMethod]
        public void Q023_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q023_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
