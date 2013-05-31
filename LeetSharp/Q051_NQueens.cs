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
            SolveNQueensRec(n, result, 0, data);
            return ConvertToStringArrayArray(result, n);
        }

        private string[][] ConvertToStringArrayArray(List<int[]> results, int n)
        {
            List<string[]> ss = new List<string[]>();
            foreach (var res in results)
            {
                string[] s = new string[n];
                for (int r = 0; r < n; r++)
                {
                    int qIndex = res[r];
                    s[r] = new string('.', qIndex) + "Q" + new string('.', n - 1 - qIndex);
                }
                ss.Add(s);
            }
            return ss.ToArray();
        }

        private void SolveNQueensRec(int n, List<int[]> res, int level, int[] data)
        {
            for (int i = 0; i < n; i++)
            {
                // check previous row
                bool isValid = true;
                for (int r = 0; r < level; r++)
                {
                    if (data[r] == i || Math.Abs(i - data[r]) == (level - r))
                    {
                        isValid = false;
                        break;
                    }
                }
                if (isValid)
                {
                    data[level] = i;
                    if (level == n - 1)
                    {
                        res.Add(data.ToArray());
                    }
                    else
                    {
                        SolveNQueensRec(n, res, level + 1, data);
                    }
                }
            }
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
