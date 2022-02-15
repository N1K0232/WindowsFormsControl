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

        private static readonly Color s_skinColor = Color.RoyalBlue;
        private static readonly Color s_textColor = Color.White;
        private static readonly Color s_borderColor = Color.PaleVioletRed;

        private Color _skinColor = Color.Empty;
        private Color _textColor = Color.Empty;
        private Color _borderColor = Color.Empty;
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
                return GetSkinColor();
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
                return GetTextColor();
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
                return GetBorderColor();
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
            Color color = GetBorderColor();
            Pen penBorder = new(color, _borderSize);
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
            float width = clientArea.Width;
            float height = clientArea.Height;
            float iconWidth = CalendarIconWidth;
            RectangleF iconArea = new(width - iconWidth, 0, iconWidth, height);
            Color skinColor = GetSkinColor();
            Color iconColor = Color.FromArgb(50, 64, 64, 64);
            SolidBrush openIconBrush = new(iconColor);
            SolidBrush skinBrush = new(skinColor);
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
            int width = Width;
            int height = Height;
            int iconWidth = _calendarIcon.Width - 9;
            int iconHeight = _calendarIcon.Height;
            int x = width - iconWidth - 9;
            int y = (height - iconHeight) / 2;
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
            Color textColor = GetTextColor();
            SolidBrush textBrush = new(textColor);
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
            ChangeCursor(e.Location);
        }

        /// <summary>
        /// changes the cursor giving the location of the mouse
        /// </summary>
        /// <param name="location">the location of the mouse</param>
        private void ChangeCursor(Point location)
        {
            if (_iconButtonArea.Contains(location))
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

        /// <summary>
        /// gets the value of the _skinColor field
        /// or the value of the s_skinColor field
        /// </summary>
        /// <returns>the skin color of the control</returns>
        private Color GetSkinColor()
        {
            Color c = _skinColor;
            if (c.IsEmpty)
            {
                c = s_skinColor;
            }

            return c;
        }

        /// <summary>
        /// gets the value of the _borderColor field
        /// or the value of the s_borderColor field
        /// </summary>
        /// <returns>the border color of the control</returns>
        private Color GetBorderColor()
        {
            Color c = _borderColor;
            if (c.IsEmpty)
            {
                c = s_borderColor;
            }

            return c;
        }

        /// <summary>
        /// gets the value of the _textColor field
        /// or the value of the s_textColor field
        /// </summary>
        /// <returns>the text color of the control</returns>
        private Color GetTextColor()
        {
            Color c = _textColor;
            if (c.IsEmpty)
            {
                c = s_textColor;
            }

            return c;
        }
    }
}