using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE1
{
    class Student
    {
        //fields
        string _name;
        string _major;
        int _birthYear;

        //properties for the fields
        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public string Major
        {
            get => _major;
            set => _major = value;
        }

        public int BirthYear
        {
            get => _birthYear;
            set => _birthYear = value;
        }

        //main constructor
        public Student(string name, string major, int birthYear)
        {
        }

        //default constructor
        public Student()
        {
            Name = "Non-Specified Name";
            Major = "Non-Specified Major";
            BirthYear = 1900;
        }

        public override string ToString()
        {
            return Name + " - " + Major + " - " + BirthYear;
        }
    }
}
