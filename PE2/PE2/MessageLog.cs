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
        List<string> listlabel = new List<string>();
        List<string> listMessage = new List<string>();


        public MessageLog(string label, string message)
        {
            this.label = "You Rolled a 20";
            this.message = message;
        }



        //saves and keeps track of the messages
        public void Save(string label, string message)
        {
            listlabel.Add(label);
            listMessage.Add(message);
        }

        //prints out whatever is stored in save()
        public void print()
        {
            for (int i = 0; i < listlabel.Count; i++)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(listlabel[i] + ": ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(message);
            }
        }

    }
}
