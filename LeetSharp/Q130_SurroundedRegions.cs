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
            return null;
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
