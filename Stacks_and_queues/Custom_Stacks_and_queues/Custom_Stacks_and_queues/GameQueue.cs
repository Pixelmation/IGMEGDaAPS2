using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_Stacks_and_queues
{
    class GameQueue : IQueue
    {
        public List<String> Queue = new List<string>();

        /// <summary>
        /// uses the EmptyCheck() method to see if the list is empty
        /// </summary>
        public bool IsEmpty => EmptyCheck();

        /// <summary>
        /// returns the number of items in the list
        /// </summary>
        public int Count => Queue.Count() + 1;

        /// <summary>
        /// returns the first item in the queue, then removes it
        /// </summary>
        /// <returns></returns>
        public string Dequeue()
        {
            String s = Queue[0];
            Queue.RemoveAt(0);
            return s;
        }

        /// <summary>
        /// adds a new string to the list
        /// </summary>
        /// <param name="s"></param>
        public void Enqueue(string s)
        {
            Queue.Add(s);
        }

        /// <summary>
        /// returns the last item in the queue without removing it
        /// </summary>
        /// <returns></returns>
        public string Peek()
        {
            String s = Queue[Queue.Count()-1];
            return s;
        }

        /// <summary>
        /// check to see if Stack is empty
        /// </summary>
        bool EmptyCheck()
        {
            if (Queue.Count() == 0)
            {
                return true;
            }
            return false;
        }
	}
}
