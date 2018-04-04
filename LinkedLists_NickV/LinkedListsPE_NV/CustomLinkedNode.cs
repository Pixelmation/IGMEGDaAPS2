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

        //next and it's property
        CustomLinkedNode next;
        public CustomLinkedNode Next { get => next; set => next = value; }

        /// <summary>
        /// constructor that sets Data and Next to default values
        /// </summary>
        /// <param name="data"></param>
        public CustomLinkedNode(string data)
        {
            Data = data;
            Next = null;
        }
    }
}
