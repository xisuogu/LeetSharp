using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given an absolute path for a file (Unix-style), simplify it.

// For example,
// path = "/home/", => "/home"
// path = "/a/./b/../../c/", => "/c"

// Corner Cases:
//  Did you consider the case where path = "/../"?
//  In this case, you should return "/".
//  Another corner case is the path might contain multiple slashes '/' together, such as "/home//foo/".
//  In this case, you should ignore redundant slashes and return "/home/foo".

namespace LeetSharp
{
    [TestClass]
    public class Q071_SimplifyPath
    {
        public string SimplifyPath(string path)
        {
            return null;
        }

        public string SolveQuestion(string input)
        {
            return "\"" + SimplifyPath(input.Deserialize()) + "\"";
        }

        [TestMethod]
        public void Q071_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q071_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
