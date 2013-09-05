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
        private void PushLeftNodesIntoStack(BinaryTree node, Stack<BinaryTree> stack)
        {
            if (node != null)
            {
                stack.Push(node);
                while (node.Left != null)
                {
                    stack.Push(node.Left);
                    node = node.Left;
                }
            }
        }

        public int[] InorderTraversal2(BinaryTree root)
        {
            Stack<BinaryTree> stack = new Stack<BinaryTree>();
            PushLeftNodesIntoStack(root, stack);

            List<int> result = new List<int>();
            while (stack.Count != 0)
            {
                var item = stack.Pop();
                result.Add(item.Value);
                PushLeftNodesIntoStack(item.Right, stack);
            }
            return result.ToArray();
        }

        // Review: How to do preorder and postorder ??? 
        public int[] InorderTraversal(BinaryTree root)
        {
            List<int> result = new List<int>();
            Stack<BinaryTree> stack = new Stack<BinaryTree>();
            BinaryTree current = root;
            while (stack.Count > 0 || current != null)
            {
                if (current != null)
                {
                    stack.Push(current);
                    current = current.Left;
                }
                else
                {
                    current = stack.Pop();
                    result.Add(current.Value);
                    current = current.Right;
                }
            }
            return result.ToArray();
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
