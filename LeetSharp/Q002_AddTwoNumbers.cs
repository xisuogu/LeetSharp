using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// You are given two linked lists representing two non-negative numbers. The digits are stored in reverse order and each of their nodes contain a single digit. Add the two numbers and return it as a linked list.

// Input: (2 -> 4 -> 3) + (5 -> 6 -> 4)
// Output: 7 -> 0 -> 8

namespace LeetSharp
{
    [TestClass]
    public class Q002_AddTwoNumbers
    {
        public ListNode<int> AddTwoNumbers(ListNode<int> l1, ListNode<int> l2)
        {
            // add l2 on to l1
            ListNode<int> current = new ListNode<int>(0);
            var answer = current;
            int toAdd = 0;
            while (true)
            {
                current.Val += toAdd;
                if (l1 != null)
                {
                    current.Val += l1.Val;
                    l1 = l1.Next;
                }
                if (l2 != null)
                {
                    current.Val += l2.Val;
                    l2 = l2.Next;
                }
                toAdd = current.Val / 10;
                current.Val = current.Val % 10;
                if (l1 != null || l2 != null || toAdd > 0)
                {
                    current.Next = new ListNode<int>(0);
                    current = current.Next;
                }
                else
                {
                    break;
                }
            }
            return answer;
        }

        public string SolveQuestion(string input)
        {
            return AddTwoNumbers(input.GetToken(0).ToListNode<int>(), 
                input.GetToken(1).ToListNode<int>()).SerializeListNode();
        }

        [TestMethod]
        public void Q002_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q002_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
