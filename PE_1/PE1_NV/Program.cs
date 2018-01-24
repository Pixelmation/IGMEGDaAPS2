using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE1
{
    class Program
    {
        static void Main(string[] args)
        {
            Roster roster = new Roster();
            //add 2 pre-enrolled students
            roster.AddStudent("Jon Arbuckle", "Animation", 1999);
            roster.AddStudent("Natsu Dragneel", "Game Design", 1999);

            //enter the switch until they quit           
            roster.Menu();

        }
    }
}
