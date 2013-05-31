using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given a binary tree, check whether it is a mirror of itself (ie, symmetric around its center).

// For example, this binary tree is symmetric:

//     1
//    / \
//   2   2
//  / \ / \
// 3  4 4  3
// But the following is not:

//     1
//    / \
//   2   2
//    \   \
//    3    3
// Note:
// Bonus points if you could solve it both recursively and iteratively.

namespace LeetSharp
{
    [TestClass]
    public class Q101_SymmetricTree
    {
        public bool IsSymmetric(BinaryTree root)
        {
            if (root == null)
            {
                return true;
            }
            var leftRight = root.InOrderBinaryTree().ToArray();
            if (leftRight.Length % 2 == 0)
            {
                return false;
            }
            var rightLeft = root.InOrderBinaryTreeRightToLeft().ToArray();
            for (int i = 0; i < leftRight.Length / 2; i++)
            {
                if (leftRight[i].Value != rightLeft[i].Value)
                {
                    return false;
                }
            }
            return true;
        }

        public string SolveQuestion(string input)
        {
            return IsSymmetric(input.ToBinaryTree()).ToString().ToLower();
        }

        [TestMethod]
        public void Q101_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q101_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
