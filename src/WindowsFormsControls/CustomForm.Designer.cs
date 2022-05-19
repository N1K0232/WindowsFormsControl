using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

namespace WindowsFormsControls;

public partial class CustomForm : Form
{
    private IContainer components = null;

    private Button minimizeButton;
    private Button maximizeButton;
    private Button exitButton;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }
    protected virtual void InitializeComponent()
    {
        components = new Container();

        minimizeButton = new Button();
        maximizeButton = new Button();
        exitButton = new Button();
        SuspendLayout();

        minimizeButton.Location = new Point(653, 0);
        minimizeButton.Name = "minimizeButton";
        minimizeButton.Size = new Size(50, 50);
        minimizeButton.TabIndex = 0;
        minimizeButton.Text = "_";
        minimizeButton.Click += new EventHandler(MinimizeButton_Click);

        maximizeButton.Location = new Point(701, 0);
        maximizeButton.Name = "maximizeButton";
        maximizeButton.Size = new Size(50, 50);
        maximizeButton.TabIndex = 1;
        maximizeButton.Text = "▢";
        maximizeButton.Click += new EventHandler(MaximizeButton_Click);

        exitButton.Location = new Point(749, 0);
        exitButton.Name = "exitButton";
        exitButton.Size = new Size(50, 50);
        exitButton.Text = "X";
        exitButton.TabIndex = 2;
        exitButton.Click += new EventHandler(ExitButton_Click);

        BackColor = Color.White;
        ClientSize = new Size(800, 450);
        ControlBox = false;
        Controls.Add(minimizeButton);
        Controls.Add(maximizeButton);
        Controls.Add(exitButton);
        ForeColor = Color.Black;
        MaximizeBox = false;
        MinimizeBox = false;
        ResumeLayout(false);
    }

    private void MinimizeButton_Click(object sender, EventArgs e) => Minimize();
    private void MaximizeButton_Click(object sender, EventArgs e) => Maximize();
    private void ExitButton_Click(object sender, EventArgs e) => Application.Exit();

    private void Minimize()
    {
        if (WindowState != FormWindowState.Minimized)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
    private void Maximize()
    {
        if (WindowState == FormWindowState.Normal)
        {
            WindowState = FormWindowState.Maximized;
        }
        if (WindowState == FormWindowState.Maximized)
        {
            WindowState = FormWindowState.Normal;
        }
    }
}