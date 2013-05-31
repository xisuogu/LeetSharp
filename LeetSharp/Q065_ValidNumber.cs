using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Validate if a given string is numeric.

// Some examples:
// "0" => true
// " 0.1 " => true
// "abc" => false
// "1 a" => false
// "2e10" => true

// Note: It is intended for the problem statement to be ambiguous. 
// You should gather all requirements up front before implementing one.

namespace LeetSharp
{
    [TestClass]
    public class Q065_ValidNumber
    {
        public bool IsNumber(string s)
        {
            s = s.Trim();
            var tokens = s.Split('e');
            if (tokens.Length > 2)
            {
                return false;
            }
            bool hasDot = false;
            return tokens.All(token =>
            {
                if (token.Length == 0)
                {
                    return false;
                }
                int start = 0;
                if (token[0] == '-' || token[0] == '+')
                {
                    start = 1;
                }
                bool hasDigit = false;
                for (int i = start; i < token.Length; i++)
                {
                    if (!char.IsNumber(token[i]))
                    {
                        if (token[i] == '.' && !hasDot)
                        {
                            hasDot = true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else 
                    {
                        hasDigit = true;
                    }
                }
                hasDot = true; // 2nd part cannot contains dot
                return hasDigit;
            });
        }

        public string SolveQuestion(string input)
        {
            return IsNumber(input.Deserialize()).ToString().ToLower();
        }

        [TestMethod]
        public void Q065_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q065_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
