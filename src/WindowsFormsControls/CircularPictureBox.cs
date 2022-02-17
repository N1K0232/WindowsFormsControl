using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WindowsFormsControls
{
    /// <summary>
    /// represents a windows circular picture box 
    /// </summary>
    public partial class CircularPictureBox : PictureBox
    {
        private static readonly Color s_firstBorderColor = Color.RoyalBlue;
        private static readonly Color s_secondBorderColor = Color.HotPink;

        private int _borderSize = 2;
        private float _gradientAngle = 50F;
        private Color _firstBorderColor = Color.Empty;
        private Color _secondBorderColor = Color.Empty;
        private DashStyle _borderLineStyle = DashStyle.Solid;
        private DashCap _borderCapStyle = DashCap.Flat;

        /// <summary>
        /// creates a new instance of the <see cref="CircularPictureBox"/>
        /// class
        /// </summary>
        public CircularPictureBox()
        {
            Size = new Size(100, 100);
            SizeMode = PictureBoxSizeMode.StretchImage;
        }

        /// <summary>
        /// gets or sets the border size of the control
        /// </summary>
        [Category("Control appearance")]
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

        /// <summary>
        /// gets or sets the gradient angle of the control
        /// </summary>
        [Category("Control appearance")]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public float GradientAngle
        {
            get
            {
                return _gradientAngle;
            }
            set
            {
                if (value == GradientAngle)
                {
                    return;
                }

                _gradientAngle = value;
                Invalidate();
            }
        }

        /// <summary>
        /// gets or sets the first color of the border
        /// </summary>
        [Category("Control appearance")]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public Color FirstBorderColor
        {
            get
            {
                Color c = _firstBorderColor;

                if (c.IsEmpty)
                {
                    c = s_firstBorderColor;
                }

                return c;
            }
            set
            {
                Color c = value;

                if (c == FirstBorderColor)
                {
                    return;
                }

                if (c.IsEmpty)
                {
                    c = s_firstBorderColor;
                }

                _firstBorderColor = c;
                Invalidate();
            }
        }

        /// <summary>
        /// gets or sets the second color of the border
        /// </summary>
        [Category("Control appearance")]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public Color SecondBorderColor
        {
            get
            {
                Color c = _secondBorderColor;

                if (c.IsEmpty)
                {
                    c = s_secondBorderColor;
                }

                return c;
            }
            set
            {
                Color c = value;

                if (c == SecondBorderColor)
                {
                    return;
                }

                if (c.IsEmpty)
                {
                    c = s_secondBorderColor;
                }

                _secondBorderColor = c;
                Invalidate();
            }
        }

        /// <summary>
        /// gets or sets the Line Style of the border
        /// </summary>
        [Category("Control appearance")]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public DashStyle BorderLineStyle
        {
            get
            {
                return _borderLineStyle;
            }
            set
            {
                if (value == BorderLineStyle)
                {
                    return;
                }

                _borderLineStyle = value;
                Invalidate();
            }
        }

        /// <summary>
        /// gets or sets the style of the cap of the border
        /// </summary>
        [Category("Control appearance")]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public DashCap BorderCapStyle
        {
            get
            {
                return _borderCapStyle;
            }
            set
            {
                if (value == BorderCapStyle)
                {
                    return;
                }

                _borderCapStyle = value;
                Invalidate();
            }
        }

        /// <summary>
        /// called when the control is resized
        /// </summary>
        /// <param name="e">the event information</param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            int width = Width;
            Size = new Size(width, width);
        }

        /// <summary>
        /// redraws the control
        /// </summary>
        /// <param name="pe">the event information</param>
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            DrawControl(pe);
        }

        /// <summary>
        /// draws the control
        /// </summary>
        /// <param name="pe">the event information</param>
        private void DrawControl(PaintEventArgs pe)
        {
            Graphics graphics = pe.Graphics;
            Rectangle rectContourSmooth = GetSmoothRectangle();
            Rectangle rectBorder = GetBorderRectangle(rectContourSmooth);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;

            DrawSmooth(graphics, rectContourSmooth);
            DrawBorder(graphics, rectBorder);
        }

        /// <summary>
        /// draws the smooth of the control
        /// </summary>
        /// <param name="graphics">the graphics of the control</param>
        /// <param name="rectContourSmooth">the rectangle of the smooth</param>
        private void DrawSmooth(Graphics graphics, Rectangle rectContourSmooth)
        {
            Control parent = Parent;
            GraphicsPath pathRegion = new();
            int smoothSize = GetSmoothSize();
            Pen penSmooth = new(parent.BackColor, smoothSize);
            pathRegion.AddEllipse(rectContourSmooth);
            Region = new Region(pathRegion);
            graphics.DrawEllipse(penSmooth, rectContourSmooth);
            pathRegion.Dispose();
            penSmooth.Dispose();
        }

        /// <summary>
        /// draws the border of the picture box
        /// </summary>
        /// <param name="graphics">the graphics of the control</param>
        /// <param name="rectBorder">the rectangle of the border</param>
        private void DrawBorder(Graphics graphics, Rectangle rectBorder)
        {
            int borderSize = BorderSize;
            Color c1 = FirstBorderColor;
            Color c2 = SecondBorderColor;
            float angle = GradientAngle;
            LinearGradientBrush borderGColor = new(rectBorder, c1, c2, angle);
            Pen penBorder = new(borderGColor, borderSize);
            penBorder.DashStyle = BorderLineStyle;
            penBorder.DashCap = BorderCapStyle;
            if (borderSize > 0)
            {
                graphics.DrawEllipse(penBorder, rectBorder);
            }

            penBorder.Dispose();
            borderGColor.Dispose();
        }

        /// <summary>
        /// gets the smooth size of the control
        /// </summary>
        /// <returns>the smooth size of the control</returns>
        private int GetSmoothSize()
        {
            int borderSize = BorderSize;
            return borderSize > 0 ? borderSize * 3 : 1;
        }

        /// <summary>
        /// gets the rectangle of the smooth
        /// </summary>
        /// <returns>the rectangle of the smooth</returns>
        private Rectangle GetSmoothRectangle()
        {
            Rectangle rectangle = ClientRectangle;
            return Rectangle.Inflate(rectangle, -1, -1);
        }

        /// <summary>
        /// gets the rectangle of the border
        /// </summary>
        /// <param name="smoothRectangle"></param>
        /// <returns>the rectangle of the border</returns>
        private Rectangle GetBorderRectangle(Rectangle smoothRectangle)
        {
            int size = -BorderSize;
            return Rectangle.Inflate(smoothRectangle, size, size);
        }
    }
}