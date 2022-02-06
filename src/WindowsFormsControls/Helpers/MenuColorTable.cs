using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsControls.Helpers
{
    public partial class MenuColorTable : ProfessionalColorTable
    {
        private readonly Color _backColor;
        private readonly Color _leftColumnColor;
        private readonly Color _borderColor;
        private readonly Color _menuItemBorderColor;
        private readonly Color _menuItemSelectedColor;

        public MenuColorTable(bool isMainMenu, Color primaryColor)
        {
            if (isMainMenu)
            {
                _backColor = Color.FromArgb(37, 39, 60);
                _leftColumnColor = Color.FromArgb(32, 33, 51);
                _borderColor = Color.FromArgb(32, 33, 51);
            }
            else
            {
                _backColor = Color.White;
                _leftColumnColor = Color.LightGray;
                _borderColor = Color.LightGray;
            }

            _menuItemBorderColor = primaryColor;
            _menuItemSelectedColor = primaryColor;
        }

        public override Color ToolStripDropDownBackground
        {
            get
            {
                return _backColor;
            }
        }
        public override Color MenuBorder
        {
            get
            {
                return _borderColor;
            }
        }
        public override Color MenuItemBorder
        {
            get
            {
                return _menuItemBorderColor;
            }
        }
        public override Color MenuItemSelected
        {
            get
            {
                return _menuItemSelectedColor;
            }
        }
        public override Color ImageMarginGradientBegin
        {
            get
            {
                return _leftColumnColor;
            }
        }
        public override Color ImageMarginGradientMiddle
        {
            get
            {
                return _leftColumnColor;
            }
        }
        public override Color ImageMarginGradientEnd
        {
            get
            {
                return _leftColumnColor;
            }
        }
    }
}