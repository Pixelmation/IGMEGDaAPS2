using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace PE3
{
    class MyForm : Form
    {
        Random rng = new Random();
        public MyForm()
        {
            //title the wondow 'Buttons!"
            this.Text = "Buttons!";

            //Change the window size to 800x800
            this.Size = new Size(800, 800);

            //button properties
            Button myButton = new Button();
            myButton.Size = new Size(80, 80);
            myButton.BackColor = Color.FromArgb(Rand(), Rand(), Rand());

            this.Controls.Add(myButton);

        }

        private int Rand()
        {
            int randnum = rng.Next(1,256);
            return randnum;
        }
    }
}
