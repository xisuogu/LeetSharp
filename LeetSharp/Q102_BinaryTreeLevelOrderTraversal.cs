using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given a binary tree, return the level order traversal of its nodes' values. (ie, from left to right, level by level).

// For example:
// Given binary tree {3,9,20,#,#,15,7},

//    3
//   / \
//  9  20
//    /  \
//   15   7
// return its level order traversal as:

// [
//  [3],
//  [9,20],
//  [15,7]
// ]

namespace LeetSharp
{
    [TestClass]
    public class Q102_BinaryTreeLevelOrderTraversal
    {
        public int[][] LevelOrder(BinaryTree root)
        {
            List<int[]> results = new List<int[]>();
            if (root != null)
            {
                Queue<BinaryTree> queue1 = new Queue<BinaryTree>();
                Queue<BinaryTree> queue2 = new Queue<BinaryTree>();

                queue1.Enqueue(root);
                while (queue1.Count > 0 || queue2.Count > 0)
                {
                    ProcessQueue(results, queue1, queue2);
                    ProcessQueue(results, queue2, queue1);
                }
            }

            return results.ToArray();
        }

        private void ProcessQueue(List<int[]> results, Queue<BinaryTree> queue1, Queue<BinaryTree> queue2)
        {
            List<int> resultInOneLevel = new List<int>();
            while (queue1.Count > 0)
            {
                BinaryTree tree = queue1.Dequeue();
                resultInOneLevel.Add(tree.Value);

                if (tree.Left != null)
                    queue2.Enqueue(tree.Left);
                if (tree.Right != null)
                    queue2.Enqueue(tree.Right);
            }
            if (resultInOneLevel.Count > 0)
                results.Add(resultInOneLevel.ToArray());
        }

        public string SolveQuestion(string input)
        {
            return TestHelper.Serialize(LevelOrder(input.ToBinaryTree()));
        }

        [TestMethod]
        public void Q102_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q102_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
