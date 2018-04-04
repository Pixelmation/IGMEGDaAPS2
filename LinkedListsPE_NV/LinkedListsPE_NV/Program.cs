using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListsPE_NV
{
    class Program
    {
        static void Main(string[] args)
        {
            //instantiate CustomLinkedList and add 5 items
            CustomLinkedList CL = new CustomLinkedList();
            CL.Add("Magic The Gathering");
            CL.Add("Pokemon");
            CL.Add("Yugioh");
            CL.Add("Hearthstone");
            CL.Add("buddyfight");
            CL.Add("Vanguard");


            //allow to the user to ask repeatedly for data.
            /*
            while (true)
            {
                Console.Write("please choose a number between 1 and {0} to remove an item: ", CL.Count);
                string answer = Console.ReadLine();
                int answer2 = -1;
                int.TryParse(answer, out answer2);
                Console.WriteLine(CL.GetData(answer2));
            }
            */

            //cycle through each node and print it
                Console.WriteLine("The List:");
            for (int i = 0; i < CL.Count; i++)
            {
                Console.WriteLine((i+1) + ": " + CL.GetData(i+1));
            }

            //repeatedly asks to have you remove a node
            while (true)
            {
                Console.WriteLine();
                Console.Write("Please select an index to remove: ");
                string answer = Console.ReadLine();
                int answer2 = -1;
                int.TryParse(answer, out answer2);
                Console.WriteLine("removed item: " + CL.RemoveAt(answer2 - 1));

                Console.WriteLine();

                //cycles through each node and prints it
                for (int i = 0; i < CL.Count; i++)
                {
                    Console.WriteLine((i + 1) + ": " + CL.GetData(i + 1));
                }
            }
        }
    }
}
