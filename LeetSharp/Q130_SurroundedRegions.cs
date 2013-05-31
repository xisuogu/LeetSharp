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
            {
                return board;
            }
            var charBoard = board.Select(s => s.ToCharArray()).ToArray();
            var newCharBoard = new char[board.Length][];
            for (int r = 0; r < board.Length; r++)
            {
                newCharBoard[r] = new String('X', board[0].Length).ToCharArray();
            }
            // check boarders
            int row = 0;
            for (int c = 0; c < charBoard[0].Length; c++)
            {
                FillFromBoarder(charBoard, newCharBoard, row, c);
            }
            row = charBoard.Length - 1;
            for (int c = 0; c < charBoard[0].Length; c++)
            {
                FillFromBoarder(charBoard, newCharBoard, row, c);
            }
            int column = 0;
            for (int r = 0; r < charBoard.Length; r++)
            {
                FillFromBoarder(charBoard, newCharBoard, r, column);
            }
            column = charBoard[0].Length - 1;
            for (int r = 0; r < charBoard.Length; r++)
            {
                FillFromBoarder(charBoard, newCharBoard, r, column);
            }

            return newCharBoard.Select(cs => new string(cs)).ToArray();
        }

        private void FillFromBoarder(char[][] charBoard, char[][] newCharBoard, int r, int c)
        {
            Queue<Tuple<int, int>> q = new Queue<Tuple<int, int>>();
            q.Enqueue(Tuple.Create(r, c));
            while (q.Count > 0)
            {
                var curPoint = q.Dequeue();
                int curRow = curPoint.Item1;
                int curCol = curPoint.Item2;
                if (curRow < 0 || curRow >= charBoard.Length || curCol < 0 || curCol >= charBoard[0].Length)
                {
                    continue;
                }
                if (charBoard[curRow][curCol] == 'O' && newCharBoard[curRow][curCol] == 'X')
                {
                    newCharBoard[curRow][curCol] = 'O';
                    q.Enqueue(Tuple.Create(curRow + 1, curCol));
                    q.Enqueue(Tuple.Create(curRow - 1, curCol));
                    q.Enqueue(Tuple.Create(curRow, curCol + 1));
                    q.Enqueue(Tuple.Create(curRow, curCol - 1));
                }
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
