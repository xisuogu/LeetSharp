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
            var tup = MaxPathSumInternal(root);
            return tup.Item2;
        }

        // Item1, answer that including root, can be combine with upstream node, so it can only connect to 1 child
        // Item2, answer
        private Tuple<int, int> MaxPathSumInternal(BinaryTree root)
        {
            if (root == null)
            {
                return Tuple.Create(int.MinValue, int.MinValue);
            }
            var leftMax = MaxPathSumInternal(root.Left);
            var rightMax = MaxPathSumInternal(root.Right);

            int includeSelfAnswer = root.Value;
            int biggerChildChainAnswer = Math.Max(leftMax.Item1, rightMax.Item1);
            if (biggerChildChainAnswer > 0)
            {
                includeSelfAnswer += biggerChildChainAnswer;
            }

            int excludeSelfAnswer = Math.Max(leftMax.Item2, rightMax.Item2);
            int currentMaxAnswer = root.Value;
            currentMaxAnswer += Math.Max(0, leftMax.Item1);
            currentMaxAnswer += Math.Max(0, rightMax.Item1);
            int answer = Math.Max(excludeSelfAnswer, currentMaxAnswer);
            return Tuple.Create(includeSelfAnswer, answer);
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
