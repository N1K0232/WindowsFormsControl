using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WindowsFormsControls
{
    public partial class RoundButton : Button
    {
        private int _borderSize = 0;
        private int _borderRadius = 40;
        private Color _borderColor = Color.PaleVioletRed;

        public RoundButton()
        {
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            Size = new Size(150, 40);
            BackColor = Color.MediumSlateBlue;
            ForeColor = Color.White;
        }

        /// <summary>
        /// gets or sets the size of the border
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Category("Button appearance")]
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
        /// gets or sets the radius of the border
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Category("Button appearance")]
        public int BorderRadius
        {
            get => _borderRadius;
            set
            {
                _borderRadius = value;
                Invalidate();
            }
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
        /// redraws the control
        /// </summary>
        /// <param name="pe"></param>
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            int width = Width;
            int height = Height;
            Graphics graphics = pe.Graphics;
            Control parent = Parent;
            RectangleF rectSurface = new(0, 0, width, height);
            RectangleF rectBorder = new(1, 1, width - 0.8F, height - 1);

            graphics.SmoothingMode = SmoothingMode.AntiAlias;

            if (_borderRadius > 2)
            {
                using var pathSurface = GetFigurePath(rectSurface, _borderRadius);
                using var pathBorder = GetFigurePath(rectBorder, _borderRadius - 1F);
                using var penSurface = new Pen(parent.BackColor, 2);
                using var penBorder = new Pen(_borderColor, 2);

                penBorder.Alignment = PenAlignment.Inset;
                Region = new Region(pathSurface);
                graphics.DrawPath(penSurface, pathSurface);

                if (_borderSize >= 1)
                {
                    graphics.DrawPath(penBorder, pathBorder);
                }
            }
            else
            {
                Region = new Region(rectSurface);
                if (_borderSize >= 1)
                {
                    using var penBorder = new Pen(_borderColor, _borderSize);
                    penBorder.Alignment = PenAlignment.Inset;
                    graphics.DrawRectangle(penBorder, 0, 0, width - 1, height - 1);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            Parent.BackColorChanged += new EventHandler(Container_BackColorChanged);
        }

        /// <summary>
        /// if the control is in design mode, this method redraws it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Container_BackColorChanged(object sender, EventArgs e)
        {
            if (DesignMode)
            {
                Invalidate();
            }
        }

        /// <summary>
        /// gets the path of the control
        /// </summary>
        /// <param name="rect">the rectangle of the control</param>
        /// <param name="radius">the radius of the control</param>
        /// <returns></returns>
        private static GraphicsPath GetFigurePath(RectangleF rect, float radius)
        {
            GraphicsPath path = new();
            path.StartFigure();
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.Width - radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.Width - radius, rect.Height - radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}