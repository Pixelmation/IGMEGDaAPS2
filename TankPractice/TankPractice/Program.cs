using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankPractice
{
    //storing a method as a variable
    //method signatures must match!
    delegate void LowHealthDelegate(string message, int number);

    class Program
    {
        static void Main(string[] args)
        {
            //variable which can hold any variable(delegate)
            LowHealthDelegate methodToCallLater;

            //assign a method to the delegate
            methodToCallLater = CallHealer;

            //assign a method to the delegate

            //make a tank and have it take damage
            Tank tank = new Tank("Grognak");

            tank.OnLowHealth += CallHealer;

            tank.TakeDamage(12);
            tank.TakeDamage(30);
            tank.TakeDamage(44);

        }
        //do something method
        //methodToCallLater("Hi", 5);

        //this method willbe called when the tank is at low health
        //this method will be stored as a delegate
        static void CallHealer(string message, int number)
        {
            Console.WriteLine("Message: " + message);
            Console.WriteLine("Health: " + number);
        }
    }
}
