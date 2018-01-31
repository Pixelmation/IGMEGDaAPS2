using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormPractice
{ 

    public partial class Form1 : Form
    {
        int Counter = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            Counter++;
            CounterBox.Text = Counter.ToString();
        }

        private void buttonSubtract_Click(object sender, EventArgs e)
        {
            Counter--;
            CounterBox.Text = Counter.ToString();

            if (Counter <= 0)
            {
                MessageBox.Show("Coolio");
            }
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            Counter = 0;
            CounterBox.Text = Counter.ToString();

        }

        private void TimerCounter_Tick(object sender, EventArgs e)
        {
            Counter++;
            CounterBox.Text = Counter.ToString();

        }
    }
}
