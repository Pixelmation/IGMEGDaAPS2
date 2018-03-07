using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Dictionary Demo
// 3/5/18

namespace DictionaryDemo_Sec3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a dictionary that maps strings to Food objects
            //   meaning the string "points to" the Food object.  
            //   Not really a pointer, just can be thought of or 
            //   visualized that way.  
            Dictionary<string, Food> ourFaveFoods =
                new Dictionary<string, Food>();

            // Create some Food items
            Food eliFood = new Food("pizza", 500, true);
            Food simonFood = new Food("beef stroganoff", 200000, true);
            Food joelFood = new Food("swordfish", 0, true);

            // Add them to dictionary using the Add method or via direct index
            ourFaveFoods.Add("Eli", eliFood);
            ourFaveFoods.Add("Simon", simonFood);
            ourFaveFoods["Joel"] = joelFood;

            // Accessing a food from the dictionary
            // Use the key as the index between square brackets
            Console.WriteLine( ourFaveFoods["Simon"] );

            // To keep the program from crashing upon keys that don't exist,
            //   call the ContainsKey() method to determine if that key is in
            //   the dictionary before attempting to access the data.  
            // Will get a KeyNotFound Exception if data isn't there
            //   and the conditional below prevents that error. 
            if( ourFaveFoods.ContainsKey("Erin") )
            {
                Console.WriteLine(ourFaveFoods["Erin"]);
            }
            else
            {
                Console.WriteLine("Erin doesn't exist");
            }

        }
    }
}
