using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryVsList_Starter
{
    class Program
    {
        //           Questions
        //1. The complexity is linear: O(n)
        //2. The complexity is likely Quadratic: O(n^2)
        //3. Using a dictionary instead

        static void Main(string[] args)
        {
            // Creates a new file reader, which loads a file of words
            // into both a list and a dictionary
            PracticeExerciseFileReader reader = new PracticeExerciseFileReader();

            // Get the two data structures needed for the exercise
            List<String> wordList = reader.WordList;
            Dictionary<String, bool> wordDictionary = reader.WordDictionary;

            //I had to add an extra list here to change the values of the doublewords to true
            List<String> doubleList = new List<string>();

            // *********************
            // Put your code between here...

            //asks for imput to use lists or dictionary
            Console.WriteLine("Would you like to search using the <L>ist or the <D>ictionary?");
            string answer = Console.ReadLine();
            answer = answer.ToUpper();
            char answerChar = answer[0];
            
            //checks each word to see if it's a double of whatever item is, then prints it and adds 1 to numDoubleWords to print how many there were
            if (answerChar == 'L')
            {
                int numDoubleWords = 0;
                foreach (string item in wordList)
                {
                    string doubleWord = item + item;
                    if (wordList.Contains(doubleWord))
                    {
                        Console.WriteLine(doubleWord);
                        numDoubleWords++;
                    }
                }
                    Console.WriteLine("There were " + numDoubleWords + " double words.");

            }
            //Adds each doubleword to a list then sets each of those words' values to true. Then calls Search()
            if (answerChar == 'D')
            {
                foreach (KeyValuePair<string, bool> item in wordDictionary)
                {
                    string doubleWord = item.Key + item.Key;
                    if (wordDictionary.ContainsKey(doubleWord))
                    {
                        doubleList.Add(doubleWord);
                    }
                }

                //I had to make a seperate list to store the words, since I couldn't change them in the Foreach loop
                for (int i = 0; i < doubleList.Count; i++)
                {
                    wordDictionary[doubleList[i]] = true;
                }
                
                Search(wordDictionary);
            }


            // ...and here.
            // *********************

            // All done, wait for user input to keep the window open
            Console.ReadLine();
        }
        /// <summary>
        /// Method that searches for double words, then calls itself if the user chooses to continue
        /// </summary>
        /// <param name="words"></param>
        static void Search(Dictionary<string, bool> words)
        {
            Console.WriteLine("Please enter a word to check for a double");
            string answer = Console.ReadLine();
            string answerDoubled = answer + answer;
            if (words.ContainsKey(answerDoubled))
            {
                Console.WriteLine("There is a double of " + answer + ". It is " + answerDoubled);
            }
            else
            {
                Console.WriteLine("There is no double of " + answer);
            }

            Console.WriteLine("would you like to search for another word? Y/N");
            string answerYN = Console.ReadLine();
            answerYN = answerYN.ToUpper();
            char charYN = answerYN[0];            
            if (charYN == 'Y')
            {
                Search(words);
            }
            if (charYN == 'N')
            {
                return;
            }
        }

    }
}
