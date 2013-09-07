using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given a 2D board containing 'X' and 'O', capture all regions surrounded by 'X'.

// A region is captured by flipping all 'O's into 'X's in that surrounded region .

// For example,

// X X X X
// X O O X
// X X O X
// X O X X
// After running your function, the board should be:

// X X X X
// X X X X
// X X X X
// X O X X

namespace LeetSharp
{
    [TestClass]
    public class Q130_SurroundedRegions
    {
        public string[] Solve(string[] board)
        {
            if (board.Length == 0 || board[0].Length == 0)
                return board;

            char[][] charBoard = board.Select(x => x.ToCharArray()).ToArray();
            int height = charBoard.Length, width = charBoard[0].Length;
            bool[,] visited = new bool[height, width];

            for (int j = 0; j < width; j++)
            {
                BFS(charBoard, visited, 0, j);
                BFS(charBoard, visited, height - 1, j);
            }

            for (int i = 1; i < height - 1; i++)
            {
                BFS(charBoard, visited, i, 0);
                BFS(charBoard, visited, i, width - 1);
            }

            for (int i = 1; i < height - 1; i++)
            {
                for (int j = 1; j < width - 1; j++)
                {
                    if (charBoard[i][j] == 'O')
                        charBoard[i][j] = 'X';
                }
            }

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (charBoard[i][j] == 'T')
                        charBoard[i][j] = 'O';
                }
            }

            return charBoard.Select(x => new string(x)).ToArray();
        }

        private void BFS(char[][] board, bool[,] visited, int x, int y)
        {
            Queue<Tuple<int, int>> queue = new Queue<Tuple<int, int>>();
            queue.Enqueue(Tuple.Create(x, y));

            while (queue.Count > 0)
            {
                var item = queue.Dequeue();
                int currentX = item.Item1;
                int currentY = item.Item2;

                if (currentX < 0 || currentY < 0 || currentX >= board.Length || currentY >= board[0].Length)
                    continue;

                if (visited[currentX, currentY])
                    continue;

                visited[currentX, currentY] = true;
                if (board[currentX][currentY] == 'O')
                {
                    board[currentX][currentY] = 'T';
                    queue.Enqueue(Tuple.Create(currentX - 1, currentY));
                    queue.Enqueue(Tuple.Create(currentX + 1, currentY));
                    queue.Enqueue(Tuple.Create(currentX, currentY - 1));
                    queue.Enqueue(Tuple.Create(currentX, currentY + 1));
                }
            }
        }

        private void DFS(char[][] board, bool[,] visited, int x, int y)
        {
            if (x < 0 || x >= board.Length || y < 0 || y >= board[0].Length)
                return;

            if (visited[x, y])
                return;

            visited[x, y] = true;
            if (board[x][y] == 'O')
            {
                board[x][y] = 'T';
                DFS(board, visited, x - 1, y);
                DFS(board, visited, x + 1, y);
                DFS(board, visited, x, y - 1);
                DFS(board, visited, x, y + 1);
            }
        }

        public string SolveQuestion(string input)
        {
            return TestHelper.Serialize(Solve(input.ToStringArray()));
        }

        [TestMethod]
        public void Q130_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q130_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
