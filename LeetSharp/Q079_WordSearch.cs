using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given a 2D board and a word, find if the word exists in the grid.

// The word can be constructed from letters of sequentially adjacent cell,
// where "adjacent" cells are those horizontally or vertically neighboring. 
// The same letter cell may not be used more than once.

// For example,
// Given board =

// [
//   ["ABCE"],
//   ["SFCS"],
//   ["ADEE"]
// ]
// word = "ABCCED", -> returns true,
// word = "SEE", -> returns true,
// word = "ABCB", -> returns false.

namespace LeetSharp
{
    [TestClass]
    public class Q079_WordSearch
    {
        public bool Exist(string[] board, string word)
        {
            int height = board.Length;
            int width = board[0].Length;
            bool[,] visited = new bool[board.Length, board[0].Length];
            for (int r = 0; r < height; r++)
            {
                for (int c = 0; c < width; c++)
                {
                    if (board[r][c] == word[0])
                    {
                        if (Find(board, r, c, word, 0, visited))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private bool Find(string[] board, int rStart, int cStart, string word, int index, bool[,] visited)
        {
            if (rStart < 0 || rStart >= board.Length || cStart< 0 || cStart >= board[0].Length)
            {
                return false;
            }
            if (visited[rStart, cStart] || board[rStart][cStart] != word[index])
            {
                return false;
            }
            if (index == word.Length - 1)
            {
                return true;
            }
            visited[rStart, cStart] = true;
            // find 4 directions
            bool result = Find(board, rStart - 1, cStart, word, index + 1, visited) ||
                Find(board, rStart + 1, cStart, word, index + 1, visited) ||
                Find(board, rStart, cStart - 1, word, index + 1, visited) ||
                Find(board, rStart, cStart + 1, word, index + 1, visited);
            visited[rStart, cStart] = false;
            return result;
        }

        public string SolveQuestion(string input)
        {
            return Exist(input.GetToken(0).ToStringArray(), input.GetToken(1).Deserialize()).ToString().ToLower();
        }

        [TestMethod]
        public void Q079_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q079_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
