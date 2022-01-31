using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using WindowsFormsControls.Helpers;

namespace WindowsFormsControls
{
    public class DropDownMenu : ContextMenuStrip
    {
        private bool _isMainMenu;
        private int _menuItemHeight = 25;
        private Color _menuItemTextColor = Color.DimGray;
        private Color _primaryColor = Color.MediumSlateBlue;

        private Bitmap _menuItemHeaderSize;

        public DropDownMenu(IContainer container)
            : base(container)
        {
        }

        /// <summary>
        /// gets or sets the value to indicate if the drop down is MainMenu
        /// </summary>
        [Browsable(false)]
        public bool IsMainMenu
        {
            get
            {
                return _isMainMenu;
            }
            set
            {
                _isMainMenu = value;
            }
        }

        /// <summary>
        /// gets or sets the item height of the control
        /// </summary>
        [Browsable(false)]
        public int MenuItemHeight
        {
            get
            {
                return _menuItemHeight;
            }
            set
            {
                _menuItemHeight = value;
            }
        }

        /// <summary>
        /// gets or sets the color of the text item
        /// </summary>
        [Browsable(false)]
        public Color MenuItemTextColor
        {
            get
            {
                return _menuItemTextColor;
            }
            set
            {
                _menuItemTextColor = value;
            }
        }

        /// <summary>
        /// gets or sets the primary color of the control
        /// </summary>
        [Browsable(false)]
        public Color PrimaryColor
        {
            get
            {
                return _primaryColor;
            }
            set
            {
                _primaryColor = value;
            }
        }

        /// <summary>
        /// called when the Handle is created
        /// </summary>
        /// <param name="e"></param>
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            if (!DesignMode)
            {
                LoadMenuItemAppearance();
                Renderer = new MenuRenderer(_isMainMenu, _primaryColor, _menuItemTextColor);
            }
        }

        /// <summary>
        /// loads the menu item appearance
        /// </summary>
        private void LoadMenuItemAppearance()
        {
            if (_isMainMenu)
            {
                _menuItemHeaderSize = new Bitmap(25, 45);
                _menuItemTextColor = Color.Gainsboro;
            }
            else
            {
                _menuItemHeaderSize = new Bitmap(15, _menuItemHeight);
            }

            foreach (ToolStripMenuItem menuItemL1 in Items)
            {
                menuItemL1.ForeColor = _menuItemTextColor;
                menuItemL1.ImageScaling = ToolStripItemImageScaling.None;
                if (menuItemL1.Image is null)
                {
                    menuItemL1.Image = _menuItemHeaderSize;
                }

                foreach (ToolStripMenuItem menuItemL2 in menuItemL1.DropDownItems)
                {
                    menuItemL2.ForeColor = _menuItemTextColor;
                    menuItemL2.ImageScaling = ToolStripItemImageScaling.None;
                    if (menuItemL2.Image is null)
                    {
                        menuItemL2.Image = _menuItemHeaderSize;
                    }

                    foreach (ToolStripMenuItem menuItemL3 in menuItemL2.DropDownItems)
                    {
                        menuItemL3.ForeColor = _menuItemTextColor;
                        menuItemL3.ImageScaling = ToolStripItemImageScaling.None;
                        if (menuItemL3.Image is null)
                        {
                            menuItemL3.Image = _menuItemHeaderSize;
                        }

                        foreach (ToolStripMenuItem menuItemL4 in menuItemL3.DropDownItems)
                        {
                            menuItemL4.ForeColor = _menuItemTextColor;
                            menuItemL4.ImageScaling = ToolStripItemImageScaling.None;
                            if (menuItemL4.Image is null)
                            {
                                menuItemL4.Image = _menuItemHeaderSize;
                            }
                        }
                    }
                }
            }
        }
    }
}