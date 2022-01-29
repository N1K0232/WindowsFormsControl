using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WindowsFormsControls
{
    public partial class CircularPictureBox : PictureBox
    {
        private int _borderSize;
        private float _gradientAngle;
        private Color _firstBorderColor;
        private Color _secondBorderColor;
        private DashStyle _borderLineStyle;
        private DashCap _borderCapStyle;

        public CircularPictureBox()
        {
            _borderSize = 2;
            _firstBorderColor = Color.RoyalBlue;
            _secondBorderColor = Color.HotPink;
            _borderLineStyle = DashStyle.Solid;
            _borderCapStyle = DashCap.Flat;
            _gradientAngle = 50F;

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
            get => _borderSize;
            set
            {
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
            get => _gradientAngle;
            set
            {
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
            get => _firstBorderColor;
            set
            {
                _firstBorderColor = value;
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
            get => _secondBorderColor;
            set
            {
                _secondBorderColor = value;
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
            get => _borderLineStyle;
            set
            {
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
            get => _borderCapStyle;
            set
            {
                _borderCapStyle = value;
                Invalidate();
            }
        }

        /// <summary>
        /// called when the control is resized
        /// </summary>
        /// <param name="e"></param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            int width = Width;
            Size = new Size(width, width);
        }

        /// <summary>
        /// redraws the control
        /// </summary>
        /// <param name="pe"></param>
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            Graphics graphics = pe.Graphics;
            Control parent = Parent;
            Rectangle clientRectangle = ClientRectangle;
            Rectangle rectContourSmooth = Rectangle.Inflate(clientRectangle, -1, -1);
            Rectangle rectBorder = Rectangle.Inflate(rectContourSmooth, -_borderSize, -_borderSize);
            int smoothSize = _borderSize > 0 ? _borderSize * 3 : 1;

            using var borderGColor = new LinearGradientBrush(rectBorder, _firstBorderColor, _secondBorderColor, _gradientAngle);
            using var pathRegion = new GraphicsPath();
            using var penSmooth = new Pen(parent.BackColor, smoothSize);
            using var penBorder = new Pen(borderGColor, _borderSize);

            penBorder.DashStyle = _borderLineStyle;
            penBorder.DashCap = _borderCapStyle;
            pathRegion.AddEllipse(rectContourSmooth);
            Region = new Region(pathRegion);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;

            graphics.DrawEllipse(penSmooth, rectContourSmooth);
            if (_borderSize > 0)
            {
                graphics.DrawEllipse(penBorder, rectBorder);
            }
        }
    }
}