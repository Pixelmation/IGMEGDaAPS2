using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_Stacks_and_queues
{
    interface IQueue
    {
        bool IsEmpty { get; }
        int Count { get; }
        void Enqueue(String s);
        String Dequeue();
        String Peek();
    }
}
