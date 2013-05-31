using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given a binary tree containing digits from 0-9 only, each root-to-leaf path could represent a number.
   
// An example is the root-to-leaf path 1->2->3 which represents the number 123.
   
// Find the total sum of all root-to-leaf numbers.
   
// For example,
   
//     1
//    / \
//   2   3
// The root-to-leaf path 1->2 represents the number 12.
// The root-to-leaf path 1->3 represents the number 13.
   
// Return the sum = 12 + 13 = 25.
   
namespace LeetSharp
{
    [TestClass]
    public class Q129_SumRoottoLeafNumbers
    {
        public int SumNumbers(BinaryTree root)
        {
            int answer = 0;
            if (root == null)
            {
                return 0;
            }
            SumNumbersInternal(root, ref answer, 0);
            return answer;
        }

        private void SumNumbersInternal(BinaryTree root, ref int answer, int current)
        {
            if (root.Left == null && root.Right == null)
            {
                answer += (current * 10 + root.Value);
                return;
            }
            if (root.Left != null)
            {
                SumNumbersInternal(root.Left, ref answer, current * 10 + root.Value);
            }
            if (root.Right != null)
            {
                SumNumbersInternal(root.Right, ref answer, current * 10 + root.Value);
            }
        }

        public string SolveQuestion(string input)
        {
            return SumNumbers(input.ToBinaryTree()).ToString();
        }

        [TestMethod]
        public void Q129_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q129_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
