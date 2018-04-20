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
            //initialize graph and set Kitchen to the current room
            Graph graph = new Graph();
            string currentRoom = "Kitchen";

            //while loop to keep the player searching until they reach exit
            while (true)
            {
                //name the current and available rooms
                Console.WriteLine("\nYou are currently in the " + currentRoom);
                Console.Write("Nearby are:      ");
                for (int i = 0; i < graph.GetAdjacentList(currentRoom).Count; i++)
                {
                    Console.Write(graph.GetAdjacentList(currentRoom)[i] + "     ");
                }

                //check for player imput
                Console.Write("\nWhere would you like to go? ");
                string answer = Console.ReadLine();

                //if the enter Exit and it's available, then they escape. Otherwise just set answer to the new currentRoom and repeat
                if (graph.IsConnected(currentRoom, answer))
                {
                    if (answer == "Exit")
                    {
                        Console.WriteLine("You have successfully Escaped!");
                        return;
                    }
                    currentRoom = answer;
                }

                //if the room isn't available then go back to the top of the loop
                else
                {
                    Console.WriteLine("Sorry, that is not an entry.");
                }
            }

        }
    }
}
