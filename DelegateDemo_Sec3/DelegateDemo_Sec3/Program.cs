using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Erin Cascioli
// 1/22/18
// Demo: Delegates and Events

namespace DelegateDemo_Sec3
{
    // Storing a method as a variable
    // Method signatures must match!
    // Can be used for any method whose signature matches this delegate!
    // Like an enum - defined outside of your classes so multiple classes can call it
    delegate void LowHealthDelegate(string message, int currentHealth);

    class Program
    {
        static void Main(string[] args)
        {
            //Variable which can hold any method (delegate)
            LowHealthDelegate methodToCallLater;

            // Assign a method to the delegate
            // We don't want to call CallHealer() yet...  we'll call it another time
            // This is a reference to another method for now
            // We don't need the return type, params, or () - just the method identifier
            methodToCallLater = CallHealer;

            // Create a Tank who can take damage
            Tank tank = new Tank("Bob");

            // When the tank is running low on health, trigger the OnLowHealth event which will call Call Healer
            // Like above, no return type, params, or () are needed - just the method identifier
            tank.OnLowHealth += CallHealer;

            // Bob is hit 3 times
            tank.TakeDamage(8);
            tank.TakeDamage(13);
            tank.TakeDamage(70);

            //DoSomething();
            //methodToCallLater("Hi", 5);
        }


        // Static method
        // Can be called from anywhere in the Program class by calling the method, 
        //   or elsewhere in the projefct by calling Program.DoSomething
        // Static = doesn't need an object reference to call/use it
        // Way to create helper functions for classes like Console or Math
        public static void DoSomething()
        {
            Console.WriteLine("Doing something");
        }


        // This method will be called when the Tank is at low health
        // This method will be stored in a delegate
        //    so it can be called anytime!
        static void CallHealer(string message, int number)
        {
            Console.WriteLine("Message: " + message);
            Console.WriteLine("Health: " + number);
        }
    }
}
