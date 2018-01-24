using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE2
{

        delegate void MessageDelegate(string label, string message);

    class Program
    {

        static void Main(string[] args)
        {
            //instantiate the other classes
            Die die = new Die();
            MessageLog messageLog = new MessageLog();

            //connect RolledATwenty and Save()
            die.RolledATwenty += messageLog.Save;

            //print the roll results and where 20s are
            die.Roll();
            messageLog.print();

        }


    }
}
