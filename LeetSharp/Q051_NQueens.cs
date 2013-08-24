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
            List<int[]> result = new List<int[]>();
            int[] data = new int[n];
            SolveNQueensRecursive(0, data, result);
            return ConvertToStringArrayArray(result, n);
        }

        private string[][] ConvertToStringArrayArray(List<int[]> result, int n)
        {
            List<string[]> strArrList = new List<string[]>();
            foreach (int[] res in result)
            {
                string[] strArr = new string[n];
                for (int i = 0; i < n; i++)
                {
                    int pos = res[i];
                    strArr[i] = new string('.', pos) + 'Q' + new string('.', n - 1 - pos);
                }
                strArrList.Add(strArr);
            }

            return strArrList.ToArray();
        }

        private void SolveNQueensRecursive(int row, int[] data, List<int[]> result)
        {
            if (row == data.Length)
            {
                result.Add(data.ToArray());
                return;
            }

            for (int col = 0; col < data.Length; col++)
            {
                if (IsValid(data, row, col))
                {
                    data[row] = col;
                    SolveNQueensRecursive(row + 1, data, result);
                }
            }
        }

        private bool IsValid(int[] data, int row, int col)
        {
            for (int i = 0; i < row; i++)
            {
                if (data[i] == col || Math.Abs(data[i] - col) == row - i)
                    return false;
            }
            return true; 
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
