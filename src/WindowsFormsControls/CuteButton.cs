using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WindowsFormsControls
{
    public partial class CuteButton : Button
    {
        private Color _firstColor = Color.LightGreen;
        private Color _secondColor = Color.DarkBlue;

        private int _firstColorTransparency = 80;
        private int _secondColorTransparency = 80;

        public CuteButton()
        {
            Size = new Size(120, 50);
            ForeColor = Color.Black;
            Font = new Font("Segoe UI", 12f);
            FlatAppearance.BorderColor = Color.White;
            FlatAppearance.BorderSize = 0;
            FlatStyle = FlatStyle.Flat;
        }

        /// <summary>
        /// gets or sets the first color of the button
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Category("Button appearance")]
        public Color FirstColor
        {
            get => _firstColor;
            set
            {
                _firstColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// gets or sets the second color of the button
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Category("Button appearance")]
        public Color SecondColor
        {
            get => _secondColor;
            set
            {
                _secondColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// gets or sets the color transparency of the first color
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Category("Button appearance")]
        public int FirstColorTransparency
        {
            get => _firstColorTransparency;
            set
            {
                _firstColorTransparency = value;
                Invalidate();
            }
        }

        /// <summary>
        /// gets or sets the color transparency of the second color
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Category("Button appearance")]
        public int SecondColorTransparency
        {
            get => _secondColorTransparency;
            set
            {
                _secondColorTransparency = value;
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
            Color c1 = Color.FromArgb(_firstColorTransparency, _firstColor);
            Color c2 = Color.FromArgb(_secondColorTransparency, _secondColor);
            Rectangle rectangle = ClientRectangle;
            LinearGradientBrush brush = new(rectangle, c1, c2, 10);

            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.FillRectangle(brush, rectangle);
            brush.Dispose();
        }
    }
}