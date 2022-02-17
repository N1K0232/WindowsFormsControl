using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsControls
{
    /// <summary>
    /// represents a windows progress bar
    /// </summary>
    public partial class WFProgressBar : ProgressBar
    {
        private Color _channelColor = Color.LightSteelBlue;
        private Color _sliderColor = Color.RoyalBlue;
        private Color _foreBackColor = Color.White;
        private int _channelHeight = 6;
        private int _sliderHeight = 6;
        private TextPosition _showValue = TextPosition.Right;

        private bool _paintedBack = false;
        private bool _stopPainting = false;

        /// <summary>
        /// creates a new instance of the <see cref="WFProgressBar"/>
        /// class
        /// </summary>
        public WFProgressBar()
        {
            SetStyle(ControlStyles.UserPaint, true);
            ForeColor = Color.White;
        }


        [Category("Control appearance")]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public Color ChannelColor
        {
            get
            {
                return _channelColor;
            }
            set
            {
                _channelColor = value;
                Invalidate();
            }
        }


        [Category("Control appearance")]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public Color SliderColor
        {
            get
            {
                return _sliderColor;
            }
            set
            {
                _sliderColor = value;
                Invalidate();
            }
        }


        [Category("Control appearance")]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public Color ForeBackColor
        {
            get
            {
                return _foreBackColor;
            }
            set
            {
                _foreBackColor = value;
                Invalidate();
            }
        }


        [Category("Control appearance")]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public int ChannelHeight
        {
            get
            {
                return _channelHeight;
            }
            set
            {
                _channelHeight = value;
                Invalidate();
            }
        }


        [Category("Control appearance")]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public int SliderHeight
        {
            get
            {
                return _sliderHeight;
            }
            set
            {
                _sliderHeight = value;
                Invalidate();
            }
        }


        [Category("Control appearance")]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public TextPosition ShowValue
        {
            get
            {
                return _showValue;
            }
            set
            {
                _showValue = value;
                Invalidate();
            }
        }


        [Category("Control appearance")]
        [Browsable(true)]
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
            }
        }

        [Category("Control appearance")]
        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                base.ForeColor = value;
            }
        }

        /// <summary>
        /// paints the background of the control
        /// </summary>
        /// <param name="pe">the event informations</param>
        protected override void OnPaintBackground(PaintEventArgs pe)
        {
            DrawBackground(pe);
        }

        /// <summary>
        /// draws the background of the control
        /// </summary>
        /// <param name="pe">the event informations</param>
        private void DrawBackground(PaintEventArgs pe)
        {
            Graphics graphics = pe.Graphics;
            Control parent = Parent;
            SolidBrush brushChannel = new(_channelColor);
            int value = Value;
            int minimum = Minimum;
            int maximum = Maximum;
            int width = Width;
            int height = Height;
            Rectangle rectChannel = new(0, 0, width, _channelHeight);

            if (!_stopPainting)
            {
                if (!_paintedBack)
                {
                    if (_channelHeight >= _sliderHeight)
                    {
                        rectChannel.Y = height - _channelHeight;
                    }
                    else
                    {
                        rectChannel.Y = height - ((_channelHeight + _sliderHeight) / 2);
                    }

                    graphics.Clear(parent.BackColor);
                    graphics.FillRectangle(brushChannel, rectChannel);

                    if (!DesignMode)
                    {
                        _paintedBack = true;
                    }
                }

                if (value == minimum || value == maximum)
                {
                    _paintedBack = false;
                }
            }

            brushChannel.Dispose();
        }

        /// <summary>
        /// raises the <see cref="Control.Paint"/>
        /// event
        /// </summary>
        /// <param name="pe">the event informations</param>
        protected override void OnPaint(PaintEventArgs pe)
        {
            DrawControl(pe);
        }

        /// <summary>
        /// draws the control
        /// </summary>
        /// <param name="pe">the event informations</param>
        private void DrawControl(PaintEventArgs pe)
        {
            double value = Convert.ToDouble(Value);
            double minimum = Convert.ToDouble(Minimum);
            double maximum = Convert.ToDouble(Maximum);
            int width = Width;
            int height = Height;
            Graphics graphics = pe.Graphics;
            double scaleFactor = ((value - minimum) / (maximum - minimum));
            int sliderWidth = Convert.ToInt32(width * scaleFactor);
            Rectangle rectSlider = new(0, 0, sliderWidth, _sliderHeight);
            SolidBrush brushSlider = new(_sliderColor);

            if (!_stopPainting)
            {
                if (_sliderHeight >= _channelHeight)
                {
                    rectSlider.Y = height - _sliderHeight;
                }
                else
                {
                    rectSlider.Y = height - (_sliderHeight + _channelHeight) / 2;
                }

                if (sliderWidth > 1)
                {
                    graphics.FillRectangle(brushSlider, rectSlider);
                }

                if (_showValue != TextPosition.None)
                {
                    DrawValueText(graphics, sliderWidth, width, rectSlider);
                }
            }

            brushSlider.Dispose();
        }

        /// <summary>
        /// draws the Text of the control
        /// </summary>
        /// <param name="graphics">the graphics of the control</param>
        /// <param name="sliderWidth">the width of the slider</param>
        /// <param name="width">the width of the control</param>
        /// <param name="rectSlider">the rectangle of the slider</param>
        private void DrawValueText(Graphics graphics, int sliderWidth, int width, Rectangle rectSlider)
        {
            Control parent = Parent;
            string text = Value.ToString() + "%";
            Font font = Font;
            Size textSize = TextRenderer.MeasureText(text, font);
            Rectangle rectText = new(0, 0, textSize.Width, textSize.Height + 2);
            Color textColor = ForeColor;
            Color backColor = _foreBackColor;
            SolidBrush brushText = new(textColor);
            SolidBrush brushTextBack = new(backColor);
            StringFormat textFormat = new();

            switch (_showValue)
            {
                case TextPosition.Left:
                    rectText.X = 0;
                    textFormat.Alignment = StringAlignment.Near;
                    break;
                case TextPosition.Right:
                    rectText.X = width - textSize.Width;
                    textFormat.Alignment = StringAlignment.Far;
                    break;
                case TextPosition.Center:
                    rectText.X = (width - textSize.Width) / 2;
                    textFormat.Alignment = StringAlignment.Center;
                    break;
                case TextPosition.Sliding:
                    rectText.X = sliderWidth - textSize.Width;
                    textFormat.Alignment = StringAlignment.Center;

                    SolidBrush brushClear = new(parent.BackColor);
                    Rectangle rect = rectSlider;
                    rect.Y = rectText.Y;
                    rect.Height = rectText.Height;
                    graphics.FillRectangle(brushClear, rect);
                    brushClear.Dispose();
                    break;
            }

            graphics.FillRectangle(brushTextBack, rectText);
            graphics.DrawString(text, font, brushText, rectText, textFormat);

            textFormat.Dispose();
            brushTextBack.Dispose();
            brushText.Dispose();
        }
    }
}