using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsControls
{
    /// <summary>
    /// represents a windows forms color picker
    /// </summary>
    public partial class ColorPicker : UserControl
    {
        private int _red;
        private int _green;
        private int _blue;

        /// <summary>
        /// 
        /// </summary>
        public ColorPicker()
        {
            InitializeComponent();
        }

        /// <summary>
        /// creates a new instance of the <see cref="ColorPicker"/>
        /// class
        /// </summary>
        public Color Result
        {
            get => colorPanel.BackColor;
        }

        /// <summary>
        /// this method is called when the control is loaded
        /// </summary>
        /// <param name="sender">the object that called the event</param>
        /// <param name="e">the event information</param>
        private void ColorPicker_Load(object sender, EventArgs e)
        {
            _red = int.Parse(txtRed.Text);
            _green = int.Parse(txtGreen.Text);
            _blue = int.Parse(txtBlue.Text);
            UpdatePanelColor();
        }

        /// <summary>
        /// this method is called when the red trackbar is scrolled
        /// </summary>
        /// <param name="sender">the object that called the event</param>
        /// <param name="e">the event information</param>
        private void RedTrackBar_OnScroll(object sender, EventArgs e)
        {
            _red = tbRed.Value;
            txtRed.Text = Convert.ToString(_red);
            UpdatePanelColor();
        }

        /// <summary>
        /// this method is called when the green trackbar is scrolled
        /// </summary>
        /// <param name="sender">the object that called the event</param>
        /// <param name="e">the event information</param>
        private void GreenTrackBar_OnScroll(object sender, EventArgs e)
        {
            _green = tbGreen.Value;
            txtGreen.Text = Convert.ToString(_green);
            UpdatePanelColor();
        }

        /// <summary>
        /// this method is called when the blue trackbar is scrolled
        /// </summary>
        /// <param name="sender">the object that called the event</param>
        /// <param name="e">the event information</param>
        private void BlueTrackBar_OnScroll(object sender, EventArgs e)
        {
            _blue = tbBlue.Value;
            txtBlue.Text = Convert.ToString(_blue);
            UpdatePanelColor();
        }

        /// <summary>
        /// this method is called when the text of the red textbox is changed
        /// </summary>
        /// <param name="sender">the object that called the event</param>
        /// <param name="e">the event information</param>
        private void RedTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtRed.Text))
            {
                _red = int.Parse(txtRed.Text);
                tbRed.Value = _red;
                UpdatePanelColor();
            }
        }

        /// <summary>
        /// this method is called when the text of the green textbox is changed
        /// </summary>
        /// <param name="sender">the object that called the event</param>
        /// <param name="e">the event information</param>
        private void GreenTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtGreen.Text))
            {
                _green = int.Parse(txtGreen.Text);
                tbGreen.Value = _green;
                UpdatePanelColor();
            }
        }

        /// <summary>
        /// this method is called when the text of the blue textbox is changed
        /// </summary>
        /// <param name="sender">the object that called the event</param>
        /// <param name="e">the event information</param>
        private void BlueTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBlue.Text))
            {
                _blue = int.Parse(txtBlue.Text);
                if (_blue > 255)
                {
                    _blue = 255;
                }
                tbBlue.Value = _blue;
                UpdatePanelColor();
            }
        }

        /// <summary>
        /// updates the background color of the panel 
        /// </summary>
        private void UpdatePanelColor()
        {
            Color color = GetColor();
            colorPanel.BackColor = color;
        }

        /// <summary>
        /// gets the color
        /// </summary>
        /// <returns></returns>
        private Color GetColor() => Color.FromArgb(_red, _green, _blue);
    }
}