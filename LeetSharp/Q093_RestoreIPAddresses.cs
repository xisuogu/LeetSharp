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
        private bool IsValid(string s)
        {
            int num;
            if (int.TryParse(s, out num))
            {
                return num.ToString() == s 
                    && num >= 0 && num <= 255;
            }
            return false;
        }

        public string[] RestoreIpAddresses(string s)
        {
            List<string> results = new List<string>();
            RestoreIpAddresses(s, 4, results, string.Empty);
            return results.ToArray();
        }

        private void RestoreIpAddresses(string s, int level, List<string> results, string data)
        {
            if (level == 0)
            {
                if (s == string.Empty)
                    results.Add(data.TrimEnd('.'));
                return;
            }

            if (s.Length > 3 * level || s.Length < level)
                return;

            for (int i = 1; i <= 3; i++)
            {
                if (s.Length >= i && IsValid(s.Substring(0, i)))
                {
                    RestoreIpAddresses(s.Substring(i), level - 1, results, data + s.Substring(0, i) + ".");
                }
            }
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
