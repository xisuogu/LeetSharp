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
            BinaryTree n1 = null;
            BinaryTree n2 = null;
            bool findingN2 = false;
            int last = int.MinValue;
            foreach (var cur in root.InOrderBinaryTree())
            {
                if (cur.Value <= last) // desending
                {
                    n2 = cur;
                    findingN2 = true;
                }
                else
                {
                    if (!findingN2)
                    {
                        n1 = cur;
                    }
                }
                last = cur.Value;
            }

            int tmp = n1.Value;
            n1.Value = n2.Value;
            n2.Value = tmp;
            return root;
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
