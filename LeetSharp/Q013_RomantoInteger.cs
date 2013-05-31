using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given a roman numeral, convert it to an integer.

// Input is guaranteed to be within the range from 1 to 3999.

namespace LeetSharp
{
    [TestClass]
    public class Q013_RomantoInteger
    {
        Dictionary<string, int> lookup = RomanToIntLookup();

        int RomanToInt(string s)
        {
            return lookup[s];
        }

        static Dictionary<string, int> RomanToIntLookup()
        {
            Dictionary<string, int> res = new Dictionary<string, int>();
            Q012_IntegertoRoman c = new Q012_IntegertoRoman();
            for (int i = 1; i <= 3999; i++)
            {
                res[c.IntToRoman(i)] = i;
            }
            return res;
        }

        public string SolveQuestion(string input)
        {
            return RomanToInt(input.Deserialize()).ToString();
        }

        [TestMethod]
        public void Q013_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q013_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
