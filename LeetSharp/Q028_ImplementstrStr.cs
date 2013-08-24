using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Implement strStr().

// Returns a pointer to the first occurrence of needle in haystack, or null if needle is not part of haystack.

namespace LeetSharp
{
    [TestClass]
    public class Q028_ImplementstrStr
    {
        public string StrStr(string haystack, string needle)
        {
            if (needle == string.Empty)
                return haystack;

            for (int i = 0; i < haystack.Length - needle.Length + 1; i++)
            {
                int hStart = i, nStart = 0;
                while (hStart < haystack.Length && nStart < needle.Length)
                {
                    if (needle[nStart] != haystack[hStart])
                    {
                        break;
                    }
                    hStart++;
                    nStart++;
                }
                if (nStart == needle.Length)
                    return haystack.Substring(hStart - needle.Length);
            }
            return null;
        }

        public string SolveQuestion(string input)
        {
            return StrStr(input.GetToken(0).Deserialize(), input.GetToken(1).Deserialize()).SerializeString();
        }

        [TestMethod]
        public void Q028_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q028_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
