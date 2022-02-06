using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsControls
{
    /// <summary>
    /// represents a windows radiobutton
    /// </summary>
    public partial class WFRadioButton : RadioButton
    {
        private Color _checkedColor = Color.MediumSlateBlue;
        private Color _unCheckedColor = Color.Gray;

        /// <summary>
        /// creates a new instance of the <see cref="WFRadioButton"/>
        /// class
        /// </summary>
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

        /// <summary>
        /// redraws the control
        /// </summary>
        /// <param name="pe">the event informations</param>
        protected override void OnPaint(PaintEventArgs pe)
        {
            DrawControl(pe);
        }

        /// <summary>
        /// draws the control. this method is called by the <see cref="OnPaint(PaintEventArgs)"/>
        /// method
        /// </summary>
        /// <param name="pe">the event informations</param>
        private void DrawControl(PaintEventArgs pe)
        {
            Graphics graphics = pe.Graphics;
            float borderSize = 18F;
            int height = Height;
            float x = 0.5F;
            float y = (height - borderSize) / 2;
            RectangleF rectBorder = new(x, y, borderSize, borderSize);
            Color backColor = BackColor;
            bool isChecked = Checked;

            graphics.Clear(backColor);

            DrawBorder(graphics, rectBorder, isChecked);
            DrawCheck(graphics, rectBorder, isChecked);
            DrawText(graphics, borderSize);
        }

        /// <summary>
        /// draws the border of the control
        /// </summary>
        /// <param name="graphics">the graphics of the control</param>
        /// <param name="rectBorder">the rectangle that represents the border</param>
        private void DrawBorder(Graphics graphics, RectangleF rectBorder, bool isChecked)
        {
            Color color = isChecked ? _checkedColor : _unCheckedColor;
            Pen penBorder;

            if (isChecked)
            {
                penBorder = new Pen(color);
                graphics.DrawEllipse(penBorder, rectBorder);
            }
            else
            {
                penBorder = new Pen(color);
                graphics.DrawEllipse(penBorder, rectBorder);
            }
        }

        /// <summary>
        /// draws the area of the check
        /// </summary>
        /// <param name="graphics">the graphics of the control</param>
        /// <param name="rectBorder">the rectangle of the border</param>
        private void DrawCheck(Graphics graphics, RectangleF rectBorder, bool isChecked)
        {
            int height = Height;
            float checkSize = 12F;
            SolidBrush brushRbCheck = new(_checkedColor);
            float x = rectBorder.X + ((rectBorder.Width - checkSize) / 2);
            float y = (height - checkSize) / 2;
            RectangleF rectCheck = new(x, y, checkSize, checkSize);

            if (isChecked)
            {
                graphics.FillEllipse(brushRbCheck, rectCheck);
            }

            brushRbCheck.Dispose();
        }

        /// <summary>
        /// draws the text of the control
        /// </summary>
        /// <param name="graphics">the graphics of the control</param>
        /// <param name="borderSize">the size of the border</param>
        private void DrawText(Graphics graphics, float borderSize)
        {
            string text = Text;
            Font font = Font;
            Size textSize = TextRenderer.MeasureText(text, font);
            float width = borderSize + 8;
            float height = (Height - textSize.Height) / 2;
            Color foreColor = ForeColor;
            SolidBrush brushText = new(foreColor);
            graphics.DrawString(text, font, brushText, width, height);
            brushText.Dispose();
        }
    }
}