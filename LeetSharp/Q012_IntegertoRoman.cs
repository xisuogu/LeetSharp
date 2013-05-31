using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given an integer, convert it to a roman numeral.

// Input is guaranteed to be within the range from 1 to 3999.

namespace LeetSharp
{
    [TestClass]
    public class Q012_IntegertoRoman
    {
        public string IntToRoman(int num)
        {
            return null;
        }

        public string SolveQuestion(string input)
        {
            return "\"" + IntToRoman(input.ToInt()) + "\"";
        }

        [TestMethod]
        public void Q012_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q012_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
