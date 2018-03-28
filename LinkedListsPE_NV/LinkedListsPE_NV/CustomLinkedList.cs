using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListsPE_NV
{
    class CustomLinkedList
    {
        CustomLinkedNode head;
        int count = 0;

        public void Add(string data)
        {
            head.Next = new CustomLinkedNode(data);
            count++;
        }

        public void GetData(int index)
        {
            if (index < 0 || index >= count)
            {
                Console.WriteLine("invalid entry");
                return;
            }
            CustomLinkedNode current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            Console.WriteLine(current.Data);            
        }
    }
}
