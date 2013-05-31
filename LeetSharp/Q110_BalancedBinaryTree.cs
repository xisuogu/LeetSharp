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
        public bool IsBalanced(BinaryTree root)
        {
            return false;
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
