using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListsPE_NV
{
    class CustomLinkedNode
    {        
        
        //data and its property
        string data;
        public string Data { get => data; set => data = value; }

        CustomLinkedNode next;
        public CustomLinkedNode Next { get => next; set => next = value; }

        public CustomLinkedNode(string data)
        {
            Data = data;
            Next = null;
        }
    }
}
