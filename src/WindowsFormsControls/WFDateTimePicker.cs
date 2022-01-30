using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WindowsFormsControls
{
    public partial class WFDateTimePicker : DateTimePicker
    {
        private const int CalendarIconWidth = 34;
        private const int ArrowIconWidth = 17;

        private Color _skinColor = Color.MediumSlateBlue;
        private Color _textColor = Color.White;
        private Color _borderColor = Color.PaleVioletRed;
        private int _borderSize = 0;

        private bool _droppedDown = false;
        private Image _calendarIcon = Properties.Resources.calendarWhite;
        private RectangleF _iconButtonArea;

        public WFDateTimePicker()
        {
            SetStyle(ControlStyles.UserPaint, true);
            MinimumSize = new Size(0, 35);
            Font = new Font("Segoe UI", 12F);
        }

        [Category("Control appearance")]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public Color SkinColor
        {
            get => _skinColor;
            set
            {
                _skinColor = value;
                SetCalendarIcon();
                Invalidate();
            }
        }

        [Category("Control appearance")]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public Color TextColor
        {
            get => _textColor;
            set
            {
                _textColor = value;
                Invalidate();
            }
        }

        [Category("Control appearance")]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public Color BorderColor
        {
            get => _borderColor;
            set
            {
                _borderColor = value;
                Invalidate();
            }
        }

        [Category("Control appearance")]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public int BorderSize
        {
            get => _borderSize;
            set
            {
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
            Font font = Font;
            string text = "   " + Text;
            float width = Width - 0.5F;
            float height = Height - 0.5F;

            Graphics graphics = CreateGraphics();
            using var penBorder = new Pen(_borderColor, _borderSize);
            using var skinBrush = new SolidBrush(_skinColor);
            using var openIconBrush = new SolidBrush(Color.FromArgb(50, 64, 64, 64));
            using var textBrush = new SolidBrush(_textColor);
            using var textFormat = new StringFormat();

            RectangleF clientArea = new(0, 0, width, height);
            RectangleF iconArea = new(clientArea.Width - CalendarIconWidth, 0, CalendarIconWidth, clientArea.Height);
            penBorder.Alignment = PenAlignment.Inset;
            textFormat.LineAlignment = StringAlignment.Center;

            graphics.FillRectangle(skinBrush, clientArea);
            graphics.DrawString(text, font, textBrush, clientArea, textFormat);
            if (_droppedDown)
            {
                graphics.FillRectangle(openIconBrush, iconArea);
            }
            if (_borderSize >= 1)
            {
                graphics.DrawRectangle(penBorder, clientArea.X, clientArea.Y, clientArea.Width, clientArea.Height);
            }

            graphics.DrawImage(_calendarIcon, Width - _calendarIcon.Width - 9, (Height - _calendarIcon.Height) / 2);
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