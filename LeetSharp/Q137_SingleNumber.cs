using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetSharp
{
    class Q137_SingleNumber
    {
        //http://www.geeksforgeeks.org/find-the-element-that-appears-once/

        public int SingleNumber(List<int> input) 
        {
            int singleNumber = 0;
            int currentBit = 0, currentSum = 0;

            for (int i = 0; i < 32; i++)
            {
                currentSum = 0; 
                currentBit = 1 << i;

                input.ForEach(x => 
                {
                    if ((x & currentBit) != 0)
                        currentSum += 1;
                });

                if (currentSum % 3 != 0)
                    singleNumber |= currentBit;
            }

            return singleNumber;
        }
    }
}