using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given a binary tree, determine if it is height-balanced.

// For this problem, a height-balanced binary tree is defined as a binary tree in which the 
// depth of the two subtrees of every node never differ by more than 1.

namespace LeetSharp
{
    [TestClass]
    public class Q110_BalancedBinaryTree
    {
        // max depth - min depth <= 1
        public bool IsBalanced(BinaryTree root)
        {
            if (root == null)
            {
                return true;
            }
            if (!IsBalanced(root.Left))
            {
                return false;
            }
            if (!IsBalanced(root.Right))
            {
                return false;
            }
            return Math.Abs(MaxDepth(root.Left) - MaxDepth(root.Right)) <= 1;
        }

        public int MaxDepth(BinaryTree root)
        {
            if (root == null)
            {
                return 0;
            }
            return 1 + Math.Max(MaxDepth(root.Left), MaxDepth(root.Right));
        }

        public string SolveQuestion(string input)
        {
            return IsBalanced(input.ToBinaryTree()).ToString().ToLower();
        }

        [TestMethod]
        public void Q110_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q110_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
