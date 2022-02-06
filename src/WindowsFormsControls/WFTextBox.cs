using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WindowsFormsControls
{
    [DefaultEvent(nameof(TextChanged))]
    public partial class WFTextBox : UserControl
    {
        private Color _borderColor = Color.MediumSlateBlue;
        private Color _borderFocusColor = Color.HotPink;

        private int _borderSize = 2;
        private int _borderRadius = 0;

        private bool _underlinedStyle = false;
        private bool _isFocused = false;

        private Color _placeHolderColor = Color.Gray;
        private string _placeHolderText = string.Empty;

        private bool _isPlaceHolder = false;
        private bool _isPasswordChar = false;

        public WFTextBox()
        {
            InitializeComponent();
        }

        /// <summary>
        /// gets or sets the border color of the textbox
        /// </summary>
        [Category("Control appearance")]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public Color BorderColor
        {
            get
            {
                return _borderColor;
            }
            set
            {
                _borderColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// gets or sets the color of the border when the textbox is focused
        /// </summary>
        [Category("Control appearance")]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public Color BorderFocusColor
        {
            get
            {
                return _borderFocusColor;
            }
            set
            {
                _borderFocusColor = value;
            }
        }

        /// <summary>
        /// gets or sets the size of the border
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
                _borderSize = value;
                Invalidate();
            }
        }

        /// <summary>
        /// gets or sets the style of the textbox
        /// true if the control is underlined otherwise false
        /// </summary>
        [Category("Control appearance")]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public bool UnderlinedStyle
        {
            get
            {
                return _underlinedStyle;
            }
            set
            {
                _underlinedStyle = value;
                Invalidate();
            }
        }

        /// <summary>
        /// gets or sets the radius of the border
        /// </summary>
        [Category("Control appearance")]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public int BorderRadius
        {
            get
            {
                return _borderRadius;
            }
            set
            {
                if (value >= 0)
                {
                    _borderRadius = value;
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// gets or sets the state of the textbox
        /// true if the control uses the System Password char otherwise false
        /// </summary>
        [Category("Control appearance")]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public bool UseSystemPasswordChar
        {
            get
            {
                return _isPasswordChar;
            }
            set
            {
                _isPasswordChar = value;
                textBox.UseSystemPasswordChar = value;
            }
        }

        /// <summary>
        /// gets or sets the password char of the textbox
        /// </summary>
        [Category("Control appearance")]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public char PasswordChar
        {
            get
            {
                return textBox.PasswordChar;
            }
            set
            {
                textBox.PasswordChar = value;
            }
        }

        /// <summary>
        /// gets or sets the status of the textbox
        /// true if the textbox is multiline otherwise false
        /// </summary>
        [Category("Control appearance")]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public bool Multiline
        {
            get
            {
                return textBox.Multiline;
            }
            set
            {
                textBox.Multiline = value;
            }
        }

        [Category("Control appearance")]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                base.BackColor = value;
                textBox.BackColor = value;
            }
        }

        [Category("Control appearance")]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                base.ForeColor = value;
                textBox.ForeColor = value;
            }
        }

        [Category("Control appearance")]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public override Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;
                textBox.Font = value;
                if (DesignMode)
                {
                    UpdateControlHeight();
                }
            }
        }

        [Category("Control appearance")]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public override string Text
        {
            get
            {
                return _isPlaceHolder ? string.Empty : textBox.Text;
            }
            set
            {
                textBox.Text = value;
                SetPlaceHolder();
            }
        }

        /// <summary>
        /// gets or sets the color of the text of the placeholder
        /// </summary>
        [Category("Place holder")]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public Color PlaceHolderColor
        {
            get
            {
                return _placeHolderColor;
            }
            set
            {
                _placeHolderColor = value;
                if (_isPlaceHolder)
                {
                    textBox.ForeColor = value;
                }
            }
        }

        /// <summary>
        /// gets or sets the text of the placeholder
        /// </summary>
        [Category("Place holder")]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public string PlaceHolderText
        {
            get
            {
                return _placeHolderText;
            }
            set
            {
                _placeHolderText = value;
                textBox.Text = "";
                SetPlaceHolder();
            }
        }

        public new event EventHandler TextChanged;

        /// <summary>
        /// loads the control
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            UpdateControlHeight();
        }

        /// <summary>
        /// called when the control is resized
        /// </summary>
        /// <param name="e"></param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (DesignMode)
            {
                UpdateControlHeight();
            }
        }

        /// <summary>
        /// redraws the control
        /// </summary>
        /// <param name="e"></param>
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
            Graphics g = pe.Graphics;
            Control parent = Parent;
            Rectangle clientRectangle = ClientRectangle;
            int width = Width;
            int height = Height;

            if (_borderRadius > 1)
            {
                Rectangle rectBorderSmooth = clientRectangle;
                Rectangle rectBorder = GetBorderRectangle(rectBorderSmooth);
                int smoothSize = GetSmoothSize();

                GraphicsPath pathBorderSmooth = GetFigurePath(rectBorderSmooth, _borderRadius);
                GraphicsPath pathBorder = GetFigurePath(rectBorder, _borderRadius - _borderSize);
                Pen penBorderSmooth = new(parent.BackColor, smoothSize);
                Pen penBorder = new(_borderColor, _borderSize);

                Region = new Region(pathBorderSmooth);
                if (_borderRadius > 15)
                {
                    SetTextBoxRoundedRegion();
                }
                g.SmoothingMode = SmoothingMode.AntiAlias;
                penBorder.Alignment = PenAlignment.Inset;

                if (_isFocused)
                {
                    penBorder.Color = _borderFocusColor;
                }

                if (_underlinedStyle)
                {
                    g.DrawPath(penBorderSmooth, pathBorderSmooth);
                    g.SmoothingMode = SmoothingMode.None;
                    g.DrawLine(penBorder, 0, height - 1, width, height - 1);
                }
                else
                {
                    g.DrawPath(penBorderSmooth, pathBorderSmooth);
                    g.DrawPath(penBorder, pathBorder);
                }
            }
            else
            {
                Pen penBorder = new(_borderColor, _borderSize);
                Region = new Region(clientRectangle);
                penBorder.Alignment = PenAlignment.Inset;

                if (_isFocused)
                {
                    penBorder.Color = _borderFocusColor;
                }

                if (_underlinedStyle)
                {
                    g.DrawLine(penBorder, 0, height - 1, width, height - 1);
                }
                else
                {
                    g.DrawLine(penBorder, 0, 0, width - 0.5F, height - 0.5F);
                }
            }
        }

        /// <summary>
        /// gets the border of rectangle from the smooth rectangle
        /// </summary>
        /// <param name="smoothRectangle">the smooth rectangle</param>
        /// <returns>the border of the rectangle</returns>
        private Rectangle GetBorderRectangle(Rectangle smoothRectangle)
        {
            int size = -_borderSize;
            return Rectangle.Inflate(smoothRectangle, size, size);
        }

        /// <summary>
        /// gets the size of the smooth
        /// </summary>
        /// <returns>the size of the smooth</returns>
        private int GetSmoothSize()
        {
            return _borderSize > 0 ? _borderSize : 1;
        }

        /// <summary>
        /// updates the height of the control 
        /// when the text box is not in Multiline
        /// </summary>
        private void UpdateControlHeight()
        {
            if (!textBox.Multiline)
            {
                Font font = Font;
                Size textSize = TextRenderer.MeasureText("Text", font);
                int textHeight = textSize.Height + 1;
                textBox.Multiline = true;
                textBox.MinimumSize = new Size(0, textHeight);
                textBox.Multiline = false;

                Height = textBox.Height + Padding.Top + Padding.Bottom;
            }
        }

        /// <summary>
        /// sets the rounded region of the control
        /// </summary>
        private void SetTextBoxRoundedRegion()
        {
            GraphicsPath pathText;
            Rectangle clientRectangle = textBox.ClientRectangle;

            if (Multiline)
            {
                pathText = GetFigurePath(clientRectangle, _borderRadius - _borderSize);
                textBox.Region = new Region(pathText);
            }
            else
            {
                pathText = GetFigurePath(clientRectangle, _borderSize * 2);
                textBox.Region = new Region(pathText);
            }
        }

        /// <summary>
        /// sets the place holder
        /// </summary>
        private void SetPlaceHolder()
        {
            if (string.IsNullOrWhiteSpace(textBox.Text) && _placeHolderText != "")
            {
                _isPlaceHolder = true;
                textBox.Text = _placeHolderText;
                textBox.ForeColor = _placeHolderColor;

                if (_isPasswordChar)
                {
                    textBox.UseSystemPasswordChar = false;
                }
            }
        }

        /// <summary>
        /// removes the place holder
        /// </summary>
        private void RemovePlaceHolder()
        {
            if (_isPlaceHolder && _placeHolderText != "")
            {
                _isPlaceHolder = false;
                textBox.Text = string.Empty;
                textBox.ForeColor = ForeColor;
                if (_isPasswordChar)
                {
                    textBox.UseSystemPasswordChar = true;
                }
            }
        }

        /// <summary>
        /// called when the text of the textbox changes
        /// </summary>
        /// <param name="sender">the object that called the event</param>
        /// <param name="e">the informations of the event</param>
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            if (TextChanged != null)
            {
                TextChanged.Invoke(sender, e);
            }
        }

        /// <summary>
        /// called when the textbox is clicked
        /// </summary>
        /// <param name="sender">the object that called the event</param>
        /// <param name="e">the informations of the event</param>
        private void TextBox_Click(object sender, EventArgs e)
        {
            OnClick(e);
        }

        /// <summary>
        /// called when the mouse enters the textbox area
        /// </summary>
        /// <param name="sender">the object that called the event</param>
        /// <param name="e">the informations of the event</param>
        private void TextBox_MouseEnter(object sender, EventArgs e)
        {
            OnMouseEnter(e);
        }

        /// <summary>
        /// called when the mouse leaves the textbox area
        /// </summary>
        /// <param name="sender">the object that called the event</param>
        /// <param name="e">the informations of the event</param>
        private void TextBox_MouseLeave(object sender, EventArgs e)
        {
            OnMouseLeave(e);
        }

        /// <summary>
        /// called when a key is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnKeyPress(e);
        }

        /// <summary>
        /// called when the mouse enters the textbox area
        /// </summary>
        /// <param name="sender">the object that called the event</param>
        /// <param name="e">the informations of the event</param>
        private void TextBox_Enter(object sender, EventArgs e)
        {
            _isFocused = true;
            Invalidate();
            RemovePlaceHolder();
        }

        /// <summary>
        /// called when the mouse leaves the textbox area
        /// </summary>
        /// <param name="sender">the object that called the event</param>
        /// <param name="e">the informations of the event</param>
        private void TextBox_Leave(object sender, EventArgs e)
        {
            _isFocused = false;
            Invalidate();
            SetPlaceHolder();
        }

        /// <summary>
        /// gets the path of the control
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="radius"></param>
        /// <returns></returns>
        private GraphicsPath GetFigurePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new();
            float curveSize = radius * 2F;

            path.StartFigure();
            path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
            path.AddArc(rect.Width - curveSize, rect.Y, curveSize, curveSize, 270, 90);
            path.AddArc(rect.Width - curveSize, rect.Height - curveSize, curveSize, curveSize, 0, 90);
            path.AddArc(rect.X, rect.Height - curveSize, curveSize, curveSize, 90, 90);
            path.CloseFigure();

            return path;
        }
    }
}