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
        //initializing variables and other required fields
        Form2 Form2;
        int progress = 0;
        Random RNG = new Random();
        List<Button> Wires = new List<Button>();
        string titleF2;

        public Form1()
        {
            InitializeComponent();

            Form2 = new Form2(titleF2);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Wires.Add(Wire1);
            Wires.Add(Wire2);
            Wires.Add(Wire3);
            Wires.Add(Wire4);
            Wires.Add(Wire5);
        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            ButtonColors();
            Wire1.Enabled = true;
            Wire2.Enabled = true;
            Wire3.Enabled = true;
            Wire4.Enabled = true;
            Wire5.Enabled = true;
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            progress++;
            TimerBar.Increment(1);
            if (progress == TimerBar.Maximum)
            {
                progress = 0;
                Lose();
            }
        }

        private void Wire_Click(object sender, EventArgs e)
        {
            //checks each rule
            bool param1 = Check1();
            bool param2 = Check2();
            bool param3 = Check3();
            bool param4 = Check4();

            //if a rule is true, asks for the correct sender and you lose if the sender isn't the right wire
            #region final check
            if (param1 == true)
            {
                if (sender == Wire2)
                {                    
                    Win();
                    return;
                }
                else
                {
                    Lose();
                    return;
                }
            }

            if (param2 == true)
            {
                if (sender == Wire5)
                {
                    Win();
                    return;
                }
                else
                {
                    Lose();
                    return;
                }
            }

            if (param3 == true)
            {
                if ((sender == Wire5 && Wire5.BackColor == Color.Blue) ||
                    (sender == Wire4 && Wire4.BackColor == Color.Blue && Wire5.BackColor != Color.Blue) ||
                    (sender == Wire3 && Wire3.BackColor == Color.Blue && Wire5.BackColor != Color.Blue && Wire4.BackColor != Color.Blue) ||
                    (sender == Wire2 && Wire2.BackColor == Color.Blue && Wire5.BackColor != Color.Blue && Wire4.BackColor != Color.Blue && Wire3.BackColor != Color.Blue))
                {
                    Win();
                    return;
                }
                else
                {
                    Lose();
                    return;
                }
            }

            if (param4 == true)
            {
                if (sender == Wire5)
                {
                    Win();
                    return;
                }
                else
                {                   
                    Lose();
                    return;
                }
            }
            #endregion           
        }

        //hardcoded rules that return true or false on if they're reached
        #region checks
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

        bool Check3()
        {
            int blueWires = 0;
            if (Wire1.BackColor == Color.Blue)
            {
                blueWires++;
            }
            if (Wire2.BackColor == Color.Blue)
            {
                blueWires++;
            }
            if (Wire3.BackColor == Color.Blue)
            {
                blueWires++;
            }
            if (Wire4.BackColor == Color.Blue)
            {
                blueWires++;
            }
            if (Wire5.BackColor == Color.Blue)
            {
                blueWires++;
            }
            if (blueWires >= 2)
            {
                return true;
            }
            return false;
        }

        bool Check4()
        {
            return true;
        }
        #endregion

        //methods for winning and losing
        #region Win/Lose
        void Win()
        {
            timer.Stop();
            Wire1.Enabled = false;
            Wire2.Enabled = false;
            Wire3.Enabled = false;
            Wire4.Enabled = false;
            Wire5.Enabled = false;
            ButtonStart.Text = "Reset";
            MessageBox.Show("You defused the bomb!");
        }

        void Lose()
        {
            titleF2 = "You clicked the " + BackColor + "wire!";
            timer.Stop();
            Wire1.Enabled = false;
            Wire2.Enabled = false;
            Wire3.Enabled = false;
            Wire4.Enabled = false;
            Wire5.Enabled = false;
            ButtonStart.Text = "Reset";
            Form2.ShowDialog();
        }
        #endregion

        //methods for randomizing the wire colors
        #region Random Colors
        void ButtonColors()
        {
            foreach (Button Button in Wires)
            {
                int color = RandNum();
                switch (color)
                {
                    case 1:
                        Button.BackColor = Color.Blue;
                        break;
                    case 2:
                        Button.BackColor = Color.Black;
                        break;
                    case 3:
                        Button.BackColor = Color.Red;
                        break;
                    case 4:
                        Button.BackColor = Color.White;
                        break;
                    case 5:
                        Button.BackColor = Color.Yellow;
                        break;
                    default:
                        break;
                }
            }
        }
        
        int RandNum()
        {
            int rgb = RNG.Next(1, 5);
            return rgb;
        }
        #endregion
    }
}
