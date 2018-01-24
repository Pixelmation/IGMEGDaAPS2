using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateDemo_Sec3
{
    class Tank
    {
        // Create an event that's triggered when the Tank is low on health
        // Events are typically public
        // Each event can work with 1 kind of signature
        // The point of an event?  From outside of this class, this event
        //    can be hooked up to to a method
        public event LowHealthDelegate OnLowHealth;

        // Fields
        private string name;
        private int health;

        /// <summary>
        /// Tank constructor
        /// </summary>
        /// <param name="name">Character's name</param>
        public Tank(string name)
        {
            this.name = name;
            health = 100;
        }

        // TakeDamage method
        // This Tank class takes a specific number of damage from an outside source
        public void TakeDamage(int hitPoints)
        {
            health -= hitPoints;
            Console.WriteLine("Tank took {0} damage. Health is {1}", hitPoints, health);

            // If the health falls below 20, Trigger the event!  Call the healer!
            // Determine if the event is hooked up before attempting to invoke the event
            //   by comparing against null
            // If event is not hooked up and it is not checked against null, exception will occur
            if(health < 20 && OnLowHealth != null)
            {
                // The health is low enough so invoke the event
                // Use the event as if it were a method
                // Pass in any necessary parameters
                OnLowHealth("I'm dying! Save me!", health);
            }
        }
    }
}
