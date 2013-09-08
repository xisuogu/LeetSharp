using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetSharp
{
    [TestClass]
    public class Q133_LowestCommonAncestor
    {
        // http://leetcode.com/2011/07/lowest-common-ancestor-of-a-binary-tree-part-i.html
        // this solution doesn't work if node1 or node2 doesn't exist in the tree. 
        public BinaryTree FindLowestCommonAncestor(BinaryTree tree, int node1, int node2)
        {
            var result = LCA(tree, node1, node2);
            if (result != null)
                result.Left = result.Right = null;
            return result;
        }


        public BinaryTree LCA(BinaryTree tree, int node1, int node2)
        {
            if (tree == null)
                return null;

            if (tree.Value == node1 || tree.Value == node2)
                return tree;

            BinaryTree L = LCA(tree.Left, node1, node2);
            BinaryTree R = LCA(tree.Right, node1, node2);
            if (L != null && R != null)
                return tree;
            return L != null ? L : R;
        }

        /* Version 2

        private BinaryTree LCA(BinaryTree tree, int node1, int node2)
        {
            if (tree == null)
                return null;

            var left = LCA(tree.Left, node1, node2);
            if (left != null)
                return left;

            var right = LCA(tree.Right, node1, node2);
            if (right != null)
                return right;

            if (Cover(tree, node1) && Cover(tree, node2))
                return tree;

            return null;
        }

        private bool Cover(BinaryTree tree, int node)
        {
            if (tree == null)
                return false;

            if (tree.Value == node)
                return true;

            return Cover(tree.Left, node) || Cover(tree.Right, node);
        }
         */

        /* Version 1
        public struct ResultData
        {
            public BinaryTree Tree;
            public bool Node1Found;
            public bool Node2Found; 
        }

        public BinaryTree FindLowestCommonAncestor(BinaryTree tree, int node1, int node2)
        {
            int counting = 0;
            BinaryTree result = FindLowestCommonAncestor(tree, node1, node2, ref counting).Tree;
            if (result != null)
                result.Left = result.Right = null;
            return result;
        }

        private ResultData FindLowestCommonAncestor(BinaryTree tree, int node1, int node2, ref int counting)
        {
            ResultData result = new ResultData();

            if (tree == null)
                return result;

            if (tree.Value == node1)
            {
                counting++;
                result.Node1Found = true;
            }
            else if (tree.Value == node2)
            {
                counting++;
                result.Node2Found = true;
            }
            if (counting == 2)
            {
                return result;
            }

            ResultData temp = FindLowestCommonAncestor(tree.Left, node1, node2, ref counting);
            if (temp.Tree != null)
                return temp;

            result.Node1Found |= temp.Node1Found;
            result.Node2Found |= temp.Node2Found;

            if (result.Node1Found && result.Node2Found)
            {
                result.Tree = tree;
                return result;
            }

            temp = FindLowestCommonAncestor(tree.Right, node1, node2, ref counting);
            if (temp.Tree != null)
                return temp;

            result.Node1Found |= temp.Node1Found;
            result.Node2Found |= temp.Node2Found;

            if (result.Node1Found && result.Node2Found)
            {
                result.Tree = tree;
                return result;
            }

            return result;
        }
         */

        public string SolveQuestion(string input)
        {
            return FindLowestCommonAncestor(input.GetToken(0).ToBinaryTree(), input.GetToken(1).ToInt(), input.GetToken(2).ToInt()).SerializeBinaryTree();
        }

        [TestMethod]
        public void Q133_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
