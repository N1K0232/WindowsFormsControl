using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WindowsFormsControls
{
    /// <summary>
    ///  
    /// </summary>
    [DefaultEvent(nameof(TextChange))]
    public partial class WFTextBox : UserControl
    {
        private Color _borderColor = Color.RoyalBlue;
        private Color _borderFocusColor = Color.HotPink;
        private int _borderSize = 2;
        private bool _underlinedStyle = false;
        private bool _isFocused = false;

        /// <summary>
        /// 
        /// </summary>
        public WFTextBox()
        {
            InitializeComponent();
        }


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
                if (value == BorderColor)
                {
                    return;
                }

                _borderColor = value;
                Invalidate();
            }
        }


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
                if (value == UnderlinedStyle)
                {
                    return;
                }

                _underlinedStyle = value;
                Invalidate();
            }
        }


        [Category("Control appearance")]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public bool PasswordChar
        {
            get
            {
                return textBox.UseSystemPasswordChar;
            }
            set
            {
                textBox.UseSystemPasswordChar = value;
            }
        }


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
            }
        }


        [Category("Control appearance")]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public string TextString
        {
            get
            {
                return textBox.Text;
            }
            set
            {
                textBox.Text = value;
            }
        }

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
                if (value == BorderFocusColor)
                {
                    return;
                }

                _borderFocusColor = value;
                Invalidate();
            }
        }

        public event EventHandler TextChange;

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            DrawControl(pe);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (DesignMode)
            {
                UpdateControlHeight();
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            UpdateControlHeight();
        }

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

                Padding padding = Padding;
                Height = textBox.Height + padding.Top + padding.Bottom;
            }
        }

        private void DrawControl(PaintEventArgs pe)
        {
            Graphics graphics = pe.Graphics;
            DrawBorder(graphics);
        }

        private void DrawBorder(Graphics graphics)
        {
            Pen penBorder;
            int width = Width;
            int height = Height;

            if (!_isFocused)
            {
                penBorder = new Pen(_borderColor, _borderSize);
                penBorder.Alignment = PenAlignment.Inset;
                if (_underlinedStyle)
                {
                    graphics.DrawLine(penBorder, 0, height - 1, width, height - 1);
                }
                else
                {
                    graphics.DrawRectangle(penBorder, 0, 0, width - 0.5F, height - 0.5F);
                }
            }
            else
            {
                penBorder = new Pen(_borderFocusColor, _borderSize);
                penBorder.Alignment = PenAlignment.Inset;
                if (_underlinedStyle)
                {
                    graphics.DrawLine(penBorder, 0, height - 1, width, height - 1);
                }
                else
                {
                    graphics.DrawRectangle(penBorder, 0, 0, width - 0.5F, height - 0.5F);
                }
            }

            penBorder.Dispose();
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            if (TextChange != null)
            {
                TextChange.Invoke(sender, e);
            }
        }

        private void TextBox_Click(object sender, EventArgs e)
        {
            OnClick(e);
        }

        private void TextBox_MouseEnter(object sender, EventArgs e)
        {
            OnMouseEnter(e);
        }

        private void TextBox_MouseLeave(object sender, EventArgs e)
        {
            OnMouseLeave(e);
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnKeyPress(e);
        }

        private void TextBox_Enter(object sender, EventArgs e)
        {
            _isFocused = true;
            Invalidate();
        }

        private void TextBox_Leave(object sender, EventArgs e)
        {
            _isFocused = false;
            Invalidate();
        }
    }
}