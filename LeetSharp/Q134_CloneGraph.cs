using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Clone an undirected graph. Each node in the graph contains a label and a list of its neighbors.

namespace LeetSharp
{
    [TestClass]
    class Q134_CloneGraph
    {
        public class UndirectedGraphNode 
        {
            public int Label;
            public List<UndirectedGraphNode> Neighbors;

            public UndirectedGraphNode(int x)
            {
                this.Label = x;
            }
        }

        public UndirectedGraphNode CloneGraph(UndirectedGraphNode node)
        {
            if (node == null)
                return null;

            var queue = new Queue<UndirectedGraphNode>();
            var map = new Dictionary<UndirectedGraphNode, UndirectedGraphNode>();

            UndirectedGraphNode retNode = new UndirectedGraphNode(node.Label);
            map[node] = retNode;

            queue.Enqueue(node);
            while (queue.Count() > 0)
            {
                UndirectedGraphNode current = queue.Dequeue();

                int count = current.Neighbors.Count;
                for (int i = 0; i < count; i++)
                {
                    UndirectedGraphNode neighbor = current.Neighbors[i];

                    if (map.ContainsKey(neighbor))
                    {
                        map[current].Neighbors.Add(map[neighbor]);
                    }
                    else
                    {
                        UndirectedGraphNode n = new UndirectedGraphNode(neighbor.Label);
                        map[current].Neighbors.Add(n);
                        map[neighbor] = n;

                        queue.Enqueue(neighbor);
                    }
                }
            }

            return retNode;
        }

    }
}
