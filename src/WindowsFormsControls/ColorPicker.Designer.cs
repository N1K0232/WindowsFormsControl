using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsControls
{
    public partial class ColorPicker
    {
        private IContainer components = null;

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
        private void InitializeComponent()
        {
            tbRed = new TrackBar();
            tbGreen = new TrackBar();
            tbBlue = new TrackBar();
            txtRed = new TextBox();
            txtGreen = new TextBox();
            txtBlue = new TextBox();
            colorPanel = new Panel();
            ((ISupportInitialize)(tbRed)).BeginInit();
            ((ISupportInitialize)(tbGreen)).BeginInit();
            ((ISupportInitialize)(tbBlue)).BeginInit();
            SuspendLayout();
            // 
            // tbRed
            // 
            tbRed.Location = new Point(8, 19);
            tbRed.Maximum = 255;
            tbRed.Name = "tbRed";
            tbRed.Size = new Size(1077, 56);
            tbRed.TabIndex = 0;
            tbRed.Scroll += new EventHandler(RedTrackBar_OnScroll);
            // 
            // tbGreen
            // 
            tbGreen.Location = new Point(8, 81);
            tbGreen.Maximum = 255;
            tbGreen.Name = "tbGreen";
            tbGreen.Size = new Size(1077, 56);
            tbGreen.TabIndex = 1;
            tbGreen.Scroll += new EventHandler(GreenTrackBar_OnScroll);
            // 
            // tbBlue
            // 
            tbBlue.Location = new Point(8, 143);
            tbBlue.Maximum = 255;
            tbBlue.Name = "tbBlue";
            tbBlue.Size = new Size(1077, 56);
            tbBlue.TabIndex = 2;
            tbBlue.Scroll += new EventHandler(BlueTrackBar_OnScroll);
            // 
            // txtRed
            // 
            txtRed.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            txtRed.ForeColor = Color.Red;
            txtRed.Location = new Point(1101, 12);
            txtRed.Name = "txtRed";
            txtRed.Size = new Size(125, 39);
            txtRed.TabIndex = 3;
            txtRed.Text = "0";
            txtRed.TextAlign = HorizontalAlignment.Right;
            txtRed.TextChanged += new EventHandler(RedTextBox_TextChanged);
            // 
            // txtGreen
            // 
            txtGreen.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            txtGreen.ForeColor = Color.Green;
            txtGreen.Location = new Point(1101, 73);
            txtGreen.Name = "txtGreen";
            txtGreen.Size = new Size(125, 39);
            txtGreen.TabIndex = 4;
            txtGreen.Text = "0";
            txtGreen.TextAlign = HorizontalAlignment.Right;
            txtGreen.TextChanged += new EventHandler(GreenTextBox_TextChanged);
            // 
            // txtBlue
            // 
            txtBlue.BackColor = Color.White;
            txtBlue.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            txtBlue.ForeColor = Color.Blue;
            txtBlue.Location = new Point(1101, 135);
            txtBlue.Name = "txtBlue";
            txtBlue.Size = new Size(125, 39);
            txtBlue.TabIndex = 5;
            txtBlue.Text = "0";
            txtBlue.TextAlign = HorizontalAlignment.Right;
            txtBlue.TextChanged += new EventHandler(BlueTextBox_TextChanged);
            // 
            // colorPanel
            // 
            colorPanel.Location = new Point(8, 232);
            colorPanel.Name = "colorPanel";
            colorPanel.Size = new Size(1063, 330);
            colorPanel.TabIndex = 6;
            // 
            // ColorPicker
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(colorPanel);
            Controls.Add(txtBlue);
            Controls.Add(txtGreen);
            Controls.Add(txtRed);
            Controls.Add(tbBlue);
            Controls.Add(tbGreen);
            Controls.Add(tbRed);
            Name = "ColorPicker";
            Size = new Size(1239, 579);
            Load += new EventHandler(ColorPicker_Load);
            ((ISupportInitialize)(tbRed)).EndInit();
            ((ISupportInitialize)(tbGreen)).EndInit();
            ((ISupportInitialize)(tbBlue)).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private TrackBar tbRed;
        private TrackBar tbGreen;
        private TrackBar tbBlue;
        private TextBox txtRed;
        private TextBox txtGreen;
        private TextBox txtBlue;
        private Panel colorPanel;
    }
}