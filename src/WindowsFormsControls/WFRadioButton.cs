using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsControls
{
    public partial class WFRadioButton : RadioButton
    {
        private Color _checkedColor = Color.MediumSlateBlue;
        private Color _unCheckedColor = Color.Gray;

        public WFRadioButton()
        {
            MinimumSize = new Size(0, 21);
            Font = new Font("Segoe UI", 12F);
        }

        /// <summary>
        /// gets or sets the color when the radio button is checked
        /// </summary>
        [Category("Control appearance")]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public Color CheckedColor
        {
            get => _checkedColor;
            set
            {
                _checkedColor = value;
                Invalidate();
            }
        }

        //gets or sets the color when the radio button is unchecked
        [Category("Control appearance")]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public Color UncheckedColor
        {
            get => _unCheckedColor;
            set
            {
                _unCheckedColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// redraws the control
        /// </summary>
        /// <param name="pe"></param>
        protected override void OnPaint(PaintEventArgs pe)
        {
            Graphics graphics = pe.Graphics;
            float borderSize = 18F;
            float checkSize = 12F;

            var rectBorder = new RectangleF
            {
                X = 0.5F,
                Y = (Height - borderSize) / 2,
                Width = borderSize,
                Height = borderSize
            };
            var rectCheck = new RectangleF
            {
                X = rectBorder.X + ((rectBorder.Width - checkSize) / 2),
                Y = (Height - checkSize) / 2,
                Width = checkSize,
                Height = checkSize
            };

            Color backColor = BackColor;
            Color foreColor = ForeColor;

            using var penBorder = new Pen(_checkedColor, 1.6F);
            using var brushRbCheck = new SolidBrush(_checkedColor);
            using var brushText = new SolidBrush(foreColor);

            graphics.Clear(backColor);

            if (Checked)
            {
                graphics.DrawEllipse(penBorder, rectBorder);
                graphics.FillEllipse(brushRbCheck, rectCheck);
            }
            else
            {
                penBorder.Color = _unCheckedColor;
                graphics.DrawEllipse(penBorder, rectBorder);
            }

            string text = Text;
            Font font = Font;
            Size textSize = TextRenderer.MeasureText(text, font);
            float width = borderSize + 8;
            float height = (Height - textSize.Height) / 2;

            graphics.DrawString(text, font, brushText, width, height);
        }

        /// <summary>
        /// called when the control is resized
        /// </summary>
        /// <param name="e"></param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            string text = Text;
            Font font = Font;
            Size textSize = TextRenderer.MeasureText(text, font);
            Width = textSize.Width + 30;
        }
    }
}