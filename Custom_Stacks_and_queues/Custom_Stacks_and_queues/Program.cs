using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_Stacks_and_queues
{
    class Program
    {
        //create the stacks for part 2 and a startpage
        static Stack<String> ForwardHistory = new Stack<string>();
        static Stack<String> BackwardHistory = new Stack<string>();
        static string currentPage = "Google";
        static void Main(string[] args)
        {
            //instantiate gameStack and gameQueue
            GameStack gameStack = new GameStack();
            GameQueue gameQueue = new GameQueue();

            #region Part 1
            //add spells to the stack and then pop them
            #region stack section

            //add the spells to the stack
            #region spells
            Console.WriteLine("Adding spells to the stack:");

            gameStack.Push("Lightning Bolt");
            Console.WriteLine(gameStack.Peek());

            gameStack.Push("Snapcaster Mage");
            Console.WriteLine(gameStack.Peek());

            gameStack.Push("CounterSpell");
            Console.WriteLine(gameStack.Peek());

            gameStack.Push("TwinBolt");
            Console.WriteLine(gameStack.Peek());

            gameStack.Push("Daze");
            Console.WriteLine(gameStack.Peek());
            #endregion

            Console.WriteLine();
            Console.WriteLine("Spells resolving in reverse order:");
            //while loop to pop each item in the list while it has items in it
            while (gameStack.IsEmpty == false)
            {
                Console.WriteLine(gameStack.Pop());
            }
            #endregion

            //spacing lines
            Console.WriteLine();
            Console.WriteLine();

            //add people to a queue and then dequeue them
            #region queue section

            //adding people to a queue
            #region people
            Console.WriteLine("People being queued a server");
            gameQueue.Enqueue("Nick");
            gameQueue.Enqueue("Briana");
            gameQueue.Enqueue("Drake");
            gameQueue.Enqueue("Nico");
            gameQueue.Enqueue("Some other nerd");

            //displays each of the people in the queue
            for (int i = 0; i < gameQueue.Count - 1; i++)
            {
                Console.WriteLine(gameQueue.Queue[i]);
            }
            #endregion

            //while the queue has people in it, dequeue until the list is empty
            Console.WriteLine();
            Console.WriteLine("Adding the queued people to the server:");
            while (gameQueue.IsEmpty == false)
            {
                Console.WriteLine(gameQueue.Dequeue() + " Has joined the server: " + (gameQueue.Count - 1) + " player(s) left in the queue");
            }
            #endregion
            #endregion

            //spacing for part 2
            Console.WriteLine("\n\n\n\n");

            #region Part 2
            //part 2 stacks

            //store the current page as a string, defaults to Google on startup
            while (true)
            {
                //display the possible controls
                Console.WriteLine();
                Console.WriteLine("Here are your possible controls:");
                Console.WriteLine("1. visit a new webpage");
                Console.WriteLine("2. move forward to the next page");
                Console.WriteLine("3. navigate back to the previous page");
                Console.WriteLine("4. print the current page, as well as the backward stack and forward stack");
                Console.WriteLine("5. quit the loop");

                string answer = Console.ReadLine();
                int answerInt = 0;
                int.TryParse(answer, out answerInt);

                //switch to check each the answer and provide the appropriate method
                switch (answerInt)
                {
                    case 1:
                        currentPage = VisitPage(currentPage);
                        Console.WriteLine("--------------------");
                        break;
                    case 2:
                        currentPage = NextPage(currentPage);
                        Console.WriteLine("--------------------");
                        break;
                    case 3:
                        currentPage = PreviousPage(currentPage);
                        Console.WriteLine("--------------------");
                        break;
                    case 4:
                        PrintEverything(currentPage);
                        Console.WriteLine("--------------------");
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("--------------------");
                        Console.WriteLine("Invalid Entry, please try again");
                        Console.WriteLine();
                        break;
                }
            }

            #endregion
        }

        #region part 2 methods

        /// <summary>
        /// method that asks for a new site, and returns the entry. old page is pushed to BackwardHistory and ForwardHistory is cleared
        /// </summary>
        /// <param name="lastSite"></param>
        /// <returns></returns>
        static string VisitPage(string cPage)
        {
            Console.WriteLine();
            Console.Write("Please Enter a website: ");
            string answer = Console.ReadLine();
            ForwardHistory.Clear();
            if (cPage != null)
            {
                BackwardHistory.Push(cPage);
            }
            return answer;
        }

        /// <summary>
        /// pushes the current page into the backHistory, and pops the first item in forwardHistory, returning it
        /// </summary>
        /// <param name="cPage"></param>
        /// <returns></returns>
        static string NextPage(string cPage)
        {
            if (ForwardHistory.Count > 0)
            {
                BackwardHistory.Push(cPage);
                string answer = ForwardHistory.Pop();
                return answer;
            }
            Console.WriteLine("There is no forward history");
            return cPage;
        }

        /// <summary>
        /// pushes the current page into the fowardHistory, and pops the first item in backwardHistory, returning it
        /// </summary>
        /// <param name="cPage"></param>
        /// <returns></returns>
        static string PreviousPage(string cPage)
        {
            if (BackwardHistory.Count > 0)
            {
                ForwardHistory.Push(cPage);
                string answer = BackwardHistory.Pop();
                return answer;
            }
            else
            {
            Console.WriteLine("There is no backward history");
            return cPage;
            }
        }

        /// <summary>
        /// prints the current page, then cycles through both stacks to print each item
        /// </summary>
        /// <param name="cPage"></param>
        static void PrintEverything(string cPage)
        {
            Console.WriteLine("Current page is " + cPage);

            Console.WriteLine();
            if (BackwardHistory.Count > 0)
            {
                Console.WriteLine("This is your current Backward History:");
                foreach (string item in BackwardHistory)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("There is no backward history");
            }

            Console.WriteLine();
            if (ForwardHistory.Count > 0)
            {
                Console.WriteLine("This is your current Forward History:");
                foreach (string item in ForwardHistory)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("There is no forward history.");
            }
        }
        #endregion
    }
}
