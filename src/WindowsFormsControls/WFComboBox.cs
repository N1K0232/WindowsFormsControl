using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;

namespace WindowsFormsControls
{
    [DefaultEvent(nameof(SelectedIndexChanged))]
    public partial class WFComboBox : UserControl
    {
        private Color _backColor = Color.WhiteSmoke;
        private Color _iconColor = Color.MediumSlateBlue;
        private Color _listBackColor = Color.FromArgb(230, 228, 245);
        private Color _listTextColor = Color.DimGray;
        private Color _borderColor = Color.MediumSlateBlue;
        private int _borderSize = 1;

        public WFComboBox()
        {
            InitializeComponents();
        }

        /// <summary>
        /// gets or sets the back color of the control
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
        /// gets or sets the color of the icon
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
        /// gets ors sets the color of the list
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
        /// gets or sets the color of the text of the list
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
        /// gets or sets the color of the border
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
        /// gets or sets the size of the border
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

        /// <summary>
        /// gets the collection of the items of the combobox
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
        /// gets or sets the data source of the combo box
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
        /// gets or sets the AutoCompleteMode of the combobox
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
        /// gets or sets the AutoCompleteSource of the combobox
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
        /// gets or sets the AutoCompleteStringCollection of the combobox
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
        /// gets or sets the index of the selected item of the combobox
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
        /// gets or sets the selected item of the combobox
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
            Padding padding = Padding;
            cmbList.Width = lblText.Width;
            int cmbWidth = cmbList.Width;
            int cmbHeight = cmbList.Height;
            Point cmbLocation = new()
            {
                X = Width - padding.Right - cmbWidth,
                Y = lblText.Bottom - cmbHeight
            };

            cmbList.Location = cmbLocation;
        }
    }
}