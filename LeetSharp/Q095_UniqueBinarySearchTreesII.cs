using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given n, generate all structurally unique BST's (binary search trees) that store values 1...n.

// For example,
// Given n = 3, your program should return all 5 unique BST's shown below.

//   1         3     3      2      1
//    \       /     /      / \      \
//     3     2     1      1   3      2
//    /     /       \                 \
//   2     1         2                 3

namespace LeetSharp
{
    [TestClass]
    public class Q095_UniqueBinarySearchTreesII
    {
        Dictionary<int, BinaryTree[]> cachedResults = new Dictionary<int, BinaryTree[]>();
        public BinaryTree[] GenerateTrees(int n)
        {
            cachedResults[0] = new BinaryTree[1] { null };
            cachedResults[1] = new BinaryTree[1] { new BinaryTree(1) };

            for (int i = 2; i <= n; i++) // get answer i: i+1 nodes
            {
                if (cachedResults.ContainsKey(i))
                {
                    continue;
                }
                // left part can have 0 - i-1 nodes, if i nodes in all
                List<BinaryTree> trees = new List<BinaryTree>();
                for (int left = 0; left <= i - 1; left++)
                {
                    var root = new BinaryTree(left + 1);
                    foreach (var possibleLeft in cachedResults[left])
                    {
                        foreach (var possibleRight in cachedResults[i - 1 - left])
                        {
                            root.Left = possibleLeft;
                            root.Right = CloneTree(possibleRight, left + 1);
                            trees.Add(CloneTree(root, 0));
                        }
                    }
                }
                cachedResults[i] = trees.ToArray();
            }

            return cachedResults[n];
        }

        private BinaryTree CloneTree(BinaryTree orig, int increment)
        {
            if (orig != null)
            {
                BinaryTree newRoot = new BinaryTree(orig.Value + increment);
                newRoot.Left = CloneTree(orig.Left, increment);
                newRoot.Right = CloneTree(orig.Right, increment);
                return newRoot;
            }
            return null;
        }

        public string SolveQuestion(string input)
        {
            return GenerateTrees(input.ToInt()).SerializeBinaryTreeArray();
        }

        [TestMethod]
        public void Q095_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q095_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
