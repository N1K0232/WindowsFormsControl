using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WindowsFormsControls
{
    public partial class ButtonWOC : Button
    {
        private const int BorderThickness = 6;
        private const int BorderThicknessByTwo = 3;

        private Color _borderColor;
        private Color _buttonColor;
        private Color _textColor;

        private Color _onHoverBorderColor;
        private Color _onHoverButtonColor;
        private Color _onHoverTextColor;

        private bool _isHovering;

        public ButtonWOC()
        {
            _borderColor = Color.Black;
            _buttonColor = Color.Blue;
            _textColor = Color.White;

            _onHoverBorderColor = Color.Red;
            _onHoverButtonColor = Color.Yellow;
            _onHoverTextColor = Color.Black;

            _isHovering = false;

            MouseEnter += new EventHandler(Mouse_Enter);
            MouseLeave += new EventHandler(Mouse_Leave);
        }

        public Color BorderColor
        {
            get => _borderColor;
            set
            {
                _borderColor = value;
                Invalidate();
            }
        }
        public Color ButtonColor
        {
            get => _buttonColor;
            set
            {
                _buttonColor = value;
                Invalidate();
            }
        }
        public Color TextColor
        {
            get => _textColor;
            set
            {
                _textColor = value;
                Invalidate();
            }
        }

        public Color OnHoverBorderColor
        {
            get => _onHoverBorderColor;
            set
            {
                _onHoverBorderColor = value;
                Invalidate();
            }
        }
        public Color OnHoverButtonColor
        {
            get => _onHoverButtonColor;
            set
            {
                _onHoverButtonColor = value;
                Invalidate();
            }
        }
        public Color OnHoverTextColor
        {
            get => _onHoverTextColor;
            set
            {
                _onHoverTextColor = value;
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            Graphics graphics = pe.Graphics;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Brush brush = new SolidBrush(_isHovering ? _onHoverBorderColor : _borderColor);
            graphics.FillEllipse(brush, 0, 0, Height, Height);
            graphics.FillEllipse(brush, Width - Height, 0, Height, Height);
            graphics.FillRectangle(brush, Height / 2, 0, Width - Height, Height);

            brush.Dispose();
            brush = new SolidBrush(_isHovering ? _onHoverButtonColor : _buttonColor);

            graphics.FillEllipse(brush, BorderThicknessByTwo, BorderThicknessByTwo, Height - BorderThickness,
                Height - BorderThickness);
            graphics.FillEllipse(brush, (Width - Height) + BorderThicknessByTwo, BorderThicknessByTwo,
                Height - BorderThickness, Height - BorderThickness);
            graphics.FillRectangle(brush, Height / 2 + BorderThicknessByTwo, BorderThicknessByTwo,
                Width - Height - BorderThickness, Height - BorderThickness);

            brush.Dispose();
            brush = new SolidBrush(_isHovering ? _onHoverTextColor : _textColor);

            SizeF stringSize = graphics.MeasureString(Text, Font);
            graphics.DrawString(Text, Font, brush, (Width - stringSize.Width) / 2, (Height - stringSize.Height) / 2);
        }

        private void Mouse_Enter(object sender, EventArgs e)
        {
            _isHovering = true;
            Invalidate();
        }
        private void Mouse_Leave(object sender, EventArgs e)
        {
            _isHovering = false;
            Invalidate();
        }
    }
}