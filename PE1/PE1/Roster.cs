using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE1
{
    class Roster
    {
        //List of students
        List<Student> StudentRoster = new List<Student>();

        public Roster()
        {
        }

        //Add student
        public void AddStudent()
        {
            Console.Write("Please enter the student's full name: ");
            string nameFromUser = Console.ReadLine();

            Console.Write("Please enter that student's Major: ");
            string majorFromUser = Console.ReadLine();

            Console.Write("Please enter the student's birth year: ");
            string year = Console.ReadLine();
            int yearFromUser = 0;
            int.TryParse(year, out yearFromUser);
            Student s = new Student(nameFromUser, majorFromUser, yearFromUser);
            StudentRoster.Add(s);
            Console.WriteLine("Added student " + nameFromUser + " to the roster.");
            Console.WriteLine();
        }

        //make a prefilled roster 
        public void AddStudent(string name, string major, int year)
        {
            Student a = new Student(name, major, year);
            StudentRoster.Add(a);
            Console.WriteLine("Added student " + name + " to the roster.");
        }

        //search by name
        public bool StudentSearch()
        {
            Console.Write("Please enter the Student's name: ");
            string nameSearch = Console.ReadLine();

            for (int i = 0; i < StudentRoster.Count; i++)
            {
                //return true if found, false if not
                if (StudentRoster[i].Name == nameSearch)
                {
                    Console.WriteLine(nameSearch + " is enrolled in this course");
                    Console.WriteLine(StudentRoster[i].ToString());
                    return true;
                }                              
            }
            Console.WriteLine(nameSearch + " is not enrolled in this course");
            return false;      
        }

        public void RemoveStudent()
        {
            Console.Write("Please enter the Student's name: ");
            string nameSearch = Console.ReadLine();

            for (int i = 0; i < StudentRoster.Count; i++)
            {
                //remove the student if found
                if (StudentRoster[i].Name == nameSearch)
                {
                    Console.WriteLine("Removed " + nameSearch + " from the roster");
                    Console.WriteLine(StudentRoster[i].ToString());
                    return;
                }               
            }
            Console.WriteLine(nameSearch + " is not enrolled in this class and cannot be removed");
        }

        public void DisplayRoster()
        {
            for (int i = 0; i < StudentRoster.Count; i++)
            {
                Console.WriteLine(StudentRoster[i].ToString());
            }
        }

        public void DisplayMajor()
        {
            Console.Write("Please enter a Major: ");
            string majorSearch = Console.ReadLine();
            Console.WriteLine("Here are the students in " + majorSearch + ":");
            for (int i = 0; i < StudentRoster.Count; i++)
            {
                //display the major of any student found
                if (StudentRoster[i].Major == majorSearch)
                {
                    Console.WriteLine(StudentRoster[i].ToString());
                    return;
                }
            }
        }

        //switch for choosing options
        public void Menu()
        {
            string choice;
            int choice2;
            Console.WriteLine("Please choose an option: " +
                              "\n1 - Add a Student" +
                              "\n2 - Remove a student" +
                              "\n3 - Search for a student" +
                              "\n4 - Print the class list" +
                              "\n5 - Print students in a specific major" +
                              "\n6 - Quit");
            choice = Console.ReadLine();
            int.TryParse(choice, out choice2);

            switch (choice2)
            {
                case 1:
                    AddStudent();
                    Console.WriteLine();
                    Menu();
                    break;
                case 2:
                    RemoveStudent();
                    Console.WriteLine();
                    Menu();
                    break;
                case 3:
                    StudentSearch();
                    Console.WriteLine();
                    Menu();
                    break;
                case 4:
                    DisplayRoster();
                    Console.WriteLine();
                    Menu();
                    break;
                case 5:
                    DisplayMajor();
                    Console.WriteLine();
                    Menu();
                    break;
                case 6:
                    return;
                default:
                    Console.WriteLine("That was not a valid entry, please try again.");
                    Console.WriteLine();
                    Menu();
                    break;
            }
        }
    }
}
