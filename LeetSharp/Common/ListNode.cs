using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetSharp
{
    public class ListNode<T>
    {
        public T Val;
        public ListNode<T> Next;
        
        public ListNode(T x)
        {
            Val = x;
            Next = null;
        }
    }
}
