using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Form_Practice
{
    public partial class Form1 : Form
    {
        Random rng = new Random();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonNo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sounds about Right.");
        }

        int RandHeight()
        {
            int number = rng.Next(0,457);
            return number;
        }

        int RandWidth()
        {
            int number = rng.Next(0, 668);
            return number;
        }

        private void buttonYes_MouseEnter(object sender, EventArgs e)
        {
            buttonYes.Location = new Point(RandWidth(), RandHeight());
        }

        private void buttonYes_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Oh.");
        }
    }
}
