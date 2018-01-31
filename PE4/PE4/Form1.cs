using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PE4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            TimerBar.Increment(1);
        }

        private void Wire_Click(object sender, EventArgs e)
        {
            //checks each parameter
            bool param1 = Check1();
            bool param2 = Check2();
            //bool param3 = Check3();
            bool param4 = Check4();

            if (param1 == true)
            {
                if (sender == Wire2)
                {
                    
                }
                else
                {

                }
            }
        }

        bool Check1()
        {
            if (Wire1.BackColor != Color.Red &&
                Wire2.BackColor != Color.Red &&
                Wire3.BackColor != Color.Red &&
                Wire4.BackColor != Color.Red &&
                Wire5.BackColor != Color.Red)
            {
                return true;
            }
            return false;
        }

        bool Check2()
        {
            if (Wire5.BackColor == Color.White)
            {
                return true;
            }
            return false;
        }

        //bool Check3()
        //{
        //
        //}

        bool Check4()
        {
            return true;
        }


    }
}
