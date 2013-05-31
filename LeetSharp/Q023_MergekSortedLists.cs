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
            lists = lists.Where(l => l != null).ToArray();
            if (lists.Length == 0)
            {
                return null;
            }
            MinHeap<ListNode<int>> heap = new MinHeap<ListNode<int>>(lists, new ListNodeComparer());
            ListNode<int> preAnswer = new ListNode<int>(0);
            ListNode<int> current = preAnswer;
            while (heap.Count > 0)
            {
                var topList = heap.ExtractDominating();
                current.Next = new ListNode<int>(topList.Val);
                current = current.Next;

                if (topList.Next != null)
                {
                    heap.Add(topList.Next);
                }
            }
            return preAnswer.Next;
        }

        class ListNodeComparer : Comparer<ListNode<int>>
        {
            public override int Compare(ListNode<int> x, ListNode<int> y)
            {
                return x.Val.CompareTo(y.Val);
            }
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
