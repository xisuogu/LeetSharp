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
            if (intervals.Length == 0)
                return intervals;

            List<int[]> resultList = new List<int[]>();
            List<int[]> orderedList = intervals.OrderBy(x => x[0]).ToList();

            int currentIndex = 0;
            resultList.Add(orderedList[0]);
            for (int i = 1; i < orderedList.Count; i++)
            {
                int[] interval = orderedList[i];
                if (interval[0] <= resultList[currentIndex][1])
                {
                    resultList[currentIndex][1] = Math.Max(interval[1], resultList[currentIndex][1]);
                }
                else
                {
                    resultList.Add(interval);
                    currentIndex++;
                }
            }

            return resultList.ToArray();
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
