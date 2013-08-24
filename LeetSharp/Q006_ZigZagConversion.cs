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
            if (nRows == 1 || string.IsNullOrEmpty(s))
                return s;

            string result = "";
            int hop1 = nRows * 2 - 2, hop2 = 0;
            for (int i = 0; i < nRows; i++)
            {
                bool swap = false;
                int index = i;
                while (index < s.Length)
                {
                    result += s[index];
                    if (hop1 == 0 || hop2 == 0)
                    {
                        index += Math.Max(hop1, hop2);
                    }
                    else
                    {
                        index += (swap ? hop2 : hop1);
                        swap = !swap;
                    }                    
                }
                hop1 -= 2;
                hop2 += 2;
            }
            return result;
        }

        #region QUEUE 
        public string Convert_Queue(string s, int nRows)
        {
            if (nRows == 1)
                return s;

            Queue<char>[] queues = new Queue<char>[nRows];
            for (int i = 0; i < nRows; i++)
                queues[i] = new Queue<char>();

            int index = 0;
            int flag = 1;
            
            foreach (char c in s)
            {
                queues[index].Enqueue(c);
                index += flag;
                
                if (index == nRows - 1)
                    flag = -1;
                else if (index == 0)
                    flag = 1;
            }
            string result = "";
            foreach (Queue<char> q in queues)
            {
                while (q.Count > 0)
                {
                    result += q.Dequeue();
                }
            }
            return result;
        }
        #endregion

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
