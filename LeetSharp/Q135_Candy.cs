using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetSharp
{
    class Q135_Candy
    {
        public int Candy(List<int> ratings)
        {
            List<int> list = new List<int>();
            list.ForEach(x => x = 1);

            for (int i = 1; i < ratings.Count; i++)
            {
                if (ratings[i] > ratings[i - 1] && list[i] <= list[i - 1])
                    list[i] = list[i - 1] + 1;
            }

            for (int i = ratings.Count - 2; i >= 0; i--)
            {
                if (ratings[i] > ratings[i + 1] && list[i] <= list[i + 1])
                    list[i] = list[i + 1] + 1;
            }

            int sum = 0;
            list.ForEach(x => sum += x);
            return sum;
        }
    }
}
