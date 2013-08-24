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
            bool inserted = false;
            List<int[]> resultList = new List<int[]>();
            int min = 0, max = 0;
            for (int i = 0; i < intervals.Length; i++)
            {
                int[] interval = intervals[i];
                if (!inserted)
                {
                    if (newInterval[1] < interval[0])
                    {
                        resultList.Add(newInterval);
                        resultList.Add(interval);
                        inserted = true;
                    }
                    else if (newInterval[0] > interval[1])
                    {
                        resultList.Add(interval);
                    }
                    else
                    {
                        min = Math.Min(interval[0], newInterval[0]);
                        max = Math.Max(interval[1], newInterval[1]);
                        resultList.Add(new int[] { min, max });
                        inserted = true;
                    }
                }
                else
                {
                    if (interval[0] <= max)
                    {
                        max = Math.Max(max, interval[1]);
                        resultList[resultList.Count - 1][1] = max;
                    }
                    else
                    {
                        resultList.Add(interval);
                    }
                }
            }

            if (!inserted)
                resultList.Add(newInterval);

            return resultList.ToArray();
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
