using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WindowsFormsControls
{
    public partial class CuteButton : Button
    {
        private Color _firstColor;
        private Color _secondColor;

        private Color _onHoverFirstColor;
        private Color _onHoverSecondColor;

        private int _firstColorTransparency;
        private int _secondColorTransparency;

        private bool _isHovering;

        public CuteButton()
        {
            _firstColor = Color.LightGreen;
            _secondColor = Color.DarkBlue;

            _onHoverFirstColor = Color.DarkGreen;
            _onHoverSecondColor = Color.LightBlue;

            _firstColorTransparency = 80;
            _secondColorTransparency = 80;

            _isHovering = false;

            Size = new Size(120, 50);
            ForeColor = Color.Black;
            Font = new Font("Segoe UI", 12f);
            FlatAppearance.BorderColor = Color.White;
            FlatAppearance.BorderSize = 0;
            FlatStyle = FlatStyle.Flat;

            MouseEnter += new EventHandler(Mouse_Enter);
            MouseLeave += new EventHandler(Mouse_Leave);
        }

        /// <summary>
        /// gets or sets the first color of the button
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Category("Button appearance")]
        public Color FirstColor
        {
            get => _firstColor;
            set
            {
                _firstColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// gets or sets the second color of the button
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Category("Button appearance")]
        public Color SecondColor
        {
            get => _secondColor;
            set
            {
                _secondColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// gets or sets the first color of the button when the mouse hovers it
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Category("Button appearance")]
        public Color OnHoverFirstColor
        {
            get => _onHoverFirstColor;
            set
            {
                _onHoverFirstColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// gets or sets the second color of the button when the mouse hovers it
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Category("Button appearance")]
        public Color OnHoverSecondColor
        {
            get => _onHoverSecondColor;
            set
            {
                _onHoverSecondColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// gets or sets the color transparency of the first color
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Category("Button appearance")]
        public int FirstColorTransparency
        {
            get => _firstColorTransparency;
            set
            {
                _firstColorTransparency = value;
                Invalidate();
            }
        }

        /// <summary>
        /// gets or sets the color transparency of the second color
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Category("Button appearance")]
        public int SecondColorTransparency
        {
            get => _secondColorTransparency;
            set
            {
                _secondColorTransparency = value;
                Invalidate();
            }
        }

        /// <summary>
        /// redraws the control
        /// </summary>
        /// <param name="pe"></param>
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            Graphics graphics = pe.Graphics;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Color c1 = Color.FromArgb(_firstColorTransparency, _isHovering ? _onHoverFirstColor : _firstColor);
            Color c2 = Color.FromArgb(_secondColorTransparency, _isHovering ? _onHoverSecondColor : _secondColor);

            Rectangle rectangle = ClientRectangle;
            Brush brush = new LinearGradientBrush(rectangle, c1, c2, 10);

            graphics.FillRectangle(brush, rectangle);
            brush.Dispose();
        }

        /// <summary>
        /// called when the mouse enters the control
        /// </summary>
        /// <param name="sender">the object that invoked the method</param>
        /// <param name="e">the event informations</param>
        private void Mouse_Enter(object sender, EventArgs e)
        {
            _isHovering = true;
            Invalidate();
        }

        /// <summary>
        /// called when the mouse leaves the control
        /// </summary>
        /// <param name="sender">the object that invoked the method</param>
        /// <param name="e">the event informations</param>
        private void Mouse_Leave(object sender, EventArgs e)
        {
            _isHovering = false;
            Invalidate();
        }
    }
}