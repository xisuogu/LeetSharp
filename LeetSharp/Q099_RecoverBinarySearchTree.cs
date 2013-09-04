using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Two elements of a binary search tree (BST) are swapped by mistake.

// Recover the tree without changing its structure.

// Note:
// A solution using O(n) space is pretty straight forward. Could you devise a constant space solution?

namespace LeetSharp
{
    [TestClass]
    public class Q099_RecoverBinarySearchTree
    {
        public BinaryTree RecoverTree(BinaryTree root)
        {
            BinaryTree first = null, second = null;
            int last = int.MinValue;

            Stack<BinaryTree> stack = new Stack<BinaryTree>();
            PushLeftNodesIntoStack(root, stack);

            while (stack.Count != 0)
            {
                var item = stack.Pop();

                if (item.Value < last)
                {
                    second = item;
                }
                else if (second == null)
                {
                    first = item;
                }

                last = item.Value;

                PushLeftNodesIntoStack(item.Right, stack);
            }

            int tempValue = first.Value;
            first.Value = second.Value;
            second.Value = tempValue;

            return root;
        }

        private void PushLeftNodesIntoStack(BinaryTree node, Stack<BinaryTree> stack)
        {
            if (node != null)
            {
                stack.Push(node);
                while (node.Left != null)
                {
                    stack.Push(node.Left);
                    node = node.Left;
                }
            }
        }

        public string SolveQuestion(string input)
        {
            return RecoverTree(input.ToBinaryTree()).SerializeBinaryTree();
        }

        [TestMethod]
        public void Q099_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q099_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
