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
            CustomLinkedList CL = new CustomLinkedList();
            CL.Add("Magic The Gathering");
            CL.Add("Pokemon");
            CL.Add("Yugioh");
            CL.Add("Yu-Gi-Oh");
            CL.Add("Vanguard");

            while (true)
            {
                Console.Write("please choose a number between 1 and 5 to get the index of: ");
                string answer = Console.ReadLine();
                int answer2 = -1;
                int.TryParse(answer, out answer2);
                CL.GetData(answer2);
                Console.WriteLine();
            }
        }
    }
}
