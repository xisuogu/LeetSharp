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
            Stack<int[]> result = new Stack<int[]>();
            if (root == null)
            {
                return result.ToArray();
            }
            Queue<BinaryTree> q = new Queue<BinaryTree>();
            q.Enqueue(root);
            q.Enqueue(null); // indicate end of level
            List<int> tmp = new List<int>();
            while (q.Count > 0)
            {
                var cur = q.Dequeue();
                if (cur == null)
                {
                    result.Push(tmp.ToArray());
                    tmp = new List<int>();
                    if (q.Count == 0) // end of tree
                    {
                        break;
                    }
                    q.Enqueue(null); // end of level
                }
                else
                {
                    tmp.Add(cur.Value);
                    if (cur.Left != null)
                    {
                        q.Enqueue(cur.Left);
                    }
                    if (cur.Right != null)
                    {
                        q.Enqueue(cur.Right);
                    }
                }
            }
            return result.ToArray();
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
