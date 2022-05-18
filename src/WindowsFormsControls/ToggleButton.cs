using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WindowsFormsControls
{
    /// <summary>
    /// represents a windows toggle
    /// </summary>
    public partial class ToggleButton : CheckBox
    {
        private static readonly Color s_onBackColor = Color.RoyalBlue;
        private static readonly Color s_offBackColor = Color.Gray;
        private static readonly Color s_onToggleColor = Color.WhiteSmoke;
        private static readonly Color s_offToggleColor = Color.Gainsboro;

        private Color _onBackColor = Color.Empty;
        private Color _offBackColor = Color.Empty;
        private Color _onToggleColor = Color.Empty;
        private Color _offToggleColor = Color.Empty;

        private bool _solidStyle = true;

        /// <summary>
        /// creates a new instance of the <see cref="ToggleButton"/>
        /// class
        /// </summary>
        public ToggleButton()
        {
            MinimumSize = new Size(90, 44);
        }

        /// <summary>
        /// gets or sets the background color when the button is on
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Category("Control appearance")]
        public Color OnBackColor
        {
            get
            {
                return GetBackColor(true);
            }
            set
            {
                if (value == OnBackColor)
                {
                    return;
                }

                _onBackColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// gets or sets the background color when the button is off
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Category("Control appearance")]
        public Color OffBackColor
        {
            get
            {
                return GetBackColor(false);
            }
            set
            {
                if (value == OffBackColor)
                {
                    return;
                }

                _offBackColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// gets or sets the toggle color when the button is on
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Category("Control appearance")]
        public Color OnToggleColor
        {
            get
            {
                return GetToggleColor(true);
            }
            set
            {
                if (value == OnToggleColor)
                {
                    return;
                }

                _onToggleColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// gets or sets the toggle color when the button is off
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Category("Control appearance")]
        public Color OffToggleColor
        {
            get
            {
                return GetToggleColor(false);
            }
            set
            {
                if (value == OffToggleColor)
                {
                    return;
                }

                _offToggleColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// gets or sets the solid style of the control
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Category("Control appearance")]
        [DefaultValue(true)]
        public bool SolidStyle
        {
            get
            {
                return _solidStyle;
            }
            set
            {
                if (value == SolidStyle)
                {
                    return;
                }

                _solidStyle = value;
                Invalidate();
            }
        }

        /// <summary>
        /// redraws the control
        /// </summary>
        /// <param name="pe">the informations of the event</param>
        protected override void OnPaint(PaintEventArgs pe)
        {
            DrawControl(pe);
        }

        /// <summary>
        /// draws the control
        /// </summary>
        /// <param name="pe">the informations of the event</param>
        private void DrawControl(PaintEventArgs pe)
        {
            int width = Width;
            int height = Height;
            Control parent = Parent;
            Graphics graphics = pe.Graphics;
            bool isChecked = Checked;

            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.Clear(parent.BackColor);

            DrawBackGround(graphics, isChecked);
            DrawToggle(graphics, width, height, isChecked);
        }

        /// <summary>
        /// draws the background of the control
        /// </summary>
        /// <param name="graphics">the graphics of the control</param>
        /// <param name="isChecked">true if it's checked otherwise false</param>
        private void DrawBackGround(Graphics graphics, bool isChecked)
        {
            GraphicsPath path = GetFigurePath();
            Color backColor = GetBackColor(isChecked);
            SolidBrush brush = new(backColor);
            if (isChecked)
            {
                if (_solidStyle)
                {
                    graphics.FillPath(brush, path);
                }
                else
                {
                    graphics.DrawPath(new Pen(_onBackColor), path);
                }
            }
            else
            {
                if (_solidStyle)
                {
                    graphics.FillPath(brush, path);
                }
                else
                {
                    graphics.DrawPath(new Pen(_offBackColor), path);
                }
            }

            path.Dispose();
        }

        /// <summary>
        /// gets the color of the background giving the status of the checkbox
        /// </summary>
        /// <param name="isChecked">the status of the checkbox
        /// true if the control is checked otherwise false</param>
        /// <returns>the color of the background</returns>
        private Color GetBackColor(bool isChecked)
        {
            Color c;

            if (isChecked)
            {
                c = _onBackColor;
                if (c.IsEmpty)
                {
                    c = s_onBackColor;
                }
            }
            else
            {
                c = _offBackColor;
                if (c.IsEmpty)
                {
                    c = s_offBackColor;
                }
            }

            return c;
        }

        /// <summary>
        /// draws the toggle of the control
        /// </summary>
        /// <param name="graphics">the graphics of the control</param>
        /// <param name="width">the width of the control</param>
        /// <param name="height">the height of the control</param>
        /// <param name="isChecked">true if it's checked otherwise false</param>
        private void DrawToggle(Graphics graphics, int width, int height, bool isChecked)
        {
            Color toggleColor = GetToggleColor(isChecked);
            SolidBrush brush = new(toggleColor);
            int toggleSize = height - 5;
            Rectangle rectangle;

            if (isChecked)
            {
                rectangle = new Rectangle(width - height + 1, 2, toggleSize, toggleSize);
            }
            else
            {
                rectangle = new Rectangle(2, 2, toggleSize, toggleSize);
            }

            graphics.FillEllipse(brush, rectangle);
        }

        /// <summary>
        /// gets the color of the toggle giving the status of the checkbox
        /// </summary>
        /// <param name="isChecked">the status of the checkbox
        /// true if the control is checked otherwise false</param>
        /// <returns>the color of the toggle</returns>
        private Color GetToggleColor(bool isChecked)
        {
            Color c;

            if (isChecked)
            {
                c = _onToggleColor;
                if (c.IsEmpty)
                {
                    c = s_onToggleColor;
                }
            }
            else
            {
                c = _offToggleColor;
                if (c.IsEmpty)
                {
                    c = s_offToggleColor;
                }
            }

            return c;
        }

        /// <summary>
        /// gets the path of the control
        /// </summary>
        /// <returns>the path of the control</returns>
        private GraphicsPath GetFigurePath()
        {
            GraphicsPath path = new();
            path.StartFigure();
            path.AddArc(GetLeftArc(), 90, 180);
            path.AddArc(GetRightArc(), 270, 180);
            path.CloseFigure();

            return path;
        }

        /// <summary>
        /// gets the left arc rectangle of the toggle button
        /// </summary>
        /// <returns>the left arc rectangle of the toggle button</returns>
        private Rectangle GetLeftArc()
        {
            int height = Height;
            int arcSize = height - 1;
            Rectangle leftArc = new(0, 0, arcSize, arcSize);
            return leftArc;
        }

        /// <summary>
        /// gets the right arc rectangle of the toggle button
        /// </summary>
        /// <returns>the right arc rectangle of the toggle button</returns>
        private Rectangle GetRightArc()
        {
            int width = Width;
            int height = Height;
            int arcSize = height - 1;
            Rectangle rightArc = new(width - arcSize - 2, 0, arcSize, arcSize);
            return rightArc;
        }
    }
}