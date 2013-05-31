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
        public bool IsValidSudoku(int[,] board)
        {
            HashSet<int> hset = new HashSet<int>();
            // row validation
            for (int r = 0; r < 9; r++)
            {
                hset.Clear();
                for (int c = 0; c < 9; c++)
                {
                    int cell = board[c, r];
                    if (cell != 0 && !hset.Add(cell))
                    {
                        return false;
                    }
                }
            }
            // column validation
            for (int c = 0; c < 9; c++)
            {
                hset.Clear();
                for (int r = 0; r < 9; r++)
                {
                    int cell = board[c, r];
                    if (cell != 0 && !hset.Add(cell))
                    {
                        return false;
                    }
                }
            }
            // 9 blocks validation
            for (int b = 0; b < 9; b++)
            {
                int cStart = (b % 3) * 3;
                int rStart = (b / 3) * 3;
                hset.Clear();
                for (int c = cStart; c < cStart + 3; c++)
                {
                    for (int r = rStart; r < rStart + 3; r++)
                    {
                        int cell = board[c, r];
                        if (cell != 0 && !hset.Add(cell))
                        {
                            return false;
                        }
                    }
                }
            }
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
