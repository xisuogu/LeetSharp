using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// The string "PAYPALISHIRING" is written in a zigzag pattern on a given number of rows like this:
// (you may want to display this pattern in a fixed font for better legibility)

// P   A   H   N
// A P L S I I G
// Y   I   R
// And then read line by line: "PAHNAPLSIIGYIR"
// Write the code that will take a string and make this conversion given a number of rows:

// string convert(string text, int nRows);
// convert("PAYPALISHIRING", 3) should return "PAHNAPLSIIGYIR".

namespace LeetSharp
{
    [TestClass]
    public class Q006_ZigZagConversion
    {
        public string Convert(string s, int nRows)
        {
            if (nRows == 1)
            {
                return s;
            }
            StringBuilder sb = new StringBuilder(s.Length);
            int hopSum = nRows * 2 - 2;
            for (int r = 0; r < nRows; r++)
            {
                // every line, hop1, hop2, hop1, hop2.... 
                // hop1 + hop2 = nRows * 2 -2
                // hop1 = n*2 - (r+1) * 2
                int startIndex = r;
                int hop = nRows * 2 - (r + 1) * 2;
                while (startIndex <= s.Length - 1)
                {
                    sb.Append(s[startIndex]);
                    if (hop == 0)
                    {
                        hop = hopSum - hop;
                    }
                    startIndex += hop;
                    hop = hopSum - hop;
                }
            }
            return sb.ToString();
        }

        public string SolveQuestion(string input)
        {
            return "\"" + Convert(input.GetToken(0).Deserialize(), input.GetToken(1).ToInt()) + "\"";
        }

        [TestMethod]
        public void Q006_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q006_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
