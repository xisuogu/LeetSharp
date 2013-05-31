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
        // interval: start, end
        // sample input: [[1,4],[1,5]] -- 2 interval, (1, 4) (1, 5)
        public int[][] Merge(int[][] intervals)
        {
            List<int[]> result = new List<int[]>();
            // order by start first
            var tuples = intervals.Select(i => Tuple.Create(i[0], i[1])).OrderBy(t => t.Item1).ToArray();
            if (tuples.Length == 0)
            {
                return result.ToArray();
            }
            int currentStart = tuples[0].Item1;
            int currentEnd = tuples[0].Item2;
            for (int i = 1; i < tuples.Length; i++)
            {
                var currentTuple = tuples[i];
                if (currentTuple.Item1 > currentEnd) // no overlap with previous
                {
                    result.Add(new int[] { currentStart, currentEnd });
                    currentStart = currentTuple.Item1;
                    currentEnd = currentTuple.Item2;
                }
                else
                {
                    currentEnd = Math.Max(currentEnd, currentTuple.Item2);
                }
            }
            result.Add(new int[] { currentStart, currentEnd });
            return result.ToArray();
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
