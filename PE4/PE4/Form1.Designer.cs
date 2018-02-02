namespace PE5
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.LabelRules = new System.Windows.Forms.Label();
            this.Rule1 = new System.Windows.Forms.Label();
            this.Rule2 = new System.Windows.Forms.Label();
            this.Rule3 = new System.Windows.Forms.Label();
            this.Rule4 = new System.Windows.Forms.Label();
            this.TimerBar = new System.Windows.Forms.ProgressBar();
            this.LabelTimer = new System.Windows.Forms.Label();
            this.ButtonStart = new System.Windows.Forms.Button();
            this.Wire1 = new System.Windows.Forms.Button();
            this.Wire2 = new System.Windows.Forms.Button();
            this.Wire3 = new System.Windows.Forms.Button();
            this.Wire4 = new System.Windows.Forms.Button();
            this.Wire5 = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // LabelRules
            // 
            this.LabelRules.AutoSize = true;
            this.LabelRules.Font = new System.Drawing.Font("Modern No. 20", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelRules.Location = new System.Drawing.Point(27, 19);
            this.LabelRules.Name = "LabelRules";
            this.LabelRules.Size = new System.Drawing.Size(64, 21);
            this.LabelRules.TabIndex = 0;
            this.LabelRules.Text = "Rules:";
            // 
            // Rule1
            // 
            this.Rule1.AutoSize = true;
            this.Rule1.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rule1.Location = new System.Drawing.Point(28, 50);
            this.Rule1.Name = "Rule1";
            this.Rule1.Size = new System.Drawing.Size(298, 18);
            this.Rule1.TabIndex = 1;
            this.Rule1.Text = "If there are no red wires, cut the second wire";
            // 
            // Rule2
            // 
            this.Rule2.AutoSize = true;
            this.Rule2.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rule2.Location = new System.Drawing.Point(28, 70);
            this.Rule2.Name = "Rule2";
            this.Rule2.Size = new System.Drawing.Size(345, 18);
            this.Rule2.TabIndex = 2;
            this.Rule2.Text = "Otherwise, if the last wire is white, cut the last wire";
            // 
            // Rule3
            // 
            this.Rule3.AutoSize = true;
            this.Rule3.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rule3.Location = new System.Drawing.Point(28, 90);
            this.Rule3.Name = "Rule3";
            this.Rule3.Size = new System.Drawing.Size(451, 18);
            this.Rule3.TabIndex = 3;
            this.Rule3.Text = "Otherwise, if there is more than one blue wire, cut the last blue wire";
            // 
            // Rule4
            // 
            this.Rule4.AutoSize = true;
            this.Rule4.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rule4.Location = new System.Drawing.Point(28, 110);
            this.Rule4.Name = "Rule4";
            this.Rule4.Size = new System.Drawing.Size(184, 18);
            this.Rule4.TabIndex = 4;
            this.Rule4.Text = "Otherwise, cut the last wire";
            // 
            // TimerBar
            // 
            this.TimerBar.Location = new System.Drawing.Point(31, 420);
            this.TimerBar.Name = "TimerBar";
            this.TimerBar.Size = new System.Drawing.Size(203, 29);
            this.TimerBar.TabIndex = 5;
            // 
            // LabelTimer
            // 
            this.LabelTimer.AutoSize = true;
            this.LabelTimer.Font = new System.Drawing.Font("Modern No. 20", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelTimer.Location = new System.Drawing.Point(27, 396);
            this.LabelTimer.Name = "LabelTimer";
            this.LabelTimer.Size = new System.Drawing.Size(214, 21);
            this.LabelTimer.TabIndex = 6;
            this.LabelTimer.Text = "Time Until Detonation:";
            // 
            // ButtonStart
            // 
            this.ButtonStart.Font = new System.Drawing.Font("Modern No. 20", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonStart.Location = new System.Drawing.Point(584, 19);
            this.ButtonStart.Name = "ButtonStart";
            this.ButtonStart.Size = new System.Drawing.Size(130, 130);
            this.ButtonStart.TabIndex = 7;
            this.ButtonStart.Text = "Start";
            this.ButtonStart.UseVisualStyleBackColor = true;
            this.ButtonStart.Click += new System.EventHandler(this.ButtonStart_Click);
            // 
            // Wire1
            // 
            this.Wire1.BackColor = System.Drawing.Color.Red;
            this.Wire1.Enabled = false;
            this.Wire1.Location = new System.Drawing.Point(90, 200);
            this.Wire1.Name = "Wire1";
            this.Wire1.Size = new System.Drawing.Size(600, 20);
            this.Wire1.TabIndex = 8;
            this.Wire1.UseVisualStyleBackColor = false;
            this.Wire1.Click += new System.EventHandler(this.Wire_Click);
            // 
            // Wire2
            // 
            this.Wire2.BackColor = System.Drawing.Color.Black;
            this.Wire2.Enabled = false;
            this.Wire2.Location = new System.Drawing.Point(90, 226);
            this.Wire2.Name = "Wire2";
            this.Wire2.Size = new System.Drawing.Size(600, 20);
            this.Wire2.TabIndex = 9;
            this.Wire2.UseVisualStyleBackColor = false;
            this.Wire2.Click += new System.EventHandler(this.Wire_Click);
            // 
            // Wire3
            // 
            this.Wire3.BackColor = System.Drawing.Color.Blue;
            this.Wire3.Enabled = false;
            this.Wire3.Location = new System.Drawing.Point(90, 252);
            this.Wire3.Name = "Wire3";
            this.Wire3.Size = new System.Drawing.Size(600, 20);
            this.Wire3.TabIndex = 10;
            this.Wire3.UseVisualStyleBackColor = false;
            this.Wire3.Click += new System.EventHandler(this.Wire_Click);
            // 
            // Wire4
            // 
            this.Wire4.BackColor = System.Drawing.Color.White;
            this.Wire4.Enabled = false;
            this.Wire4.Location = new System.Drawing.Point(90, 278);
            this.Wire4.Name = "Wire4";
            this.Wire4.Size = new System.Drawing.Size(600, 20);
            this.Wire4.TabIndex = 11;
            this.Wire4.UseVisualStyleBackColor = false;
            this.Wire4.Click += new System.EventHandler(this.Wire_Click);
            // 
            // Wire5
            // 
            this.Wire5.BackColor = System.Drawing.Color.Yellow;
            this.Wire5.Enabled = false;
            this.Wire5.Location = new System.Drawing.Point(90, 304);
            this.Wire5.Name = "Wire5";
            this.Wire5.Size = new System.Drawing.Size(600, 20);
            this.Wire5.TabIndex = 12;
            this.Wire5.UseVisualStyleBackColor = false;
            this.Wire5.Click += new System.EventHandler(this.Wire_Click);
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.Wire5);
            this.Controls.Add(this.Wire4);
            this.Controls.Add(this.Wire3);
            this.Controls.Add(this.Wire2);
            this.Controls.Add(this.Wire1);
            this.Controls.Add(this.ButtonStart);
            this.Controls.Add(this.LabelTimer);
            this.Controls.Add(this.TimerBar);
            this.Controls.Add(this.Rule4);
            this.Controls.Add(this.Rule3);
            this.Controls.Add(this.Rule2);
            this.Controls.Add(this.Rule1);
            this.Controls.Add(this.LabelRules);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Proceed To Converse and none shall Discharge Their Bodily Scraps Haphazardly";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LabelRules;
        private System.Windows.Forms.Label Rule1;
        private System.Windows.Forms.Label Rule2;
        private System.Windows.Forms.Label Rule3;
        private System.Windows.Forms.Label Rule4;
        private System.Windows.Forms.ProgressBar TimerBar;
        private System.Windows.Forms.Label LabelTimer;
        private System.Windows.Forms.Button ButtonStart;
        private System.Windows.Forms.Button Wire1;
        private System.Windows.Forms.Button Wire2;
        private System.Windows.Forms.Button Wire3;
        private System.Windows.Forms.Button Wire4;
        private System.Windows.Forms.Button Wire5;
        private System.Windows.Forms.Timer timer;
    }
}

