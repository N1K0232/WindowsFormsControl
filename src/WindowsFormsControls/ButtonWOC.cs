using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WindowsFormsControls
{
    public partial class ButtonWOC : Button
    {
        private const int BorderThickness = 6;
        private const int BorderThicknessByTwo = 3;

        private Color _borderColor = Color.Black;
        private Color _buttonColor = Color.RoyalBlue;
        private Color _textColor = Color.White;

        private Color _onHoverBorderColor = Color.Red;
        private Color _onHoverButtonColor = Color.Yellow;
        private Color _onHoverTextColor = Color.Black;

        private bool _isHovering = false;

        public ButtonWOC()
        {
            FlatAppearance.BorderColor = Color.White;
            FlatAppearance.BorderSize = 0;
            FlatAppearance.MouseOverBackColor = Color.White;
            FlatAppearance.MouseDownBackColor = Color.White;
            FlatStyle = FlatStyle.Flat;

            MinimumSize = new Size(150, 50);
            BackColor = Color.Transparent;
            Font = new Font("Segoe UI", 12F);

            MouseEnter += new EventHandler(Mouse_Enter);
            MouseLeave += new EventHandler(Mouse_Leave);
        }

        /// <summary>
        /// gets or sets the color of the border
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Category("Button appearance")]
        public Color BorderColor
        {
            get => _borderColor;
            set
            {
                _borderColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// gets or sets the color of the button
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Category("Button appearance")]
        public Color ButtonColor
        {
            get => _buttonColor;
            set
            {
                _buttonColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// gets or sets the color of the text
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Category("Button appearance")]
        public Color TextColor
        {
            get => _textColor;
            set
            {
                _textColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// gets or sets the color of the border when the mouse hovers the button
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Category("Button appearance")]
        public Color OnHoverBorderColor
        {
            get => _onHoverBorderColor;
            set
            {
                _onHoverBorderColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// gets or sets the color of the button when the mouse hovers it
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Category("Button appearance")]
        public Color OnHoverButtonColor
        {
            get => _onHoverButtonColor;
            set
            {
                _onHoverButtonColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// gets or sets the color of the text when the mouse hovers the button
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Category("Button appearance")]
        public Color OnHoverTextColor
        {
            get => _onHoverTextColor;
            set
            {
                _onHoverTextColor = value;
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

            DrawBorder(graphics);
            FillControl(graphics);
            DrawText(graphics);
        }

        /// <summary>
        /// draws the border of the control
        /// </summary>
        /// <param name="graphics">the graphics of the control</param>
        private void DrawBorder(Graphics graphics)
        {
            int width = Width;
            int height = Height;
            Color borderColor = _isHovering ? _onHoverBorderColor : _borderColor;
            SolidBrush brush = new(borderColor);
            graphics.FillEllipse(brush, 0, 0, height, height);
            graphics.FillEllipse(brush, width - height, 0, height, height);
            graphics.FillRectangle(brush, height / 2, 0, width - height, height);
            brush.Dispose();
        }

        /// <summary>
        /// fills the control
        /// </summary>
        /// <param name="graphics">the graphics of the control</param>
        private void FillControl(Graphics graphics)
        {
            int width = Width;
            int height = Height;
            Color buttonColor = _isHovering ? _onHoverButtonColor : _buttonColor;
            SolidBrush brush = new(buttonColor);

            graphics.FillEllipse(brush, BorderThicknessByTwo, BorderThicknessByTwo, height - BorderThickness,
                height - BorderThickness);
            graphics.FillEllipse(brush, (width - height) + BorderThicknessByTwo, BorderThicknessByTwo,
                height - BorderThickness, height - BorderThickness);
            graphics.FillRectangle(brush, height / 2 + BorderThicknessByTwo, BorderThicknessByTwo,
                width - height - BorderThickness, height - BorderThickness);

            brush.Dispose();
        }

        /// <summary>
        /// draws the text
        /// </summary>
        /// <param name="graphics">the graphics of the control</param>
        private void DrawText(Graphics graphics)
        {
            int width = Width;
            int height = Height;
            string text = Text;
            Font font = Font;
            SizeF stringSize = graphics.MeasureString(text, font);
            float textWidth = (width - stringSize.Width) / 2;
            float textHeight = (height - stringSize.Height) / 2;
            Color textColor = _isHovering ? _onHoverTextColor : _textColor;
            SolidBrush brush = new(textColor);
            graphics.DrawString(text, font, brush, textWidth, textHeight);
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