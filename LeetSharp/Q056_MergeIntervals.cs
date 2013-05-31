using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given a collection of intervals, merge all overlapping intervals.

// For example,
// Given [1,3],[2,6],[8,10],[15,18],
// return [1,6],[8,10],[15,18].

namespace LeetSharp
{
    [TestClass]
    public class Q056_MergeIntervals
    {
        public int[][] Merge(int[][] intervals)
        {
            return null;
        }

        public string SolveQuestion(string input)
        {
            return TestHelper.Serialize(Merge(input.ToIntArrayArray()));
        }

        [TestMethod]
        public void Q056_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q056_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
