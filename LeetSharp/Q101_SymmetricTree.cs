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
                return true;
            
            Stack<BinaryTree> stack1 = new Stack<BinaryTree>();
            Stack<BinaryTree> stack2 = new Stack<BinaryTree>();
            BinaryTree current1 = root.Left;
            BinaryTree current2 = root.Right;

            while (stack1.Count > 0 || current1 != null)
            {
                if (current1 != null)
                {
                    if (current2 == null)
                        return false;

                    stack1.Push(current1);
                    stack2.Push(current2);

                    current1 = current1.Left;
                    current2 = current2.Right;
                }
                else
                {
                    if (current2 != null)
                        return false;

                    current1 = stack1.Pop();
                    current2 = stack2.Pop();

                    if (current1.Value != current2.Value)
                        return false; 

                    current1 = current1.Right;
                    current2 = current2.Left;
                }
            }

            if (stack2.Count > 0 || current2 != null)
                return false;

            return true; 
        }

        public bool IsSymmetric2(BinaryTree root)
        {
            if (root == null)
                return true;

            var leftToRight = root.InOrderBinaryTree().ToList();
            if (leftToRight.Count % 2 == 0)
                return false;

            var rightToLeft = root.InOrderBinaryTreeRightToLeft().ToList();
            for (int i = 0; i < leftToRight.Count / 2; i++)
            {
                if (leftToRight[i].Value != rightToLeft[i].Value)
                    return false;
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
