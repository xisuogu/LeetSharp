using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given a binary tree
   
//     struct TreeLinkNode {
//       TreeLinkNode *left;
//       TreeLinkNode *right;
//       TreeLinkNode *next;
//     }
// Populate each next pointer to point to its next right node. If there is no next right node, the next pointer should be set to NULL.
   
// Initially, all next pointers are set to NULL.
   
// Note:
   
// You may only use constant extra space.
// You may assume that it is a perfect binary tree (ie, all leaves are at the same level, and every parent has two children).
// For example,
// Given the following perfect binary tree,
   
//          1
//        /  \
//       2    3
//      / \  / \
//     4  5  6  7
// After calling your function, the tree should look like:
   
//          1 -> NULL
//        /  \
//       2 -> 3 -> NULL
//      / \  / \
//     4->5->6->7 -> NULL

namespace LeetSharp
{
    [TestClass]
    public class Q116_PopulatingNextRightPointersinEachNode
    {
        public TreeNodeWithNext Connect(BinaryTree input)
        {
            return null;
        }

        public string SolveQuestion(string input)
        {
            return Connect(input.ToBinaryTree()).SerializeTreeNodeWithNext();
        }

        [TestMethod]
        public void Q116_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q116_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
