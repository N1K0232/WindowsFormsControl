using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using WindowsFormsControls.Common;

namespace WindowsFormsControls
{
    /// <summary>
    /// represents a windows button
    /// </summary>
    public partial class CuteButton : Button, ICuteButtonControl, ICustomButtonControl, IButtonControl
    {
        private static readonly Color s_firstColor = Color.LightGreen;
        private static readonly Color s_secondColor = Color.DarkBlue;

        private Color _firstColor = Color.Empty;
        private Color _secondColor = Color.Empty;
        private int _firstColorTransparency = 80;
        private int _secondColorTransparency = 80;

        /// <summary>
        /// creates a new instance of the <see cref="CuteButton"/>
        /// class
        /// </summary>
        public CuteButton()
        {
            Size = new Size(120, 50);
            ForeColor = Color.Black;
            Font = new Font("Segoe UI", 12F);
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
            get
            {
                return GetFirstColor();
            }
            set
            {
                if (value == FirstColor)
                {
                    return;
                }

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
            get
            {
                return GetSecondColor();
            }
            set
            {
                if (value == SecondColor)
                {
                    return;
                }

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
            get
            {
                return _firstColorTransparency;
            }
            set
            {
                if (value == FirstColorTransparency)
                {
                    return;
                }

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
            get
            {
                return _secondColorTransparency;
            }
            set
            {
                if (value == SecondColorTransparency)
                {
                    return;
                }

                _secondColorTransparency = value;
                Invalidate();
            }
        }

        public Button ActiveButton => this;

        /// <summary>
        /// redraws the control
        /// </summary>
        /// <param name="pe"></param>
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            DrawControl(pe);
        }

        /// <summary>
        /// draws the control 
        /// </summary>
        /// <param name="pe">the event informations</param>
        private void DrawControl(PaintEventArgs pe)
        {
            Color firstColor = Color.FromArgb(FirstColorTransparency, GetFirstColor());
            Color secondColor = Color.FromArgb(SecondColorTransparency, GetSecondColor());
            Rectangle rectangle = ClientRectangle;
            LinearGradientBrush brush = new(rectangle, firstColor, secondColor, 10);
            Graphics graphics = pe.Graphics;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.FillRectangle(brush, rectangle);
            brush.Dispose();
        }

        /// <summary>
        /// gets the value of the _firstColor field
        /// or the value of the s_firstColor field
        /// </summary>
        /// <returns>the firstColor of the control</returns>
        private Color GetFirstColor()
        {
            Color c = _firstColor;

            if (c.IsEmpty)
            {
                c = s_firstColor;
            }

            return c;
        }

        /// <summary>
        /// gets the value of the _secondColor field
        /// or the value of the s_secondColor field
        /// </summary>
        /// <returns>the second color of the control</returns>
        private Color GetSecondColor()
        {
            Color c = _secondColor;

            if (c.IsEmpty)
            {
                c = s_secondColor;
            }

            return c;
        }
    }
}