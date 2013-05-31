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
            // get empty positions
            List<Tuple<int, int>> emptyPos = new List<Tuple<int, int>>();
            for (int r = 0; r < 9; r++)
            {
                for (int c = 0; c < 9; c++)
                {
                    if (board[c, r] == 0)
                    {
                        emptyPos.Add(Tuple.Create(c, r));
                    }
                }
            }

            int currentStep = 0;
            board[emptyPos[0].Item1, emptyPos[0].Item2] = 1;
            bool backfill = false;
            while (currentStep >= 0)
            {
                if (backfill || !IsBoardValidSlim(board, emptyPos[currentStep].Item1, emptyPos[currentStep].Item2))
                {
                    var pos = emptyPos[currentStep];
                    if (board[pos.Item1, pos.Item2] == 9)
                    {
                        board[pos.Item1, pos.Item2] = 0;
                        currentStep--;
                        backfill = true;
                    }
                    else
                    {
                        board[pos.Item1, pos.Item2]++;
                        backfill = false;
                    }
                }
                else
                {
                    if (++currentStep == emptyPos.Count)
                    {
                        return board; // found answer
                    }
                    board[emptyPos[currentStep].Item1, emptyPos[currentStep].Item2] = 1;
                }
            }
            return null;
        }

        private bool IsBoardValidSlim(int[,] board, int currentC, int currentR)
        {
            HashSet<int> hset = new HashSet<int>();
            // check row
            for (int c = 0; c < 9; c++)
            {
                int cell = board[c, currentR];
                if (cell != 0 && !hset.Add(cell))
                {
                    return false;
                }
            }
            // check column
            hset.Clear();
            for (int r = 0; r < 9; r++)
            {
                int cell = board[currentC, r];
                if (cell != 0 && !hset.Add(cell))
                {
                    return false;
                }
            }
            // check block
            int cStart = (currentC / 3) * 3;
            int rStart = (currentR / 3) * 3;
            hset.Clear();
            for (int r = rStart; r < rStart + 3; r++)
            {
                for (int c = cStart; c < cStart + 3; c++)
                {
                    int cell = board[c, r];
                    if (cell != 0 && !hset.Add(cell))
                    {
                        return false;
                    }
                }
            }
            return true;
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
