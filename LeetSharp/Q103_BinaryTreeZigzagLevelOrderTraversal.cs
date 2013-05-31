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
            List<int[]> result = new List<int[]>();
            var s1 = new Stack<BinaryTree>();
            var s2 = new Stack<BinaryTree>();
            int level = 0;
            if (root != null)
            {
                s1.Push(root);
            }
            while (s1.Count > 0 || s2.Count > 0)
            {
                var currentStack = level % 2 == 0 ? s1 : s2;
                var nextStack = level % 2 == 1 ? s1 : s2;
                List<int> levelEle = new List<int>();
                while (currentStack.Count > 0)
                {
                    var node = currentStack.Pop();
                    levelEle.Add(node.Value);
                    if (level % 2 == 0)
                    {
                        if (node.Left != null)
                        {
                            nextStack.Push(node.Left);
                        }
                        if (node.Right != null)
                        {
                            nextStack.Push(node.Right);
                        }
                    }
                    else
                    {
                        if (node.Right != null)
                        {
                            nextStack.Push(node.Right);
                        }
                        if (node.Left != null)
                        {
                            nextStack.Push(node.Left);
                        }
                    }
                }
                result.Add(levelEle.ToArray());
                level++;
            }
            return result.ToArray();
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
