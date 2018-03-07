using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_Stacks_and_queues
{
    interface IStack
    {
        bool IsEmpty { get; }
        int Count { get; }
        void Push(String s);
        String Pop();
        String Peek();
    }
}
