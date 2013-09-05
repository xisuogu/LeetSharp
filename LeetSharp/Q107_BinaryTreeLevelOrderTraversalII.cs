using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given a binary tree, return the bottom-up level order traversal of its nodes' values. 
// (ie, from left to right, level by level from leaf to root).

// For example:
// Given binary tree {3,9,20,#,#,15,7},

//     3
//    / \
//   9  20
//     /  \
//    15   7
// return its bottom-up level order traversal as:

// [
//   [15,7]
//   [9,20],
//   [3],
// ]

namespace LeetSharp
{
    [TestClass]
    public class Q107_BinaryTreeLevelOrderTraversalII
    {
        public int[][] LevelOrderBottomII(BinaryTree root)
        {
            Stack<int[]> results = new Stack<int[]>();
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

        private void ProcessQueue(Stack<int[]> results, Queue<BinaryTree> queue1, Queue<BinaryTree> queue2)
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
                results.Push(resultInOneLevel.ToArray());
        }

        public string SolveQuestion(string input)
        {
            return TestHelper.Serialize(LevelOrderBottomII(input.ToBinaryTree()));
        }

        [TestMethod]
        public void Q107_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q107_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
