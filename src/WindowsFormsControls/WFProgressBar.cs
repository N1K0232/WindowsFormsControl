using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsControls
{
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

        public WFProgressBar()
        {
            SetStyle(ControlStyles.UserPaint, true);
            ForeColor = Color.White;
        }

        [Category("Control appearance")]
        public Color ChannelColor
        {
            get => _channelColor;
            set
            {
                _channelColor = value;
                Invalidate();
            }
        }

        [Category("Control appearance")]
        public Color SliderColor
        {
            get => _sliderColor;
            set
            {
                _sliderColor = value;
                Invalidate();
            }
        }

        [Category("Control appearance")]
        public Color ForeBackColor
        {
            get => _foreBackColor;
            set
            {
                _foreBackColor = value;
                Invalidate();
            }
        }

        [Category("Control appearance")]
        public int ChannelHeight
        {
            get => _channelHeight;
            set
            {
                _channelHeight = value;
                Invalidate();
            }
        }

        [Category("Control appearance")]
        public int SliderHeight
        {
            get => _sliderHeight;
            set
            {
                _sliderHeight = value;
                Invalidate();
            }
        }

        [Category("Control appearance")]
        public TextPosition ShowValue
        {
            get => _showValue;
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

        protected override void OnPaintBackground(PaintEventArgs pe)
        {
            int value = Value;
            int minimum = Minimum;
            int maximum = Maximum;
            int width = Width;
            int height = Height;
            Control parent = Parent;

            if (!_stopPainting)
            {
                if (!_paintedBack)
                {
                    Graphics graphics = pe.Graphics;
                    Rectangle rectChannel = new(0, 0, width, _channelHeight);
                    using var brushChannel = new SolidBrush(_channelColor);
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
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            double value = Convert.ToDouble(Value);
            double minimum = Convert.ToDouble(Minimum);
            double maximum = Convert.ToDouble(Maximum);
            int width = Width;
            int height = Height;

            if (!_stopPainting)
            {
                Graphics graphics = pe.Graphics;
                double scaleFactor = ((value - minimum) / (maximum - minimum));
                int sliderWidth = Convert.ToInt32(width * scaleFactor);
                Rectangle rectSlider = new(0, 0, sliderWidth, _sliderHeight);
                using var brushSlider = new SolidBrush(_sliderColor);

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
                    DrawValueText(graphics, sliderWidth, rectSlider);
                }
            }
        }

        private void DrawValueText(Graphics graphics, int sliderWidth, Rectangle rectSlider)
        {
            Control parent = Parent;
            int width = Width;
            int height = Height;
            string text = Value.ToString() + "%";
            Font font = Font;
            Size textSize = TextRenderer.MeasureText(text, font);
            Rectangle rectText = new(0, 0, textSize.Width, textSize.Height + 2);
            Color textColor = ForeColor;
            Color backColor = _foreBackColor;
            using var brushText = new SolidBrush(textColor);
            using var brushTextBack = new SolidBrush(backColor);
            using var textFormat = new StringFormat();

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

                    using (var brushClear = new SolidBrush(parent.BackColor))
                    {
                        Rectangle rect = rectSlider;
                        rect.Y = rectText.Y;
                        rect.Height = rectText.Height;
                        graphics.FillRectangle(brushClear, rect);
                    }
                    break;
            }

            graphics.FillRectangle(brushTextBack, rectText);
            graphics.DrawString(text, font, brushText, rectText, textFormat);
        }
    }
}