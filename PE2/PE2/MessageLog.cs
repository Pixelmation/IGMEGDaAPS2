using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE2
{
    class MessageLog
    {
        //variables
        private string label;
        private string message;

        //list to hold info
        List<string> listMessage = new List<string>();

        //constuctor
        public MessageLog(string message)
        {
            label = "You Rolled a 20: ";
            this.message = message;
        }



        //saves and keeps track of the messages
        public void Save(string label, string message)
        {
            listMessage.Add(message);
        }

        //prints out whatever is stored in save()
        public void print()
        {
            for (int i = 0; i < listMessage.Count; i++)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(label);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(message);
            }
        }

    }
}
