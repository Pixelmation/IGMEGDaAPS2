using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph();
            string currentRoom = "Kitchen";

            while (!false)
            {
                Console.WriteLine("\nYou are currently in the " + currentRoom);
                Console.Write("Nearby are:      ");
                for (int i = 0; i < graph.GetAdjacentList(currentRoom).Count; i++)
                {
                    Console.Write(graph.GetAdjacentList(currentRoom)[i] + "     ");
                }
                Console.Write("\nWhere would you like to go? ");
                string answer = Console.ReadLine();
                if (graph.IsConnected(currentRoom, answer))
                {
                    if (answer == "Exit")
                    {
                        Console.WriteLine("You have successfully Escaped!");
                        return;
                    }
                    currentRoom = answer;
                }
                else
                {
                    Console.WriteLine("Sorry, that is not an entry.");
                }
            }

        }
    }
}
