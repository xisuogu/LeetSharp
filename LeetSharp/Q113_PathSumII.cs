using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given a binary tree and a sum, find all root-to-leaf paths where each path's sum equals the given sum.
   
// For example:
// Given the below binary tree and sum = 22,
//               5
//              / \
//             4   8
//            /   / \
//           11  13  4
//          /  \    / \
//         7    2  5   1
// return
   
// [
//    [5,4,11,2],
//    [5,8,4,5]
// ]

namespace LeetSharp
{
    [TestClass]
    public class Q113_PathSumII
    {
        public int[][] PathSum(BinaryTree root, int sum)
        {
            return null;
        }

        public string SolveQuestion(string input)
        {
            return TestHelper.Serialize(PathSum(input.GetToken(0).ToBinaryTree(), input.GetToken(1).ToInt()));
        }

        [TestMethod]
        public void Q113_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q113_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
