using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given a binary tree, return the inorder traversal of its nodes' values.

// For example:
// Given binary tree {1,#,2,3},

//    1
//     \
//      2
//     /
//    3
// return [1,3,2].

// Note: Recursive solution is trivial, could you do it iteratively?

namespace LeetSharp
{
    [TestClass]
    public class Q094_BinaryTreeInorderTraversal
    {
        public int[] InorderTraversal(BinaryTree root)
        {
            List<int> result = new List<int>();
            InorderTraversalNonRec(root, result);
            return result.ToArray();
        }

        private void InorderTraversalNonRec(BinaryTree root, List<int> result)
        {
            if (root == null)
            {
                return;
            }
            Stack<BinaryTree> stack = new Stack<BinaryTree>();
            stack.Push(root);
            while (root.Left != null)
            {
                stack.Push(root.Left);
                root = root.Left;
            }
            while (stack.Count > 0)
            {
                var tmp = stack.Pop();
                result.Add(tmp.Value);
                if (tmp.Right != null)
                {
                    stack.Push(tmp.Right);
                    tmp = tmp.Right;
                    while (tmp.Left!= null)
                    {
                        stack.Push(tmp.Left);
                        tmp = tmp.Left;
                    }
                }
            }
        }

        private void InorderTraversalRec(BinaryTree root, List<int> result)
        {
            if (root == null)
            {
                return;
            }
            InorderTraversalRec(root.Left, result);
            result.Add(root.Value);
            InorderTraversalRec(root.Right, result);
        }

        public string SolveQuestion(string input)
        {
            return TestHelper.Serialize(InorderTraversal(input.ToBinaryTree()));
        }

        [TestMethod]
        public void Q094_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q094_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
