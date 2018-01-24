using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace WindowsForms_hardcoded
{
    class MyWindow : Form
    {
        
        public MyWindow()
        {
            this.Text = "Title bar Text";
            this.BackColor = Color.Azure;
            //this.BackColor = Color.FromArgb(69,69,69);

            //change the size
            //create a copy of the struct
            //change the values
            //reassign back
            Size tempSize = this.Size;
            tempSize.Width = 200;
            tempSize.Height = 500;
            this.Size = tempSize;


            this.Size = new Size(200, 500);

            Button myButton = new Button();
            myButton.Text = "butt";
            myButton.Size = new Size(100, 100);
            myButton.BackColor = Color.Indigo;

            //hook up change button method to a click event
            myButton.Click += ChangeButton;

            //draws the button
            this.Controls.Add(myButton);
        }


        private void ChangeButton(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                Button b = (Button)sender;
                b.BackColor = Color.RosyBrown;
            }

        }

    }
}
