using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// The n-queens puzzle is the problem of placing n queens on an n�n chessboard such that no two queens attack each other.
// Given an integer n, return all distinct solutions to the n-queens puzzle.

// Each solution contains a distinct board configuration of the n-queens' placement, where 'Q' and '.' both indicate a queen and an empty space respectively.

// For example,
// There exist two distinct solutions to the 4-queens puzzle:

//[
// [".Q..",  // Solution 1
//  "...Q",
//  "Q...",
//  "..Q."],

// ["..Q.",  // Solution 2
//  "Q...",
//  "...Q",
//  ".Q.."]
//]

namespace LeetSharp
{
    [TestClass]
    public class Q051_NQueens
    {
        public string[][] SolveNQueens(int n)
        {
            return null;
        }

        public string SolveQuestion(string input)
        {
            return TestHelper.Serialize(SolveNQueens(input.ToInt()));
        }

        [TestMethod]
        public void Q051_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q051_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
