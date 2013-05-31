using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given a binary tree and a sum, determine if the tree has a root-to-leaf path 
// such that adding up all the values along the path equals the given sum.
   
// For example:
// Given the below binary tree and sum = 22,
//               5
//              / \
//             4   8
//            /   / \
//           11  13  4
//          /  \      \
//         7    2      1
// return true, as there exist a root-to-leaf path 5->4->11->2 which sum is 22.

namespace LeetSharp
{
    [TestClass]
    public class Q112_PathSum
    {
        public bool HasPathSum(BinaryTree root, int sum)
        {
            if (root == null)
            {
                return false;
            }
            int remaining = sum - root.Value;
            if (remaining == 0 && root.Left == null && root.Right == null)
            {
                return true;
            }
            return HasPathSum(root.Left, remaining) || HasPathSum(root.Right, remaining);
        }

        public string SolveQuestion(string input)
        {
            return HasPathSum(input.GetToken(0).ToBinaryTree(), input.GetToken(1).ToInt()).ToString().ToLower();
        }

        [TestMethod]
        public void Q112_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q112_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
