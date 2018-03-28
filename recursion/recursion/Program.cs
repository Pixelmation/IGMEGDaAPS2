using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace recursion
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Console.Write("Please enter a number to find it's factorial: ");
            string numString = Console.ReadLine();
            double number = 0;
            double.TryParse(numString, out number);
            */

            for (int i = 0; i < 999; i++)
            {
            Console.WriteLine((i+1) + ": " + Factorials(i));
            }
        }

        public static double Factorials(double n)
        {
            //base case
            if (n==0)
            {
                return 1;
            }

            //recursive case
            else if (n > 0)
            {
                return n * Factorials(n - 1);
            }

            //less than 0 returns an invalid case
            else
            {
                return -1;
            }
        }
    }
}
