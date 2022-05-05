using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsControls.Common
{
    public interface ICuteButtonControl : ICustomButtonControl, IButtonControl
    {
        Color FirstColor { get; set; }
        Color SecondColor { get; set; }
        int FirstColorTransparency { get; set; }
        int SecondColorTransparency { get; set; }
    }
}