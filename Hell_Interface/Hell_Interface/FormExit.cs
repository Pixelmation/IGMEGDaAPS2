using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Hell_Interface
{
    public partial class FormExit : Form
    {
        //int for trying to exit the application
        int clicks = 0;

        //initialize rng
        Random RNG = new Random();

        /// <summary>
        /// rng method that returns an int between 1 and 1600
        /// </summary>
        /// <returns></returns>
        int RandNumWidth()
        {
            int number = RNG.Next(1, 1601);
            return number;
        }

        /// <summary>
        /// rng method that returns an int between 1 and 800
        /// </summary>
        /// <returns></returns>
        int RandNumHeight()
        {
            int number = RNG.Next(1, 801);
            return number;
        }

        /// <summary>
        /// constructor that hides max/min, resize and close button
        /// </summary>
        public FormExit()
        {
            InitializeComponent();
            this.ControlBox = false;
        }

        /// <summary>
        /// if No is clicked, then return to Form1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonNo_Click(object sender, EventArgs e)
        {
            clicks = 0;
            this.Close();
        }

        /// <summary>
        /// if Yes is clicked, repeat window 10 times to confirm, sleeping for 500ms between each click, then closes both windows
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonYes_Click(object sender, EventArgs e)
        {
            clicks++;
            textBoxConfirm.Text = YesClicks();
            this.Location = new Point(RandNumWidth(),RandNumHeight());
            if (clicks >=9)
            {
                Application.Exit();

            }
        }

        /// <summary>
        /// method to add to the textboxConfirm
        /// </summary>
        /// <returns></returns>
        string YesClicks()
        {
            string result = "Are you";
            for (int i = 0; i < clicks; i++)
            {
                result = result + " really ";
            }
            result = result + "sure you want to exit?";
            return result;
        }
    }
}
