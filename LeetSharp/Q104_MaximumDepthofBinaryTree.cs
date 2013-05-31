using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given a binary tree, find its maximum depth.

// The maximum depth is the number of nodes along the longest path from the root node down to the farthest leaf node.

namespace LeetSharp
{
    [TestClass]
    public class Q104_MaximumDepthofBinaryTree
    {
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
            return MaxDepth(input.ToBinaryTree()).ToString();
        }

        [TestMethod]
        public void Q104_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q104_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
