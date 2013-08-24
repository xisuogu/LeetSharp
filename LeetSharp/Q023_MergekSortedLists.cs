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
        public class Node : IComparable
        {
            public int Data { get; set; } 
            public int Index { get; set; }
            

            public int CompareTo(object obj)
            {
                Node other = obj as Node;
                if (other == null)
                {
                    throw new ArgumentException("obj");
                }

                return Data.CompareTo(other.Data);
            }
        }

        public ListNode<int> MergeKLists(ListNode<int>[] lists)
        {
            MinHeap<Node> heap = new MinHeap<Node>();
            for (int i = 0; i < lists.Length; i++)
            {
                if (lists[i] == null)
                    continue;

                Node node = new Node();
                node.Data = lists[i].Val;
                node.Index = i;
                heap.Add(node);
                lists[i] = lists[i].Next;
            }

            ListNode<int> resultList = new ListNode<int>(0);
            ListNode<int> head = resultList;
            while (heap.Count > 0)
            {
                Node node = heap.ExtractDominating();
                resultList.Next = new ListNode<int>(node.Data);
                resultList = resultList.Next;

                int index = node.Index;
                if (lists[index] != null)
                {
                    node.Data = lists[index].Val;
                    lists[index] = lists[index].Next;
                    heap.Add(node);
                }
            }

            return head.Next;
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
