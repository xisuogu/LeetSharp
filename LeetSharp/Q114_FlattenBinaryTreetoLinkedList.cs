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
            if (root == null)
            {
                return null;
            }
            root.Left = Flatten(root.Left);
            root.Right = Flatten(root.Right);
            if (root.Left == null)
            {
                return root;
            }
            var rightMostInLeft = root.Left;
            while (rightMostInLeft.Right != null)
            {
                rightMostInLeft = rightMostInLeft.Right;
            }
            rightMostInLeft.Right = root.Right;
            root.Right = root.Left;
            root.Left = null;
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
