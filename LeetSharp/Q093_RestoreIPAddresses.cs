using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given a string containing only digits, restore it by returning all possible valid IP address combinations.

// For example:
// Given "25525511135",

// return ["255.255.11.135", "255.255.111.35"]. (Order does not matter)

namespace LeetSharp
{
    [TestClass]
    public class Q093_RestoreIPAddresses
    {
        public string[] RestoreIpAddresses(string s)
        {
            List<string> result = new List<string>();
            RestoreIpAddressesInternal(s, 0, 1, result, "");
            return result.ToArray();
        }

        private void RestoreIpAddressesInternal(string s, int startingIndex, int level, List<string> result,
            string current)
        {
            int remainingCharCount = s.Length - startingIndex;
            if (remainingCharCount < (5 - level) || remainingCharCount > 3 * (5 - level))
            {
                // too many or too few
                return;
            }
            if (level == 4)
            {
                if (IsValidIpPart(s.Substring(startingIndex)))
                {
                    result.Add(current + s.Substring(startingIndex));
                }
            }
            else
            {
                for (int i = 1; i <= 3; i++)
                {
                    if (remainingCharCount >= i && IsValidIpPart(s.Substring(startingIndex, i)))
                    {
                        RestoreIpAddressesInternal(s, startingIndex + i, level + 1, result,
                            current + s.Substring(startingIndex, i) + ".");
                    }
                }
            }
        }

        private bool IsValidIpPart(string part)
        {
            if (part.Length <= 0 || part.Length > 3)
            {
                return false;
            }
            int tmp = 0;
            if (!int.TryParse(part, out tmp))
            {
                return false;
            }
            if (tmp > 255)
            {
                return false;
            }
            return part == tmp.ToString();
        }

        public string SolveQuestion(string input)
        {
            return TestHelper.Serialize(RestoreIpAddresses(input.Deserialize()));
        }

        [TestMethod]
        public void Q093_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q093_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
