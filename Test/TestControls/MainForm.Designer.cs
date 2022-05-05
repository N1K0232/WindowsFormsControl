using System;
using System.ComponentModel;
using System.Drawing;
using WindowsFormsControls;

namespace TestControls
{
    public partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            firstButton = new ButtonWOC();
            secondButton = new RoundButton();
            thirdButton = new CuteButton();
            wfTextBox1 = new WFTextBox();
            wfDateTimePicker1 = new WFDateTimePicker();
            wfDateTimePicker2 = new WFDateTimePicker();
            wfDateTimePicker3 = new WFDateTimePicker();
            buttonwoc1 = new ButtonWOC();
            buttonwoc2 = new ButtonWOC();
            cuteRoundButton1 = new CuteRoundButton();
            SuspendLayout();
            // 
            // firstButton
            // 
            firstButton.BackColor = Color.Transparent;
            firstButton.BorderColor = Color.Black;
            firstButton.BorderThickness = 6;
            firstButton.BorderThicknessByTwo = 3;
            firstButton.ButtonColor = Color.RoyalBlue;
            firstButton.FlatAppearance.BorderColor = Color.White;
            firstButton.FlatAppearance.BorderSize = 0;
            firstButton.FlatAppearance.MouseDownBackColor = Color.White;
            firstButton.FlatAppearance.MouseOverBackColor = Color.White;
            firstButton.FlatStyle = FlatStyle.Flat;
            firstButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            firstButton.ForeColor = Color.Transparent;
            firstButton.Location = new Point(366, 243);
            firstButton.MinimumSize = new Size(150, 50);
            firstButton.Name = "firstButton";
            firstButton.OnHoverBorderColor = Color.Red;
            firstButton.OnHoverButtonColor = Color.Yellow;
            firstButton.OnHoverTextColor = Color.Black;
            firstButton.Size = new Size(188, 62);
            firstButton.TabIndex = 0;
            firstButton.Text = "first button";
            firstButton.TextColor = Color.White;
            firstButton.UseVisualStyleBackColor = false;
            // 
            // secondButton
            // 
            secondButton.BackColor = Color.RoyalBlue;
            secondButton.BorderColor = Color.PaleVioletRed;
            secondButton.BorderRadius = 40;
            secondButton.BorderSize = 0;
            secondButton.FlatAppearance.BorderSize = 0;
            secondButton.FlatStyle = FlatStyle.Flat;
            secondButton.ForeColor = Color.White;
            secondButton.Location = new Point(144, 120);
            secondButton.Name = "secondButton";
            secondButton.Size = new Size(188, 50);
            secondButton.TabIndex = 1;
            secondButton.Text = "second button";
            secondButton.UseVisualStyleBackColor = false;
            // 
            // thirdButton
            // 
            thirdButton.FirstColor = Color.LightGreen;
            thirdButton.FirstColorTransparency = 80;
            thirdButton.FlatAppearance.BorderColor = Color.White;
            thirdButton.FlatAppearance.BorderSize = 0;
            thirdButton.FlatStyle = FlatStyle.Flat;
            thirdButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            thirdButton.ForeColor = Color.Black;
            thirdButton.Location = new Point(472, 115);
            thirdButton.Name = "thirdButton";
            thirdButton.SecondColor = Color.DarkBlue;
            thirdButton.SecondColorTransparency = 80;
            thirdButton.Size = new Size(150, 62);
            thirdButton.TabIndex = 2;
            thirdButton.Text = "third button";
            thirdButton.UseVisualStyleBackColor = true;
            // 
            // wfTextBox1
            // 
            wfTextBox1.BackColor = Color.White;
            wfTextBox1.BorderColor = Color.RoyalBlue;
            wfTextBox1.BorderFocusColor = Color.HotPink;
            wfTextBox1.BorderSize = 2;
            wfTextBox1.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            wfTextBox1.ForeColor = Color.DimGray;
            wfTextBox1.Location = new Point(374, 377);
            wfTextBox1.Margin = new Padding(4);
            wfTextBox1.Multiline = false;
            wfTextBox1.Name = "wfTextBox1";
            wfTextBox1.Padding = new Padding(7);
            wfTextBox1.PasswordChar = false;
            wfTextBox1.Size = new Size(312, 36);
            wfTextBox1.TabIndex = 3;
            wfTextBox1.TextString = "";
            wfTextBox1.UnderlinedStyle = false;
            // 
            // wfDateTimePicker1
            // 
            wfDateTimePicker1.BorderColor = Color.PaleVioletRed;
            wfDateTimePicker1.BorderSize = 0;
            wfDateTimePicker1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            wfDateTimePicker1.Location = new Point(307, 45);
            wfDateTimePicker1.MinimumSize = new Size(0, 35);
            wfDateTimePicker1.Name = "wfDateTimePicker1";
            wfDateTimePicker1.Size = new Size(250, 35);
            wfDateTimePicker1.SkinColor = Color.MediumSlateBlue;
            wfDateTimePicker1.TabIndex = 4;
            wfDateTimePicker1.TextColor = Color.White;
            // 
            // wfDateTimePicker2
            // 
            wfDateTimePicker2.BorderColor = Color.PaleVioletRed;
            wfDateTimePicker2.BorderSize = 0;
            wfDateTimePicker2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            wfDateTimePicker2.Location = new Point(22, 45);
            wfDateTimePicker2.MinimumSize = new Size(0, 35);
            wfDateTimePicker2.Name = "wfDateTimePicker2";
            wfDateTimePicker2.Size = new Size(250, 35);
            wfDateTimePicker2.SkinColor = Color.MediumSlateBlue;
            wfDateTimePicker2.TabIndex = 5;
            wfDateTimePicker2.TextColor = Color.White;
            // 
            // wfDateTimePicker3
            // 
            wfDateTimePicker3.BorderColor = Color.PaleVioletRed;
            wfDateTimePicker3.BorderSize = 0;
            wfDateTimePicker3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            wfDateTimePicker3.Location = new Point(70, 310);
            wfDateTimePicker3.MinimumSize = new Size(0, 35);
            wfDateTimePicker3.Name = "wfDateTimePicker3";
            wfDateTimePicker3.Size = new Size(250, 35);
            wfDateTimePicker3.SkinColor = Color.RoyalBlue;
            wfDateTimePicker3.TabIndex = 6;
            wfDateTimePicker3.TextColor = Color.White;
            // 
            // buttonwoc1
            // 
            buttonwoc1.BackColor = Color.Transparent;
            buttonwoc1.BorderColor = Color.Black;
            buttonwoc1.BorderThickness = 6;
            buttonwoc1.BorderThicknessByTwo = 3;
            buttonwoc1.ButtonColor = Color.RoyalBlue;
            buttonwoc1.FlatAppearance.BorderColor = Color.White;
            buttonwoc1.FlatAppearance.BorderSize = 0;
            buttonwoc1.FlatAppearance.MouseDownBackColor = Color.White;
            buttonwoc1.FlatAppearance.MouseOverBackColor = Color.White;
            buttonwoc1.FlatStyle = FlatStyle.Flat;
            buttonwoc1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            buttonwoc1.ForeColor = Color.Transparent;
            buttonwoc1.Location = new Point(690, 108);
            buttonwoc1.MinimumSize = new Size(150, 50);
            buttonwoc1.Name = "buttonwoc1";
            buttonwoc1.OnHoverBorderColor = Color.Red;
            buttonwoc1.OnHoverButtonColor = Color.Yellow;
            buttonwoc1.OnHoverTextColor = Color.Black;
            buttonwoc1.Size = new Size(188, 62);
            buttonwoc1.TabIndex = 7;
            buttonwoc1.Text = "buttonwoc1";
            buttonwoc1.TextColor = Color.White;
            buttonwoc1.UseVisualStyleBackColor = false;
            // 
            // buttonwoc2
            // 
            buttonwoc2.BackColor = Color.Transparent;
            buttonwoc2.BorderColor = Color.Black;
            buttonwoc2.BorderThickness = 6;
            buttonwoc2.BorderThicknessByTwo = 3;
            buttonwoc2.ButtonColor = Color.RoyalBlue;
            buttonwoc2.FlatAppearance.BorderColor = Color.White;
            buttonwoc2.FlatAppearance.BorderSize = 0;
            buttonwoc2.FlatAppearance.MouseDownBackColor = Color.White;
            buttonwoc2.FlatAppearance.MouseOverBackColor = Color.White;
            buttonwoc2.FlatStyle = FlatStyle.Flat;
            buttonwoc2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            buttonwoc2.ForeColor = Color.Transparent;
            buttonwoc2.Location = new Point(681, 244);
            buttonwoc2.MinimumSize = new Size(150, 50);
            buttonwoc2.Name = "buttonwoc2";
            buttonwoc2.OnHoverBorderColor = Color.Red;
            buttonwoc2.OnHoverButtonColor = Color.Yellow;
            buttonwoc2.OnHoverTextColor = Color.Black;
            buttonwoc2.Size = new Size(188, 62);
            buttonwoc2.TabIndex = 8;
            buttonwoc2.Text = "buttonwoc2";
            buttonwoc2.TextColor = Color.White;
            buttonwoc2.UseVisualStyleBackColor = false;
            // 
            // cuteRoundButton1
            // 
            cuteRoundButton1.BackColor = Color.White;
            cuteRoundButton1.BorderColor = Color.White;
            cuteRoundButton1.BorderRadius = 40;
            cuteRoundButton1.BorderSize = 0;
            cuteRoundButton1.FirstColor = Color.LightGreen;
            cuteRoundButton1.FirstColorTransparency = 80;
            cuteRoundButton1.FlatAppearance.BorderSize = 0;
            cuteRoundButton1.FlatStyle = FlatStyle.Flat;
            cuteRoundButton1.ForeColor = Color.Black;
            cuteRoundButton1.Location = new Point(62, 203);
            cuteRoundButton1.Name = "cuteRoundButton1";
            cuteRoundButton1.SecondColor = Color.DarkBlue;
            cuteRoundButton1.SecondColorTransparency = 80;
            cuteRoundButton1.Size = new Size(188, 50);
            cuteRoundButton1.TabIndex = 9;
            cuteRoundButton1.Text = "cuteRoundButton1";
            cuteRoundButton1.UseVisualStyleBackColor = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(917, 457);
            Controls.Add(cuteRoundButton1);
            Controls.Add(buttonwoc2);
            Controls.Add(buttonwoc1);
            Controls.Add(wfDateTimePicker3);
            Controls.Add(wfDateTimePicker2);
            Controls.Add(wfDateTimePicker1);
            Controls.Add(wfTextBox1);
            Controls.Add(thirdButton);
            Controls.Add(secondButton);
            Controls.Add(firstButton);
            Name = "MainForm";
            Text = "Test";
            ResumeLayout(false);
        }

        private void ConfigureClickMethod()
        {
            foreach (Control c in Controls)
            {
                if (c is Button)
                {
                    Button b = c as Button;
                    b.Click += new EventHandler(Button_Click);
                }
            }
        }

        #endregion

        private ButtonWOC firstButton;
        private RoundButton secondButton;
        private CuteButton thirdButton;
        private WFTextBox wfTextBox1;
        private WFDateTimePicker wfDateTimePicker1;
        private WFDateTimePicker wfDateTimePicker2;
        private WFDateTimePicker wfDateTimePicker3;
        private ButtonWOC buttonwoc1;
        private ButtonWOC buttonwoc2;
        private CuteRoundButton cuteRoundButton1;
    }
}