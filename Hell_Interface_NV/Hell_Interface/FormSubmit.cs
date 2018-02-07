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
    public partial class FormSubmit : Form
    {
        //initialize rng
        Random RNG = new Random();

        /// <summary>
        /// creates a random number between 0 and 9 then adds it to a string
        /// </summary>
        /// <returns></returns>
        string NumbLabel()
        {
            string result = "";
            for (int i = 0; i < 25; i++)
            {
                int number = RNG.Next(0, 10);
                result= result + number.ToString();
            }
            return result;
        }

        /// <summary>
        /// disables max/min, resize and close
        /// </summary>
        public FormSubmit()
        {
            InitializeComponent();
            this.ControlBox = false;
        }

        /// <summary>
        /// on form load, creates a string 25 digits long and adds it to a string for the labelNum
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormSubmit_Load(object sender, EventArgs e)
        {
            labelNum.Text = NumbLabel();
        }

        /// <summary>
        /// when the back button is clicked, close the window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// if the textbox matches the label then you succeed and the form closes. if not then you have to start over
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBoxNum.Text == labelNum.Text )
            {
                MessageBox.Show("congratulations, you've applied!");
                Application.Exit();
            }
            else
            {
                MessageBox.Show("Incorrect, please try again.");
                this.Close();
            }
        }
    }
}
