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
            //instantiate CustomLinkedList and Random
            CustomLinkedList CL = new CustomLinkedList();
            Random rng = new Random();

            //populates the list with 6 numbers so it's easy to tell if stuff has been switched or removed
            #region add values
            CL.Add("1");
            CL.Add("2");
            CL.Add("3");
            CL.Add("4");
            CL.Add("5");
            CL.Add("6");
            #endregion

            while (true)
            {
                #region list commands
                Console.WriteLine();
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine("q or quit      - End the Loop\n" +
                                  "print          - Print everything in the list\n" +
                                  "count          - print the number of items in the list\n" +
                                  "clear          - clear the entire list\n" +
                                  "remove         - randomly remove one element from the list\n" +
                                  "backwards      - prints each item in reverse order\n" +
                                  "scramble       - removes a random piece of data from the list, then randomly reinserts it\n" +
                                  "anything else will be added to teh end of the list\n");
                Console.Write("please choose one: ");
                string answer = Console.ReadLine();
                answer = answer.ToLower();
                #endregion

                #region the switch
                switch (answer)
                {
                    //exits the loop
                    case "q":
                        return;
                    case "quit":
                        return;

                    //prints each item
                    case "print":
                        Console.WriteLine("The Current List:");
                        for (int i = 0; i < CL.Count; i++)
                        {
                            Console.WriteLine((i + 1) + ": " + CL.GetData(i + 1));
                        }
                        Console.WriteLine();
                        break;

                    //prints how many items there are
                    case "count":
                        Console.WriteLine("there are " + CL.Count + " items in the list.\n");
                        break;

                    //removes everything
                    case "clear":
                        CL.Clear();
                        Console.WriteLine("The list has been cleared.\n");
                        break;

                    //removes something at random
                    case "remove":                       
                        int randNumRemove = rng.Next(0, CL.Count);
                        CL.Remove(randNumRemove);
                        Console.WriteLine("a random element was removed!\n");
                        break;

                    //prints the list backwards
                    case "backwards":
                        Console.WriteLine("The Current Backwards List:");
                        CL.PrintReversed();
                        Console.WriteLine();
                        break;
                        
                    //randomly removes then reinserts an item
                    case "scramble":
                        int randNumScramble1 = rng.Next(0, CL.Count);
                        int randNumScramble2 = rng.Next(0, CL.Count - 1);                        
                        CL.Insert(CL.Remove(randNumScramble1), randNumScramble2);
                        Console.WriteLine("a random item has been removed and put back in randomly\n");
                        break;

                    //anything else will be added to the end
                    default:
                        CL.Add(answer);
                        Console.WriteLine(answer + " has been added to the end of the list!");
                        break;                    
                }
                #endregion
            }
        }
    }
}
