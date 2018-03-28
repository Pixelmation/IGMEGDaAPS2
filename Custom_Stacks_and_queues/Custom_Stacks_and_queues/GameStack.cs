using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_Stacks_and_queues
{
    class GameStack : IStack
    {
        //part 1 list
        public List<String> Stack = new List<string>();

        //part 2 lists
        public Stack<String> ForwardHistory = new Stack<string>();
        public Stack<String> BackwardHistory = new Stack<string>();

        #region part 1 interface stuff
        /// <summary>
        /// uses the EmptyCheck() method to see if the list is empty
        /// </summary>
        public bool IsEmpty => EmptyCheck();

        /// <summary>
        /// returns the number of items in the list
        /// </summary>
        public int Count => Stack.Count + 1;

        /// <summary>
        /// returns the top item in the stack without removing it
        /// </summary>
        /// <returns></returns>
        public string Peek()
        {
            String s = Stack[Stack.Count - 1];
            return s;
        }

        /// <summary>
        /// returns the top item in the stack, then removes it
        /// </summary>
        /// <returns></returns>
        public string Pop()
        {
            String s = Stack[Stack.Count - 1];
            Stack.RemoveAt(Stack.Count - 1);
            return s;
        }

        /// <summary>
        /// adds a new string to the list
        /// </summary>
        /// <param name="s"></param>
        public void Push(string s)
        {
            Stack.Add(s);
        }

        /// <summary>
        /// check to see if Stack is empty
        /// </summary>
        /// <returns></returns>
        bool EmptyCheck()
        {
            if (Stack.Count() == 0)
            {
                return true;
            }
            return false;
        }
        #endregion

    }
}
