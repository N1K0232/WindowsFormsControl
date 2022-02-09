using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsControls
{
    /// <summary>
    /// represents a custom windows date time picker
    /// </summary>
    public partial class WFDateTimePicker : DateTimePicker
    {
        private const int CalendarIconWidth = 34;
        private const int ArrowIconWidth = 17;

        private Color _skinColor = Color.RoyalBlue;
        private Color _textColor = Color.White;
        private Color _borderColor = Color.PaleVioletRed;
        private int _borderSize = 0;

        private bool _droppedDown = false;
        private Image _calendarIcon = Properties.Resources.calendarWhite;
        private RectangleF _iconButtonArea;

        /// <summary>
        /// creates a new instance of the <see cref="WFDateTimePicker"/>
        /// class
        /// </summary>
        public WFDateTimePicker()
        {
            SetStyle(ControlStyles.UserPaint, true);
            MinimumSize = new Size(0, 35);
            Font = new Font("Segoe UI", 12F);
        }

        /// <summary>
        /// gets or sets the skin color of the control
        /// </summary>
        [Category("Control appearance")]
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public Color SkinColor
        {
            get
            {
                return _skinColor;
            }
            set
            {
                if (value == SkinColor)
                {
                    return;
                }

                _skinColor = value;
                SetCalendarIcon();
                Invalidate();
            }
        }

        /// <summary>
        /// gets or sets the text color
        /// </summary>
        [Category("Control appearance")]
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public Color TextColor
        {
            get
            {
                return _textColor;
            }
            set
            {
                if (value == TextColor)
                {
                    return;
                }

                _textColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// gets or sets the border color
        /// </summary>
        [Category("Control appearance")]
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public Color BorderColor
        {
            get
            {
                return _borderColor;
            }
            set
            {
                if (value == BorderColor)
                {
                    return;
                }

                _borderColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// gets or sets the border size
        /// </summary>
        [Category("Control appearance")]
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public int BorderSize
        {
            get
            {
                return _borderSize;
            }
            set
            {
                if (value == BorderSize)
                {
                    return;
                }

                _borderSize = value;
                Invalidate();
            }
        }

        protected override void OnDropDown(EventArgs eventargs)
        {
            base.OnDropDown(eventargs);
            _droppedDown = true;
        }

        protected override void OnCloseUp(EventArgs eventargs)
        {
            base.OnCloseUp(eventargs);
            _droppedDown = false;
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            e.Handled = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            DrawControl();
        }

        /// <summary>
        /// draws the control
        /// </summary>
        private void DrawControl()
        {
            // note: the method CreateGraphics() returns the same
            // Graphics object of the PaintEventArgs class
            Graphics graphics = CreateGraphics();
            float width = Width - 0.5F;
            float height = Height - 0.5F;
            RectangleF clientArea = new(0, 0, width, height);

            DrawBorder(graphics, clientArea);
            DrawRectangle(graphics, clientArea);
            DrawImage(graphics);
            DrawText(graphics, clientArea);
        }

        /// <summary>
        /// draws the border of the control
        /// </summary>
        /// <param name="graphics">the graphics of the control</param>
        /// <param name="clientArea">the client area of the control</param>
        private void DrawBorder(Graphics graphics, RectangleF clientArea)
        {
            Pen penBorder = new(_borderColor, _borderSize);
            float x = clientArea.X;
            float y = clientArea.Y;
            float width = clientArea.Width;
            float height = clientArea.Height;

            if (_borderSize >= 1)
            {
                graphics.DrawRectangle(penBorder, x, y, width, height);
            }
        }

        /// <summary>
        /// draws and fills the rectangle of the control
        /// </summary>
        /// <param name="graphics">the graphics of the control</param>
        /// <param name="clientArea">the client area of the control</param>
        private void DrawRectangle(Graphics graphics, RectangleF clientArea)
        {
            RectangleF iconArea = new(clientArea.Width - CalendarIconWidth, 0, CalendarIconWidth, clientArea.Height);
            Color iconColor = Color.FromArgb(50, 64, 64, 64);
            SolidBrush openIconBrush = new(iconColor);
            SolidBrush skinBrush = new(_skinColor);
            graphics.FillRectangle(skinBrush, clientArea);

            if (_droppedDown)
            {
                graphics.FillRectangle(openIconBrush, iconArea);
            }
        }

        /// <summary>
        /// draws the calendar image
        /// </summary>
        /// <param name="graphics">the graphics of the control</param>
        private void DrawImage(Graphics graphics)
        {
            int x = Width - _calendarIcon.Width - 9;
            int y = (Height - _calendarIcon.Height) / 2;
            graphics.DrawImage(_calendarIcon, x, y);
        }

        /// <summary>
        /// draws the text of the control
        /// </summary>
        /// <param name="graphics">the graphics of the control</param>
        /// <param name="clientArea">the client area of the control</param>
        private void DrawText(Graphics graphics, RectangleF clientArea)
        {
            Font font = Font;
            string text = "   " + Text;
            SolidBrush textBrush = new(_textColor);
            StringFormat textFormat = new();
            textFormat.Alignment = StringAlignment.Center;
            graphics.DrawString(text, font, textBrush, clientArea, textFormat);
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            int iconWidth = GetIconButtonWidth();
            int width = Width - iconWidth;
            int height = Height;
            _iconButtonArea = new RectangleF(width, 0, iconWidth, height);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (_iconButtonArea.Contains(e.Location))
            {
                Cursor = Cursors.Hand;
            }
            else
            {
                Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// when the skin color of the control changes, this method is invoked
        /// and changes the calendar icon giving the brightness of the color
        /// </summary>
        private void SetCalendarIcon()
        {
            float brightness = _skinColor.GetBrightness();
            if (brightness > 0.8F)
            {
                _calendarIcon = Properties.Resources.calendarDark;
            }
            else
            {
                _calendarIcon = Properties.Resources.calendarWhite;
            }
        }

        /// <summary>
        /// gets the width of the icon button
        /// </summary>
        /// <returns>the width of the icon button</returns>
        private int GetIconButtonWidth()
        {
            string text = Text;
            Font font = Font;
            Size textSize = TextRenderer.MeasureText(text, font);
            int textWidth = textSize.Width;

            if (textWidth <= Width - (CalendarIconWidth + 20))
            {
                return CalendarIconWidth;
            }
            else
            {
                return ArrowIconWidth;
            }
        }
    }
}