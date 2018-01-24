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
            MessageLog messageLog = new MessageLog("You rolled a 20", "");
            Die die = new Die();

            die.RolledATwenty += messageLog.Save;

            die.Roll();
            messageLog.print();

        }


    }
}
