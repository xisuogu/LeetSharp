using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetSharp
{
    class Q136_GasStation
    {
        public int CanCompleteCircuit(List<int> gas, List<int> cost)
        {
            int totalSum = 0, currentSum = 0; 
            int index = -1;

            for (int i = 0; i < gas.Count; i++)
            {
                    currentSum += (gas[i] - cost[i]);
                    totalSum += (gas[i] - cost[i]);
                
                    if (currentSum < 0)
                    {
                        index = i;    
                        currentSum = 0;
                    }
            }
        
            return totalSum < 0 ? -1 : index + 1;
        }
    }
}
