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
            bool[,] visited = new bool[board.Length, board[0].Length];
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[0].Length; j++)
                {                    
                    if (Dfs(board, word, visited, i, j, 0))
                        return true;
                }
            }

            return false;
        }

        private bool Dfs(string[] board, string word, bool[,] visited, int i, int j, int level)
        {
            if (i < 0 || i >= board.Length || j < 0 || j >= board[0].Length)
                return false;

            if (visited[i, j] == true || board[i][j] != word[level])
                return false;

            if (level == word.Length - 1)
                return true;

            visited[i, j] = true;

            bool ret = Dfs(board, word, visited, i - 1, j, level + 1) 
                || Dfs(board, word, visited, i, j - 1, level + 1)
                || Dfs(board, word, visited, i + 1, j, level + 1)
                || Dfs(board, word, visited, i, j + 1, level + 1);

            visited[i, j] = false;

            return ret;
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
