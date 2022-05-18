using System.Windows.Forms;

namespace WindowsFormsControls.Common
{
    public interface ICustomButtonControl : IButtonControl
    {
        Button ActiveButton { get; }
    }
}