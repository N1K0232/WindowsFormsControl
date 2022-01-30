using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsControls
{
    public partial class ColorPicker : UserControl
    {
        private int _red;
        private int _green;
        private int _blue;

        public ColorPicker()
        {
            InitializeComponent();
        }

        public Color Result
        {
            get => colorPanel.BackColor;
        }

        private void ColorPicker_Load(object sender, EventArgs e)
        {
            _red = int.Parse(txtRed.Text);
            _green = int.Parse(txtGreen.Text);
            _blue = int.Parse(txtBlue.Text);
            UpdatePanelColor();
        }
        private void RedTrackBar_OnScroll(object sender, EventArgs e)
        {
            _red = tbRed.Value;
            txtRed.Text = Convert.ToString(_red);
            UpdatePanelColor();
        }
        private void GreenTrackBar_OnScroll(object sender, EventArgs e)
        {
            _green = tbGreen.Value;
            txtGreen.Text = Convert.ToString(_green);
            UpdatePanelColor();
        }
        private void BlueTrackBar_OnScroll(object sender, EventArgs e)
        {
            _blue = tbBlue.Value;
            txtBlue.Text = Convert.ToString(_blue);
            UpdatePanelColor();
        }
        private void RedTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtRed.Text))
            {
                _red = int.Parse(txtRed.Text);
                tbRed.Value = _red;
                UpdatePanelColor();
            }
        }
        private void GreenTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtGreen.Text))
            {
                _green = int.Parse(txtGreen.Text);
                tbGreen.Value = _green;
                UpdatePanelColor();
            }
        }
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

        private void UpdatePanelColor()
        {
            Color color = GetColor();
            colorPanel.BackColor = color;
        }
        private Color GetColor() => Color.FromArgb(_red, _green, _blue);
    }
}