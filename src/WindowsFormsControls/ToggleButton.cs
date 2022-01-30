using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WindowsFormsControls
{
    public partial class ToggleButton : CheckBox
    {
        private Color _onBackColor;
        private Color _offBackColor;
        private Color _onToggleColor;
        private Color _offToggleColor;

        private bool _solidStyle = true;

        public ToggleButton()
        {
            _onBackColor = Color.MediumSlateBlue;
            _onToggleColor = Color.WhiteSmoke;
            _offBackColor = Color.Gray;
            _offToggleColor = Color.Gainsboro;

            MinimumSize = new Size(45, 22);
        }

        /// <summary>
        /// gets or sets the background color when the button is on
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Category("Control appearance")]
        public Color OnBackColor
        {
            get => _onBackColor;
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
            get => _offBackColor;
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
            get => _onToggleColor;
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
            get => _offToggleColor;
            set
            {
                _offToggleColor = value;
                Invalidate();
            }
        }

        public override string Text
        {
            get => base.Text;
            set
            {
            }
        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        [Category("Control appearance")]
        [DefaultValue(true)]
        public bool SolidStyle
        {
            get => _solidStyle;
            set
            {
                _solidStyle = value;
                Invalidate();
            }
        }

        /// <summary>
        /// redraws the control
        /// </summary>
        /// <param name="pe"></param>
        protected override void OnPaint(PaintEventArgs pe)
        {
            int width = Width;
            int height = Height;
            int toggleSize = height - 5;
            Control parent = Parent;
            Graphics graphics = pe.Graphics;
            SolidBrush backColor;
            SolidBrush toggleColor;
            GraphicsPath path = GetFigurePath();
            Rectangle rectangle;

            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.Clear(parent.BackColor);

            if (Checked)
            {
                backColor = new SolidBrush(_onBackColor);
                toggleColor = new SolidBrush(_onToggleColor);
                rectangle = new Rectangle(width - height + 1, 2, toggleSize, toggleSize);
                if (_solidStyle)
                {
                    graphics.FillPath(backColor, path);
                }
                else
                {
                    graphics.DrawPath(new Pen(_onBackColor), path);
                }

                graphics.FillEllipse(toggleColor, rectangle);
            }
            else
            {
                backColor = new SolidBrush(_offBackColor);
                toggleColor = new SolidBrush(_offToggleColor);
                rectangle = new Rectangle(2, 2, toggleSize, toggleSize);

                if (_solidStyle)
                {
                    graphics.FillPath(backColor, path);
                }
                else
                {
                    graphics.DrawPath(new Pen(_offBackColor), path);
                }

                graphics.FillEllipse(toggleColor, rectangle);
            }
        }

        /// <summary>
        /// gets the path of the control
        /// </summary>
        /// <returns></returns>
        private GraphicsPath GetFigurePath()
        {
            int arcSize = Height - 1;
            Rectangle leftArc = new(0, 0, arcSize, arcSize);
            Rectangle rightArc = new(Width - arcSize - 2, 0, arcSize, arcSize);

            GraphicsPath path = new();
            path.StartFigure();
            path.AddArc(leftArc, 90, 180);
            path.AddArc(rightArc, 270, 180);
            path.CloseFigure();

            return path;
        }
    }
}