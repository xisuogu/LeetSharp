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
        public BinaryTree[] GenerateTrees(int n)
        {
            int[] input = Enumerable.Range(1, n).ToArray();
            List<BinaryTree> trees = GenerateTree(input, 0, n - 1);

            return trees.ToArray();
        }

        public List<BinaryTree> GenerateTree(int[] input, int start, int end)
        {
            if (start > end)
            {
                return new List<BinaryTree> { null };
            }

            if (start == end)
            {
                BinaryTree tree = new BinaryTree(input[start]);
                return new List<BinaryTree> { tree };
            }

            List<BinaryTree> results = new List<BinaryTree>();
            for (int i = start; i <= end; i++)
            {
                List<BinaryTree> left = GenerateTree(input, start, i - 1);
                List<BinaryTree> right = GenerateTree(input, i + 1, end);
                                
                foreach (var leftTree in left)
                {
                    foreach (var rightTree in right)
                    {
                        BinaryTree current = new BinaryTree(input[i]);
                        current.Left = leftTree;
                        current.Right = rightTree;
                        results.Add(current);
                    }
                }
            }
            return results;
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
