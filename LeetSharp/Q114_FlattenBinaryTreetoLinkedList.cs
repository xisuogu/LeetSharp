using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given a binary tree, flatten it to a linked list in-place.
   
// For example,
// Given
   
//          1
//         / \
//        2   5
//       / \   \
//      3   4   6
// The flattened tree should look like:
//    1
//     \
//      2
//       \
//        3
//         \
//          4
//           \
//            5
//             \
//              6

namespace LeetSharp
{
    [TestClass]
    public class Q114_FlattenBinaryTreetoLinkedList
    {
        public BinaryTree Flatten(BinaryTree root)
        {
            BinaryTree p = root;
            while (p != null)
            {
                BinaryTree rightMostNode = p.Left;
                if (rightMostNode != null)
                {
                    while (rightMostNode.Right != null)
                        rightMostNode = rightMostNode.Right;

                    rightMostNode.Right = p.Right;
                    p.Right = p.Left;
                    p.Left = null;
                }

                p = p.Right;
            }

            return root;
        }

        public string SolveQuestion(string input)
        {
            return Flatten(input.ToBinaryTree()).SerializeBinaryTree();
        }

        [TestMethod]
        public void Q114_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q114_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
