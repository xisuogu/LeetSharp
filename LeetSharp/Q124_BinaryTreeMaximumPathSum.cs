using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given a binary tree, find the maximum path sum.

// The path may start and end at any node in the tree.

// For example:
// Given the below binary tree,

//       1
//      / \
//     2   3
// Return 6.

namespace LeetSharp
{
    [TestClass]
    public class Q124_BinaryTreeMaximumPathSum
    {
        public int MaxPathSum(BinaryTree root)
        {
            int max = int.MinValue;
            MaxPathSum(root, ref max);
            return max;
        }

        private int MaxPathSum(BinaryTree root, ref int max)
        {
            if (root == null)
                return 0;

            int left = MaxPathSum(root.Left, ref max);
            left = Math.Max(0, left);
            int right = MaxPathSum(root.Right, ref max);
            right = Math.Max(0, right);
            
            max = Math.Max(max, root.Value + left + right);
            return root.Value + Math.Max(left, right);
        }

        public string SolveQuestion(string input)
        {
            return MaxPathSum(input.ToBinaryTree()).ToString();
        }

        [TestMethod]
        public void Q124_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q124_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
