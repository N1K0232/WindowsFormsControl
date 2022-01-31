using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WindowsFormsControls
{
    public partial class ToggleButton : CheckBox
    {
        private Color _onBackColor = Color.RoyalBlue;
        private Color _offBackColor = Color.Gray;
        private Color _onToggleColor = Color.WhiteSmoke;
        private Color _offToggleColor = Color.Gainsboro;

        private bool _solidStyle = true;

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
                return _onBackColor;
            }
            set
            {
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
                return _offBackColor;
            }
            set
            {
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
                return _onToggleColor;
            }
            set
            {
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
                return _offToggleColor;
            }
            set
            {
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
                _solidStyle = value;
                Invalidate();
            }
        }

        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
            }
        }

        /// <summary>
        /// redraws the control
        /// </summary>
        /// <param name="pe">the informations of the event</param>
        protected override void OnPaint(PaintEventArgs pe)
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
            Color backColor = isChecked ? _onBackColor : _offBackColor;
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
            Color toggleColor = isChecked ? _onToggleColor : _offToggleColor;
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
        /// gets the path of the control
        /// </summary>
        /// <returns></returns>
        private GraphicsPath GetFigurePath()
        {
            int width = Width;
            int height = Height;
            int arcSize = height - 1;
            Rectangle leftArc = new(0, 0, arcSize, arcSize);
            Rectangle rightArc = new(width - arcSize - 2, 0, arcSize, arcSize);

            GraphicsPath path = new();
            path.StartFigure();
            path.AddArc(leftArc, 90, 180);
            path.AddArc(rightArc, 270, 180);
            path.CloseFigure();

            return path;
        }
    }
}