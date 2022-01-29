using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsControls
{
    public partial class WFTextBox
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox = new TextBox();
            this.SuspendLayout();
            // 
            // textBox1
            // 
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
            // 
            // CustomTextBox
            // 
            this.AutoScaleMode = AutoScaleMode.None;
            this.BackColor = SystemColors.Window;
            this.Controls.Add(textBox);
            this.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            this.ForeColor = Color.DimGray;
            this.Name = "WFTextBox";
            this.Padding = new Padding(10, 7, 10, 7);
            this.Size = new Size(250, 30);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}