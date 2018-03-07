using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryVsList_Starter
{
	class PracticeExerciseFileReader
	{
		// Fields to hold data
		private List<String> wordList;
		private Dictionary<String, bool> wordDictionary;

		// Add a field to hold StreamReader for file reading
		// *********************
		// Put your code between here...



		// ...and here.
		// *********************


		/// <summary>
		/// Gets the list of words that have been read in
		/// </summary>
		public List<string> WordList { get { return wordList; } }

		/// <summary>
		/// Gets the dictionary of words that have been read in
		/// </summary>
		public Dictionary<String, bool> WordDictionary { get { return wordDictionary; } }

		/// <summary>
		/// Loads words from an external file
		/// </summary>
		public PracticeExerciseFileReader()
		{
			// Create the data structures
			wordList = new List<string>();
			wordDictionary = new Dictionary<string, bool>();

			// Initialize the StreamReader
			// *********************
			// Put your code between here...



			// ...and here.
			// *********************


			try
			{
				// Open the file and read it into both the list and dictionary

				// *********************
				// Put your code between here...





				// ...and here.
				// *********************
			}
			catch (Exception e)
			{
				Console.WriteLine("Error loading word list: " + e.Message + "\n");
				Console.WriteLine("If you ran this program with Ctrl+F5 (or 'Start without Debugging'), try running it with F5 instead (or vice versa)");
			}
			finally
			{
				// Close the reader 

				// *********************
				// Put your code between here...



				// ...and here.
				// *********************
			}
		}
	}
}
