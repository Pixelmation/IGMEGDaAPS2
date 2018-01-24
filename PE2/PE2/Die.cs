using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE2
{
    class Die
    {
        //event triggered when a 20 is rolled
        public event MessageDelegate RolledATwenty;

        //rng
        Random RNG = new Random();

        //roll function that calls RolledATwenty everytime randNum = 20
        public void Roll()
        {
            int numOfRolls = 100;
            for (int i = 0; i < numOfRolls; i++)
            {
                int randNum = RNG.Next(1, 21);
                Console.WriteLine(randNum);
                if (randNum == 20 && RolledATwenty != null)
                {
                    RolledATwenty("You Rolled a 20", "This was roll number " + i);
                }
            }
        }
    }
}
