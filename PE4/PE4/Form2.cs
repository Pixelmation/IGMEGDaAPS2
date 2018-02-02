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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public Form2(IContainer components, string titleColor)
        {
            titleColor = "Oops! You cut the wrong Wire!";
            this.Text = titleColor;
        }
    }
}
