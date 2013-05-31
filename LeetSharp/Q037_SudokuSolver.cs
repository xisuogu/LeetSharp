using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Write a program to solve a Sudoku puzzle by filling the empty cells.

// Empty cells are indicated by the character '.'.

// You may assume that there will be only one unique solution.

namespace LeetSharp
{
    [TestClass]
    public class Q037_SudokuSolver
    {
        public int[,] SolveSudoku(int[,] board)
        {
            return null;
        }

        private string SerializeSodoku(int[,] board)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            for (int r = 0; r < 9; r++)
            {
                sb.Append("\"");
                for (int c = 0; c < 9; c++)
                {
                    sb.Append(board[c, r].ToString());
                }
                sb.Append("\",");
            }
            return sb.ToString().TrimEnd(',') + "]";
        }

        public string SolveQuestion(string input)
        {
            int[,] data = Q036_ValidSudoku.ParseSudokuData(input);
            return SerializeSodoku(SolveSudoku(data));
        }

        [TestMethod]
        public void Q037_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q037_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
