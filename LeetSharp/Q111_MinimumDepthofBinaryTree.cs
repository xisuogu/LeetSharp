using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given a binary tree, find its minimum depth.

// The minimum depth is the number of nodes along the shortest path from the root node down to the nearest leaf node.

namespace LeetSharp
{
    [TestClass]
    public class Q111_MinimumDepthofBinaryTree
    {
        public int MinDepth(BinaryTree root)
        {
            if (root == null)
            {
                return 0;
            }
            return MinDepthRec(root);
        }

        private int MinDepthRec(BinaryTree root)
        {
            if (root == null)
            {
                return int.MaxValue;
            }
            if (root.Left == null && root.Right == null)
            {
                return 1;
            }
            return 1 + Math.Min(MinDepthRec(root.Left), MinDepthRec(root.Right));
        }

        public string SolveQuestion(string input)
        {
            return MinDepth(input.ToBinaryTree()).ToString();
        }

        [TestMethod]
        public void Q111_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q111_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
