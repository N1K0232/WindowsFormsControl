namespace TestControls
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.firstButton = new WindowsFormsControls.ButtonWOC();
            this.secondButton = new WindowsFormsControls.RoundButton();
            this.thirdButton = new WindowsFormsControls.CuteButton();
            this.wfTextBox1 = new WindowsFormsControls.WFTextBox();
            this.wfDateTimePicker1 = new WindowsFormsControls.WFDateTimePicker();
            this.wfDateTimePicker2 = new WindowsFormsControls.WFDateTimePicker();
            this.wfDateTimePicker3 = new WindowsFormsControls.WFDateTimePicker();
            this.buttonwoc1 = new WindowsFormsControls.ButtonWOC();
            this.SuspendLayout();
            // 
            // firstButton
            // 
            this.firstButton.BackColor = System.Drawing.Color.Transparent;
            this.firstButton.BorderColor = System.Drawing.Color.Black;
            this.firstButton.BorderThickness = 6;
            this.firstButton.BorderThicknessByTwo = 3;
            this.firstButton.ButtonColor = System.Drawing.Color.RoyalBlue;
            this.firstButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.firstButton.FlatAppearance.BorderSize = 0;
            this.firstButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.firstButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.firstButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.firstButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.firstButton.ForeColor = System.Drawing.Color.Transparent;
            this.firstButton.Location = new System.Drawing.Point(366, 243);
            this.firstButton.MinimumSize = new System.Drawing.Size(150, 50);
            this.firstButton.Name = "firstButton";
            this.firstButton.OnHoverBorderColor = System.Drawing.Color.Red;
            this.firstButton.OnHoverButtonColor = System.Drawing.Color.Yellow;
            this.firstButton.OnHoverTextColor = System.Drawing.Color.Black;
            this.firstButton.Size = new System.Drawing.Size(188, 62);
            this.firstButton.TabIndex = 0;
            this.firstButton.Text = "first button";
            this.firstButton.TextColor = System.Drawing.Color.White;
            this.firstButton.UseVisualStyleBackColor = false;
            this.firstButton.Click += new System.EventHandler(this.Button_Click);
            // 
            // secondButton
            // 
            this.secondButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.secondButton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.secondButton.BorderRadius = 40;
            this.secondButton.BorderSize = 0;
            this.secondButton.FlatAppearance.BorderSize = 0;
            this.secondButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.secondButton.ForeColor = System.Drawing.Color.White;
            this.secondButton.Location = new System.Drawing.Point(144, 120);
            this.secondButton.Name = "secondButton";
            this.secondButton.Size = new System.Drawing.Size(188, 50);
            this.secondButton.TabIndex = 1;
            this.secondButton.Text = "second button";
            this.secondButton.UseVisualStyleBackColor = false;
            this.secondButton.Click += new System.EventHandler(this.Button_Click);
            // 
            // thirdButton
            // 
            this.thirdButton.FirstColor = System.Drawing.Color.LightGreen;
            this.thirdButton.FirstColorTransparency = 80;
            this.thirdButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.thirdButton.FlatAppearance.BorderSize = 0;
            this.thirdButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.thirdButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.thirdButton.ForeColor = System.Drawing.Color.Black;
            this.thirdButton.Location = new System.Drawing.Point(472, 115);
            this.thirdButton.Name = "thirdButton";
            this.thirdButton.SecondColor = System.Drawing.Color.DarkBlue;
            this.thirdButton.SecondColorTransparency = 80;
            this.thirdButton.Size = new System.Drawing.Size(150, 62);
            this.thirdButton.TabIndex = 2;
            this.thirdButton.Text = "third button";
            this.thirdButton.UseVisualStyleBackColor = true;
            this.thirdButton.Click += new System.EventHandler(this.Button_Click);
            // 
            // wfTextBox1
            // 
            this.wfTextBox1.BackColor = System.Drawing.Color.White;
            this.wfTextBox1.BorderColor = System.Drawing.Color.RoyalBlue;
            this.wfTextBox1.BorderFocusColor = System.Drawing.Color.HotPink;
            this.wfTextBox1.BorderSize = 2;
            this.wfTextBox1.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.wfTextBox1.ForeColor = System.Drawing.Color.DimGray;
            this.wfTextBox1.Location = new System.Drawing.Point(374, 377);
            this.wfTextBox1.Margin = new System.Windows.Forms.Padding(4);
            this.wfTextBox1.Multiline = false;
            this.wfTextBox1.Name = "wfTextBox1";
            this.wfTextBox1.Padding = new System.Windows.Forms.Padding(7);
            this.wfTextBox1.PasswordChar = false;
            this.wfTextBox1.Size = new System.Drawing.Size(312, 36);
            this.wfTextBox1.TabIndex = 3;
            this.wfTextBox1.TextString = "";
            this.wfTextBox1.UnderlinedStyle = false;
            // 
            // wfDateTimePicker1
            // 
            this.wfDateTimePicker1.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.wfDateTimePicker1.BorderSize = 0;
            this.wfDateTimePicker1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.wfDateTimePicker1.Location = new System.Drawing.Point(307, 45);
            this.wfDateTimePicker1.MinimumSize = new System.Drawing.Size(0, 35);
            this.wfDateTimePicker1.Name = "wfDateTimePicker1";
            this.wfDateTimePicker1.Size = new System.Drawing.Size(250, 35);
            this.wfDateTimePicker1.SkinColor = System.Drawing.Color.MediumSlateBlue;
            this.wfDateTimePicker1.TabIndex = 4;
            this.wfDateTimePicker1.TextColor = System.Drawing.Color.White;
            // 
            // wfDateTimePicker2
            // 
            this.wfDateTimePicker2.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.wfDateTimePicker2.BorderSize = 0;
            this.wfDateTimePicker2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.wfDateTimePicker2.Location = new System.Drawing.Point(22, 45);
            this.wfDateTimePicker2.MinimumSize = new System.Drawing.Size(0, 35);
            this.wfDateTimePicker2.Name = "wfDateTimePicker2";
            this.wfDateTimePicker2.Size = new System.Drawing.Size(250, 35);
            this.wfDateTimePicker2.SkinColor = System.Drawing.Color.MediumSlateBlue;
            this.wfDateTimePicker2.TabIndex = 5;
            this.wfDateTimePicker2.TextColor = System.Drawing.Color.White;
            // 
            // wfDateTimePicker3
            // 
            this.wfDateTimePicker3.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.wfDateTimePicker3.BorderSize = 0;
            this.wfDateTimePicker3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.wfDateTimePicker3.Location = new System.Drawing.Point(70, 310);
            this.wfDateTimePicker3.MinimumSize = new System.Drawing.Size(0, 35);
            this.wfDateTimePicker3.Name = "wfDateTimePicker3";
            this.wfDateTimePicker3.Size = new System.Drawing.Size(250, 35);
            this.wfDateTimePicker3.SkinColor = System.Drawing.Color.RoyalBlue;
            this.wfDateTimePicker3.TabIndex = 6;
            this.wfDateTimePicker3.TextColor = System.Drawing.Color.White;
            // 
            // buttonwoc1
            // 
            this.buttonwoc1.BackColor = System.Drawing.Color.Transparent;
            this.buttonwoc1.BorderColor = System.Drawing.Color.Black;
            this.buttonwoc1.BorderThickness = 6;
            this.buttonwoc1.BorderThicknessByTwo = 3;
            this.buttonwoc1.ButtonColor = System.Drawing.Color.RoyalBlue;
            this.buttonwoc1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonwoc1.FlatAppearance.BorderSize = 0;
            this.buttonwoc1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.buttonwoc1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.buttonwoc1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonwoc1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonwoc1.ForeColor = System.Drawing.Color.Transparent;
            this.buttonwoc1.Location = new System.Drawing.Point(690, 108);
            this.buttonwoc1.MinimumSize = new System.Drawing.Size(150, 50);
            this.buttonwoc1.Name = "buttonwoc1";
            this.buttonwoc1.OnHoverBorderColor = System.Drawing.Color.Red;
            this.buttonwoc1.OnHoverButtonColor = System.Drawing.Color.Yellow;
            this.buttonwoc1.OnHoverTextColor = System.Drawing.Color.Black;
            this.buttonwoc1.Size = new System.Drawing.Size(188, 62);
            this.buttonwoc1.TabIndex = 7;
            this.buttonwoc1.Text = "buttonwoc1";
            this.buttonwoc1.TextColor = System.Drawing.Color.White;
            this.buttonwoc1.UseVisualStyleBackColor = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(917, 457);
            this.Controls.Add(this.buttonwoc1);
            this.Controls.Add(this.wfDateTimePicker3);
            this.Controls.Add(this.wfDateTimePicker2);
            this.Controls.Add(this.wfDateTimePicker1);
            this.Controls.Add(this.wfTextBox1);
            this.Controls.Add(this.thirdButton);
            this.Controls.Add(this.secondButton);
            this.Controls.Add(this.firstButton);
            this.Name = "MainForm";
            this.Text = "Test";
            this.ResumeLayout(false);

        }

        #endregion

        private WindowsFormsControls.ButtonWOC firstButton;
        private WindowsFormsControls.RoundButton secondButton;
        private WindowsFormsControls.CuteButton thirdButton;
        private WindowsFormsControls.WFTextBox wfTextBox1;
        private WindowsFormsControls.WFDateTimePicker wfDateTimePicker1;
        private WindowsFormsControls.WFDateTimePicker wfDateTimePicker2;
        private WindowsFormsControls.WFDateTimePicker wfDateTimePicker3;
        private WindowsFormsControls.ButtonWOC buttonwoc1;
    }
}