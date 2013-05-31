using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given a set of non-overlapping intervals, insert a new interval into the intervals (merge if necessary).

// You may assume that the intervals were initially sorted according to their start times.

// Example 1:
// Given intervals [1,3],[6,9], insert and merge [2,5] in as [1,5],[6,9].

// Example 2:
// Given [1,2],[3,5],[6,7],[8,10],[12,16], insert and merge [4,9] in as [1,2],[3,10],[12,16].

// This is because the new interval [4,9] overlaps with [3,5],[6,7],[8,10].

namespace LeetSharp
{
    [TestClass]
    public class Q057_InsertInterval
    {
        public int[][] Insert(int[][] intervals, int[] newInterval)
        {
            List<int[]> result = new List<int[]>();
            var tuples = intervals.Select(i => Tuple.Create(i[0], i[1])).ToArray();
            int mergedLow = newInterval[0];
            int mergedHigh = newInterval[1];
            bool mergedWritten = false;
            for (int i = 0; i < tuples.Length; i++)
            {
                var currentTuple = tuples[i];
                if (currentTuple.Item1 > mergedHigh) // curent token is ahead merging one, merging complete
                {
                    if (!mergedWritten)
                    {
                        mergedWritten = true;
                        result.Add(new int[] { mergedLow, mergedHigh });
                    }
                    result.Add(new int[] { currentTuple.Item1, currentTuple.Item2 });
                }
                else if (currentTuple.Item2 < mergedLow)
                {
                    result.Add(new int[] { currentTuple.Item1, currentTuple.Item2 });
                }
                else // current tuple has overlap with merging one
                {
                    mergedLow = Math.Min(mergedLow, currentTuple.Item1);
                    mergedHigh = Math.Max(mergedHigh, currentTuple.Item2);
                }
            }
            if (!mergedWritten) // from inmerging to non-imerging
            {
                result.Add(new int[] { mergedLow, mergedHigh });
            }
            return result.ToArray();
        }

        public string SolveQuestion(string input)
        {
            return TestHelper.Serialize(Insert(input.GetToken(0).ToIntArrayArray(), input.GetToken(1).ToIntArray()));
        }

        [TestMethod]
        public void Q057_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q057_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
