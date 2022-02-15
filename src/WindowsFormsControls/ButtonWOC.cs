using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WindowsFormsControls
{
    /// <summary>
    /// represents a rounded windows button
    /// </summary>
    public partial class ButtonWOC : Button, IButtonControl
    {
        //constants
        private const int DefaultBorderThickness = 6;
        private const int DefaultBorderThicknessByTwo = 3;

        //static color fields
        private static readonly Color s_borderColor = Color.Black;
        private static readonly Color s_buttonColor = Color.RoyalBlue;
        private static readonly Color s_textColor = Color.White;
        private static readonly Color s_onHoverBorderColor = Color.Red;
        private static readonly Color s_onHoverButtonColor = Color.Yellow;
        private static readonly Color s_onHoverTextColor = Color.Black;

        //colors
        private Color _borderColor = Color.Empty;
        private Color _buttonColor = Color.Empty;
        private Color _textColor = Color.Empty;
        private Color _onHoverBorderColor = Color.Empty;
        private Color _onHoverButtonColor = Color.Empty;
        private Color _onHoverTextColor = Color.Empty;

        //these fields are used to draw the border
        private int _borderThickness = 0;
        private int _borderThicknessByTwo = 0;

        //this field is used to redraw the control when the mouse enters
        //or leaves the button area
        private bool _isHovering = false;

        /// <summary>
        /// creates a new instance of the <see cref="ButtonWOC"/>
        /// class
        /// </summary>
        public ButtonWOC()
        {
            FlatAppearance.BorderColor = Color.White;
            FlatAppearance.BorderSize = 0;
            FlatAppearance.MouseOverBackColor = Color.White;
            FlatAppearance.MouseDownBackColor = Color.White;
            FlatStyle = FlatStyle.Flat;

            MinimumSize = new Size(150, 50);
            BackColor = Color.Transparent;
            ForeColor = Color.Transparent;
            Font = new Font("Segoe UI", 12F);

            MouseEnter += new EventHandler(Mouse_Enter);
            MouseLeave += new EventHandler(Mouse_Leave);
        }

        /// <summary>
        /// gets or sets the color of the border
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Category("Button appearance")]
        public Color BorderColor
        {
            get
            {
                //gets the _borderColor field value because the
                //mouse doesn't hover the control
                return GetBorderColor(false);
            }
            set
            {
                if (value == BorderColor)
                {
                    return;
                }

                _borderColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// gets or sets the color of the button
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Category("Button appearance")]
        public Color ButtonColor
        {
            get
            {
                //gets the _buttonColor value 
                //because the mouse doesn't hover the control
                return GetButtonColor(false);
            }
            set
            {
                if (value == ButtonColor)
                {
                    return;
                }

                _buttonColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// gets or sets the color of the text
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Category("Button appearance")]
        public Color TextColor
        {
            get
            {
                //gets the _textColor value 
                //because the mouse doesn't hover the control
                return GetTextColor(false);
            }
            set
            {
                if (value == TextColor)
                {
                    return;
                }

                _textColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// gets or sets the color of the border when the mouse hovers the button
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Category("Button appearance")]
        public Color OnHoverBorderColor
        {
            get
            {
                //gets the _onHoverButtonColor value 
                //because the mouse hovers the control
                return GetBorderColor(true);
            }
            set
            {
                if (value == OnHoverBorderColor)
                {
                    return;
                }

                _onHoverBorderColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// gets or sets the color of the button when the mouse hovers it
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Category("Button appearance")]
        public Color OnHoverButtonColor
        {
            get
            {
                //gets the _onHoverButtonColor value 
                //because the mouse hovers the control
                return GetButtonColor(true);
            }
            set
            {
                if (value == OnHoverButtonColor)
                {
                    return;
                }

                _onHoverButtonColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// gets or sets the color of the text when the mouse hovers the button
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Category("Button appearance")]
        public Color OnHoverTextColor
        {
            get
            {
                //gets the _onHoverTuttonColor value 
                //because the mouse hovers the control
                return GetTextColor(true);
            }
            set
            {
                if (value == OnHoverTextColor)
                {
                    return;
                }

                _onHoverTextColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// gets or sets the thickness of the border of the button
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Category("Button appearance")]
        public int BorderThickness
        {
            get
            {
                int thickness = _borderThickness;
                return thickness == 0 ?
                    DefaultBorderThickness :
                    _borderThickness;
            }
            set
            {
                if (value == BorderThickness)
                {
                    return;
                }

                _borderThickness = value;
                Invalidate();
            }
        }

        /// <summary>
        /// gets or sets the border thickness divided by two
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Category("Button appearance")]
        public int BorderThicknessByTwo
        {
            get
            {
                int thickness = _borderThicknessByTwo;
                return thickness == 0 ?
                    DefaultBorderThicknessByTwo :
                    _borderThicknessByTwo;
            }
            set
            {
                if (value == BorderThicknessByTwo || value != BorderThickness / 2)
                {
                    return;
                }

                _borderThicknessByTwo = value;
                Invalidate();
            }
        }

        /// <summary>
        /// redraws the control
        /// </summary>
        /// <param name="pe">the event informations</param>
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            DrawControl(pe);
        }

        /// <summary>
        /// this methos is called by the <see cref="OnPaint(PaintEventArgs)"/>
        /// method and draws the control
        /// </summary>
        /// <param name="pe">the event informations</param>
        private void DrawControl(PaintEventArgs pe)
        {
            int width = Width;
            int height = Height;
            Graphics graphics = pe.Graphics;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            DrawBorder(graphics, width, height);
            FillButton(graphics, width, height);
            DrawText(graphics, width, height);
        }

        /// <summary>
        /// draws the border of the control
        /// </summary>
        /// <param name="graphics">the graphics of the control</param>
        private void DrawBorder(Graphics graphics, int width, int height)
        {
            Color borderColor = GetBorderColor(_isHovering);
            SolidBrush brush = new(borderColor);
            graphics.FillEllipse(brush, 0, 0, height, height);
            graphics.FillEllipse(brush, width - height, 0, height, height);
            graphics.FillRectangle(brush, height / 2, 0, width - height, height);
            brush.Dispose();
        }

        /// <summary>
        /// gets the border color of the button when the mouse hovers the button
        /// </summary>
        /// <returns></returns>
        private Color GetBorderColor(bool isHovering)
        {
            Color c;

            if (isHovering)
            {
                c = _onHoverBorderColor;
                if (c.IsEmpty)
                {
                    c = s_onHoverBorderColor;
                }
            }
            else
            {
                c = _borderColor;
                if (c.IsEmpty)
                {
                    c = s_borderColor;
                }
            }

            return c;
        }

        /// <summary>
        /// fills the control
        /// </summary>
        /// <param name="graphics">the graphics of the control</param>
        private void FillButton(Graphics graphics, int width, int height)
        {
            int borderThickness = BorderThickness;
            int borderThicknessByTwo = BorderThicknessByTwo;
            Color buttonColor = GetButtonColor(_isHovering);
            SolidBrush brush = new(buttonColor);

            graphics.FillEllipse(brush, borderThicknessByTwo, borderThicknessByTwo, height - borderThickness,
                height - borderThickness);
            graphics.FillEllipse(brush, (width - height) + borderThicknessByTwo, borderThicknessByTwo,
                height - borderThickness, height - borderThickness);
            graphics.FillRectangle(brush, height / 2 + borderThicknessByTwo, borderThicknessByTwo,
                width - height - borderThickness, height - borderThickness);

            brush.Dispose();
        }

        /// <summary>
        /// gets the button color when the mouse hovers the button
        /// </summary>
        /// <returns></returns>
        private Color GetButtonColor(bool isHovering)
        {
            Color c;

            if (isHovering)
            {
                c = _onHoverButtonColor;
                if (c.IsEmpty)
                {
                    c = s_onHoverButtonColor;
                }
            }
            else
            {
                c = _buttonColor;
                if (c.IsEmpty)
                {
                    c = s_buttonColor;
                }
            }

            return c;
        }

        /// <summary>
        /// draws the text
        /// </summary>
        /// <param name="graphics">the graphics of the control</param>
        private void DrawText(Graphics graphics, int width, int height)
        {
            string text = Text;
            Font font = Font;
            SizeF stringSize = graphics.MeasureString(text, font);
            float textWidth = (width - stringSize.Width) / 2;
            float textHeight = (height - stringSize.Height) / 2;
            Color textColor = GetTextColor(_isHovering);
            SolidBrush brush = new(textColor);
            graphics.DrawString(text, font, brush, textWidth, textHeight);
            brush.Dispose();
        }

        /// <summary>
        /// gets the text color of the button when the mouse hovers the button
        /// </summary>
        /// <returns></returns>
        private Color GetTextColor(bool isHovering)
        {
            Color c;

            if (isHovering)
            {
                c = _onHoverTextColor;
                if (c.IsEmpty)
                {
                    c = s_onHoverTextColor;
                }
            }
            else
            {
                c = _textColor;
                if (c.IsEmpty)
                {
                    c = s_textColor;
                }
            }

            return c;
        }

        /// <summary>
        /// called when the mouse enters the control
        /// </summary>
        /// <param name="sender">the object that invoked the method</param>
        /// <param name="e">the event informations</param>
        private void Mouse_Enter(object sender, EventArgs e)
        {
            _isHovering = true;
            Invalidate();
        }

        /// <summary>
        /// called when the mouse leaves the control
        /// </summary>
        /// <param name="sender">the object that invoked the method</param>
        /// <param name="e">the event informations</param>
        private void Mouse_Leave(object sender, EventArgs e)
        {
            _isHovering = false;
            Invalidate();
        }
    }
}