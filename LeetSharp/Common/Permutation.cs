using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetSharp
{
    public class Permutation
    {
        public static IEnumerable<T[]> SwapPermute<T>(T[] input)
        {
            var result = new List<T[]>();
            SwapPermuteInternal(ref input, 0, result);
            return result;
        }

        private static void SwapPermuteInternal<T>(ref T[] input, int level, List<T[]> result)
        {
            if (input.Length - 1 == level)
            {
                result.Add(input.ToArray());
            }
            else
            {
                for (int i = level; i < input.Length; i++)
                {
                    Swap(ref input, level, i);
                    SwapPermuteInternal(ref input, level + 1, result);
                    Swap(ref input, level, i);
                }
            }
        }

        private static void Swap<T>(ref T[] input, int level, int i)
        {
            if (level != i)
            {
                var temp = input[level];
                input[level] = input[i];
                input[i] = temp;
            }
        }
    }
}
