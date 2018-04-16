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
        CustomLinkedNode head = null;
        CustomLinkedNode tail = null;

        //count of the number of nodes
        int count = 0;
        public int Count { get => count; set => count = value; }

        //create a new node and add it to the end
        #region Add
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
                tail = head;
            }

            else
            {
                //create a new CustomLinkedNode, then set it as tail.Next and then as the new tail
                CustomLinkedNode willAdd = new CustomLinkedNode(data);
                tail.Next = willAdd;
                willAdd.Previous = tail;
                tail = tail.Next;
            }

            //increases count by 1
            count++;
        }
        #endregion

        //prints out each node
        #region GetData
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
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next;
                }
                return current.Data;
            }
        }
        #endregion

        //removes a node at the index
        #region Remove
        /// <summary>
        /// removes the node at the index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public string Remove(int index)
        {
            //returns an invalid entry if it's outside of the scope of count
            if (index < 0 || index > count - 1)
            {
                return "invalid entry\n";
            }

            //if they chose the first node, then remove head and set the next node to the new head
            else if (index == 0)
            {
                CustomLinkedNode temp = head;
                head = null;
                head = temp.Next;
                count--;
                return temp.Data;
            }

            //if they chose the last node, then remove tail and set the node before it to the new tail
            else if (index == count)
            {
                CustomLinkedNode temp = tail;
                tail = null;

                CustomLinkedNode current = head;

                while (current.Next != tail)
                {
                    current = current.Next;
                }
                current = tail;
                count--;
                return temp.Data;
            }

            //if there is only one node, then set both head and tail to null
            else if(count == 1)
            {
                //temporarily stores tail to be returned
                CustomLinkedNode temp = tail;
                tail = null;

                //sets current to head
                CustomLinkedNode current = head;

                //cycles to the end then sets the last item to tail
                while (current.Next != tail)
                {
                    current = current.Next;
                }
                current = tail;
                count--;
                return temp.Data;
            }

            //if there is only one node, then set both head and tail to null
            else if(count == 1)
            {                
                CustomLinkedNode temp = tail;
                head = null;
                tail = null;
                count--;
                return temp.Data;
            }

            //if the node is in the middle, cycle to the node before it, then set it's next node to the node after the indexed one
            else
            {
                CustomLinkedNode current = head;

                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next;
                }
                CustomLinkedNode removed = current.Next;               
                current.Next = current.Next.Next;
                current.Next.Previous = current;
                count--;
                return removed.Data;
            }
        }
        #endregion

        //inserts a node at the index
        #region Insert
        /// <summary>
        /// inserts a new node into the middle
        /// </summary>
        /// <param name="data"></param>
        /// <param name="index"></param>
        public void Insert(string data, int index)
        {
            //says invalid if index is negative
            if (index < 0)
            {
                Console.WriteLine("invalid entry\n");
            }
            //if index is equal to or greater than count, just use add
            else if (index >= count)
            {
                Add(data);
                Console.WriteLine(data + " has been added!");
                Console.WriteLine();
            }
            //otherwise add it to the middle
            else
            {
                //creates a new node for the entry
                CustomLinkedNode willAdd = new CustomLinkedNode(data);

                //sets the current value to head                
                CustomLinkedNode current = head;

                //inserts the data into whatever index is and fixes attachments
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next;
                }
                current.Next.Previous = willAdd;
                willAdd.Next = current.Next;
                willAdd.Previous = current;
                current.Next = willAdd;
                count++;
            }
        }
        #endregion

        //clears the list
        #region Clear
        /// <summary>
        /// calls the return method 
        /// </summary>
        public void Clear()
        {
            //remove i as it increases, and subtract 1 from i until it reaches 0
            for (int i = 0; i < count; i++)
            {                
                Remove(i);
                i--;
            }            
        }
        #endregion

        //Prints the list backwards
        #region PrintReversed
        /// <summary>
        /// Prints the current list in reverse
        /// </summary>
        public void PrintReversed()
        {
            //Setup a current node to be tail
            CustomLinkedNode current = tail;

            //cycles through backwards, printing each one
            for (int i = 0; i < Count; i++)
            {
                Console.WriteLine((Count - i) + ": " + current.Data);
                current = current.Previous;
            }
        }
        #endregion
    }
}
