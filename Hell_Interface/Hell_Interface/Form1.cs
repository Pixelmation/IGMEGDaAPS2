using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hell_Interface
{
    public partial class Form1 : Form
    {
        //List of radio buttons
        List<RadioButton> AgeButton = new List<RadioButton>();

        //initialize rng
        Random RNG = new Random();

        //rng method
        int RandNum()
        {
            int number = RNG.Next(1, 101);
            return number;
        }

        public Form1()
        {
            InitializeComponent();

            //add radio buttons to list
            #region radiobuttons
            AgeButton.Add(Age1);
            AgeButton.Add(Age2);
            AgeButton.Add(Age3);
            AgeButton.Add(Age4);
            AgeButton.Add(Age5);
            AgeButton.Add(Age6);
            AgeButton.Add(Age7);
            AgeButton.Add(Age8);
            AgeButton.Add(Age9);
            AgeButton.Add(Age10);
            AgeButton.Add(Age11);
            AgeButton.Add(Age12);
            AgeButton.Add(Age13);
            AgeButton.Add(Age14);
            AgeButton.Add(Age15);
            #endregion
        }

        private void Age_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < AgeButton.Count; i++)
            {
                int newText = RandNum();
                
                AgeButton[i].Text = newText.ToString();
            }
        }
    }
}
