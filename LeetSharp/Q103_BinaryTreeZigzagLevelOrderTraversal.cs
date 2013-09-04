using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given a binary tree, return the zigzag level order traversal of its nodes' values.
// (ie, from left to right, then right to left for the next level and alternate between).

// For example:
// Given binary tree {3,9,20,#,#,15,7},

//    3
//   / \
//  9  20
//    /  \
//   15   7
// return its zigzag level order traversal as:

// [
//  [3],
//  [20,9],
//  [15,7]
// ]

namespace LeetSharp
{
    [TestClass]
    public class Q103_BinaryTreeZigzagLevelOrderTraversal
    {
        public int[][] ZigzagLevelOrder(BinaryTree root)
        {            
            List<int[]> results = new List<int[]>();
            if (root != null)
            {
                Stack<BinaryTree> stack1 = new Stack<BinaryTree>();
                Stack<BinaryTree> stack2 = new Stack<BinaryTree>();

                stack1.Push(root);
                while (stack1.Count > 0 || stack2.Count > 0)
                {
                    ProcessQueue(results, stack1, stack2, false);
                    ProcessQueue(results, stack2, stack1, true);
                }
            }

            return results.ToArray();
        }

        private void ProcessQueue(List<int[]> results, Stack<BinaryTree> stack1, Stack<BinaryTree> stack2, bool reverse)
        {
            List<int> resultInOneLevel = new List<int>();
            while (stack1.Count > 0)
            {
                BinaryTree tree = stack1.Pop();
                resultInOneLevel.Add(tree.Value);

                if (!reverse)
                {
                    if (tree.Left != null)
                        stack2.Push(tree.Left);
                    if (tree.Right != null)
                        stack2.Push(tree.Right);
                }
                else
                {
                    if (tree.Right != null)
                        stack2.Push(tree.Right);
                    if (tree.Left != null)
                        stack2.Push(tree.Left);
                }
            }
            if (resultInOneLevel.Count > 0)
                results.Add(resultInOneLevel.ToArray());
        }

        public string SolveQuestion(string input)
        {
            return TestHelper.Serialize(ZigzagLevelOrder(input.ToBinaryTree()));
        }

        [TestMethod]
        public void Q103_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q103_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
