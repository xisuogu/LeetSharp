using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// You are given an n x n 2D matrix representing an image.

// Rotate the image by 90 degrees (clockwise).

// Follow up:
// Could you do this in-place?

namespace LeetSharp
{
    [TestClass]
    public class Q048_RotateImage
    {
        public int[][] Rotate(int[][] matrix)
        {
            return null;
        }

        public string SolveQuestion(string input)
        {
            return TestHelper.Serialize(Rotate(input.ToIntArrayArray()));
        }

        [TestMethod]
        public void Q048_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q048_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
