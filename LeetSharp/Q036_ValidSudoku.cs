using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Determine if a Sudoku is valid, according to: Sudoku Puzzles - The Rules.

// The Sudoku board could be partially filled, where empty cells are filled with the character '.'.

namespace LeetSharp
{
    [TestClass]
    public class Q036_ValidSudoku
    {
        private HashSet<int> Init(int length)
        {
            HashSet<int> set = new HashSet<int>();
            for (int i = 0; i < length; i++)
                set.Add(i + 1);
            return set;
        }

        private bool IsValidSudoku_Straight(int[,] board, bool isRow)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                HashSet<int> set = Init(board.GetLength(0));
                for (int j = 0; j < board.GetLength(0); j++)
                {
                    int value = isRow ? board[i, j] : board[j, i];
                    if (value != 0 && !set.Remove(value))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private bool IsValidSudoku_Diagonal(int[,] board)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                int rStart = (i / 3) * 3;
                int cStart = (i % 3) * 3;

                HashSet<int> set = Init(board.GetLength(0));
                for (int r = rStart; r < rStart + 3; r++)
                {
                    for (int c = cStart; c < cStart + 3; c++)
                    {
                        int value = board[r, c];
                        if (value != 0 && !set.Remove(value))
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        public bool IsValidSudoku(int[,] board)
        {
            if (!IsValidSudoku_Straight(board, true))
                return false;

            if (!IsValidSudoku_Straight(board, false))
                return false;

            if (!IsValidSudoku_Diagonal(board))
                return false;

            return true;
        }

        public static int[,] ParseSudokuData(string s)
        {
            int[,] result = new int[9, 9];
            var tokens = s.TrimStart('[').TrimEnd(']').Split(',');
            for (int r = 0; r < 9; r++)
            {
                var token = tokens[r].Trim('"');
                for (int c = 0; c < 9; c++)
                {
                    result[c, r] = token[c] == '.' ? 0 : int.Parse(token[c].ToString());
                }
            }
            return result;
        }

        public string SolveQuestion(string input)
        {
            int[,] data = ParseSudokuData(input);
            return IsValidSudoku(data).ToString().ToLower();
        }

        [TestMethod]
        public void Q036_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q036_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
