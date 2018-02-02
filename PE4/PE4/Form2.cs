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
        public Form2(string titleColor)
        {
            InitializeComponent();
            titleColor = "Oops! You cut the " +titleColor+ " Wire!";
            this.Text = titleColor;
        }
    }
}
