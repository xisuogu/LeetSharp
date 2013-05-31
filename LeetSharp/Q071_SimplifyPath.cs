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
            Stack<string> pathStack = new Stack<string>();
            var tokens = path.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < tokens.Length; i++)
            {
                if (tokens[i] == "..")
                {
                    if (pathStack.Count > 0)
                    {
                        pathStack.Pop();
                    }
                }
                else if (tokens[i] != ".")
                {
                    pathStack.Push(tokens[i]);
                }
            }
            return "/" + String.Join("/", pathStack.Reverse().ToArray());
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
