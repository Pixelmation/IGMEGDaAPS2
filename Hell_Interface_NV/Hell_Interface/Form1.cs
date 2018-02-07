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

        /// <summary>
        /// rng method that returns an int between 1 and 100
        /// </summary>
        /// <returns></returns>
        int RandNum()
        {
            int number = RNG.Next(1, 101);
            return number;
        }

        /// <summary>
        /// Add radiobuttons to the list on form load and disables max/min, resize and close
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            this.ControlBox = false;
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

        /// <summary>
        /// whenever a radio button is clicked, radomize the number besides each one
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Age_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < AgeButton.Count; i++)
            {
                int newText = RandNum();
                
                AgeButton[i].Text = newText.ToString();
            }
        }

        /// <summary>
        /// when text in textBoxSkills is changed, change the text to "None, lol"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxSkills_TextChanged(object sender, EventArgs e)
        {
            textBoxSkills.Text = "None, lol";
        }

        /// <summary>
        /// whenever a checkbox is chosen, change it to unpaid intern
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBox_EnabledChanged(object sender, EventArgs e)
        {
            checkBoxManager.Checked = false;
            checkBoxJanitor.Checked = false;
            checkBoxCEO.Checked = false;
            checkBoxIntern.Checked = true;

        }

        /// <summary>
        /// Enters FormExit when buttonExit is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonExit_Click(object sender, EventArgs e)
        {
            
            FormExit form = new FormExit(textBoxName.Text);
            form.ShowDialog();

        }

        /// <summary>
        /// makes every word yes when clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonYes_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.Controls.Count; i++)
            {
                this.Controls[i].Text = "Yes";
            }
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            FormSubmit FormSub = new FormSubmit(textBoxName.Text);
            FormSub.ShowDialog();
        }
    }
}
