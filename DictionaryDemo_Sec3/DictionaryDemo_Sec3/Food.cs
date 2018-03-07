using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Food class represents a (hopefully yummy!) food

namespace DictionaryDemo_Sec3
{
    class Food
    {
        // Fields
        private string foodType;
        private int calories;
        private bool yummy;

        // Properties are typically listed second in the class
        public string FoodType
        {
            get { return foodType; }
            set { foodType = value; }
        }

        // Constructors typically listed second (if no properties)
        //   or third (if properties).
        public Food(string foodType, int calories, bool yummy)
        {
            this.foodType = foodType;
            this.calories = calories;
            this.yummy = yummy;
        }

        // Methods listed last. 
        public override string ToString()
        {
            return foodType + " has " + calories + "calories and is yummy? " + yummy;
        }


    }
}
