using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsControls
{
    public partial class WFTextBox
    {
        private IContainer components = null;
        private TextBox textBox;

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

        /// <summary> 
        /// Initializes the control
        /// </summary>
        private void InitializeComponent()
        {
            components = new Container();

            textBox = new TextBox();
            SuspendLayout();

            textBox.BorderStyle = BorderStyle.None;
            textBox.Dock = DockStyle.Fill;
            textBox.ForeColor = Color.Black;
            textBox.Location = new Point(10, 7);
            textBox.Name = "textBox";
            textBox.Size = new Size(230, 22);
            textBox.TabIndex = 0;
            textBox.Click += new EventHandler(TextBox_Click);
            textBox.TextChanged += new EventHandler(TextBox_TextChanged);
            textBox.Enter += new EventHandler(TextBox_Enter);
            textBox.KeyPress += new KeyPressEventHandler(TextBox_KeyPress);
            textBox.Leave += new EventHandler(TextBox_Leave);
            textBox.MouseEnter += new EventHandler(TextBox_MouseEnter);
            textBox.MouseLeave += new EventHandler(TextBox_MouseLeave);

            AutoScaleMode = AutoScaleMode.None;
            BackColor = SystemColors.Window;
            Controls.Add(textBox);
            Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            ForeColor = Color.DimGray;
            Name = "WFTextBox";
            Padding = new Padding(10, 7, 10, 7);
            Size = new Size(250, 30);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}