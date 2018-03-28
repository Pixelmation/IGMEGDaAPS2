using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListsPE_NV
{
    class CustomLinkedList
    {
        //instantiate head with a null string
        CustomLinkedNode head = new CustomLinkedNode("");

        //count of the number of nodes
        int count = 0;
        public int Count { get => count; set => count = value; }

        /// <summary>
        /// Method to call when adding data, passing in whatever that data is
        /// </summary>
        /// <param name="data"></param>
        public void Add(string data)
        {
            //if head is null, sets it to Data
            if (head == null)
            {
                head = new CustomLinkedNode(data);
            }

            else
            {
                //create a new CustomLinkedNode to be added equal to whatever Data was
                CustomLinkedNode willAdd = new CustomLinkedNode(data);

                //sets the current to head
                CustomLinkedNode current = head;

                //cycles to the last option, then sets the last one's Next value to willAdd
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = willAdd;
            }

            //increases count by 1
            count++;
        }

        /// <summary>
        /// call whenever you're calling the data needed
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public string GetData(int index)
        {
            //if index is 0 or less, or greater than count, return "invalid entry"
            if (index <= 0 || index > count)
            {
                return "invalid entry\n";
            }

            else
            {
                //sets the current value to head
                CustomLinkedNode current = head;

                //cycles through each option until it hits whatever index was, then returns it
                for (int i = 0; i < index; i++)
                {
                    current = current.Next;
                }
                return current.Data;
            }
        }
    }
}
