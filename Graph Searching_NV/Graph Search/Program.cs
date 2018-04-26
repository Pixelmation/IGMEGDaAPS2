using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_Search
{
    class Program
    {
        static void Main(string[] args)
        {
            //instantiate graph
            Graph graph = new Graph();

            //loop to make testing easier
            while (true)
            {
                Console.Write("Enter a vertex: ");
                string answer = Console.ReadLine();

                if (answer == "quit")
                {
                    return;
                }
                graph.DepthFirst(answer);
                Console.WriteLine();
            }

        }
    }
}
