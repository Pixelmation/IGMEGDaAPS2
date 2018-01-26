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

            //Change the window size to 500x500
            this.Size = new Size(470, 490);

            //size of the buttons and the 
            int ButtonWidth = 40;
            int ButtonHeight = 40;
            int well = 5;

            //nested for loops to create each button with it's properties, and set them in a grid row by row
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Button myButton = new Button();
                    myButton.Location = new Point(5+(j * ButtonWidth + (well*j)),5 + (i * ButtonHeight + (well*i)));
                    myButton.Size = new Size(ButtonWidth, ButtonHeight);
                    myButton.BackColor = Color.FromArgb(Rand(), Rand(), Rand());
                    myButton.MouseEnter += ButtonClickHandler;
                    this.Controls.Add(myButton);

                }
            }

        }


        //Method for changing button
        private void ButtonClickHandler(object sender, EventArgs e)
        {
            //checks if sender is a button. if it is, changes it's color
            if (sender is Button)
            {
                Button b = (Button)sender;
                b.BackColor = Color.FromArgb(Rand(), Rand(), Rand());
            }
        }

        //RNG from 1-255
            private int Rand()
        {
            int randnum = rng.Next(1,256);
            return randnum;
        }
    }
}
