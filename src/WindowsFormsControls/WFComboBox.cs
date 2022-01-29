using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;

namespace WindowsFormsControls
{
    public partial class WFComboBox : UserControl
    {
        private Color _backColor;
        private Color _iconColor;
        private Color _listBackColor;
        private Color _listTextColor;
        private Color _borderColor;
        private int _borderSize;

        public WFComboBox()
        {
            _backColor = Color.WhiteSmoke;
            _iconColor = Color.MediumSlateBlue;
            _listBackColor = Color.FromArgb(230, 228, 245);
            _listTextColor = Color.DimGray;
            _borderColor = Color.MediumSlateBlue;
            _borderSize = 1;

            InitializeComponents();
        }

        //appearance properties
        /// <summary>
        /// 
        /// </summary>
        public new Color BackColor
        {
            get
            {
                return _backColor;
            }
            set
            {
                _backColor = value;
                lblText.BackColor = value;
                btnIcon.BackColor = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Color IconColor
        {
            get
            {
                return _iconColor;
            }
            set
            {
                _iconColor = value;
                btnIcon.Invalidate();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Color ListBackColor
        {
            get
            {
                return _listBackColor;
            }
            set
            {
                _listBackColor = value;
                cmbList.BackColor = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Color ListTextColor
        {
            get
            {
                return _listTextColor;
            }
            set
            {
                _listTextColor = value;
                cmbList.ForeColor = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Color BorderColor
        {
            get
            {
                return _borderColor;
            }
            set
            {
                _borderColor = value;
                base.BackColor = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int BorderSize
        {
            get
            {
                return _borderSize;
            }
            set
            {
                _borderSize = value;
                Padding = new Padding(value);
                AdjustComboBoxDimensions();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                base.ForeColor = value;
                lblText.ForeColor = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;
                lblText.Font = value;
                cmbList.Font = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public new string Text
        {
            get
            {
                return lblText.Text;
            }
            set
            {
                lblText.Text = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public ComboBoxStyle DropDownStyle
        {
            get
            {
                return cmbList.DropDownStyle;
            }
            set
            {
                if (value != ComboBoxStyle.Simple)
                {
                    cmbList.DropDownStyle = value;
                }
            }
        }

        //data properties
        /// <summary>
        /// 
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Localizable(true)]
        [Editor("System.Windows.Forms.Design.ListControlStringCollectionEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [MergableProperty(false)]
        public ComboBox.ObjectCollection Items
        {
            get
            {
                return cmbList.Items;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue(null)]
        [RefreshProperties(RefreshProperties.Repaint)]
        [AttributeProvider(typeof(IListSource))]
        public object DataSource
        {
            get
            {
                return cmbList.DataSource;
            }
            set
            {
                cmbList.DataSource = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue(AutoCompleteMode.None)]
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public AutoCompleteMode AutoCompleteMode
        {
            get
            {
                return cmbList.AutoCompleteMode;
            }
            set
            {
                cmbList.AutoCompleteMode = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue(AutoCompleteSource.None)]
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public AutoCompleteSource AutoCompleteSource
        {
            get
            {
                return cmbList.AutoCompleteSource;
            }
            set
            {
                cmbList.AutoCompleteSource = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Localizable(true)]
        [Editor("System.Windows.Forms.Design.ListControlStringCollectionEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public AutoCompleteStringCollection AutoCompleteCustomSource
        {
            get
            {
                return cmbList.AutoCompleteCustomSource;
            }
            set
            {
                cmbList.AutoCompleteCustomSource = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int SelectedIndex
        {
            get
            {
                return cmbList.SelectedIndex;
            }
            set
            {
                cmbList.SelectedIndex = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        [Bindable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object SelectedItem
        {
            get
            {
                return cmbList.SelectedItem;
            }
            set
            {
                cmbList.SelectedItem = value;
            }
        }

        public event EventHandler SelectedIndexChanged;

        private void AdjustComboBoxDimensions()
        {
            cmbList.Width = lblText.Width;
            cmbList.Location = new Point
            {
                X = Width - this.Padding.Right - cmbList.Width,
                Y = lblText.Bottom - cmbList.Height
            };
        }
    }
}