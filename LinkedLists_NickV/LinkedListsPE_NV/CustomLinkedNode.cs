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

<<<<<<< HEAD
=======
        //previous and it's property
        CustomLinkedNode previous;
        public CustomLinkedNode Previous { get => previous; set => previous = value; }

>>>>>>> 52c6207b6bc216a3d166d35b3eeb78894bb6ed6b
        //tail and it's property
        CustomLinkedNode tail;
        public CustomLinkedNode Tail { get => tail; set => tail = value; }


        /// <summary>
        /// constructor that sets Data and Next to default values
        /// </summary>
        /// <param name="data"></param>
        public CustomLinkedNode(string data)
        {
            Data = data;
            Next = null;
<<<<<<< HEAD
=======
            Previous = null; 
>>>>>>> 52c6207b6bc216a3d166d35b3eeb78894bb6ed6b
            Tail = null;
        }
    }
}
