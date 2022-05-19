using System.Windows.Forms;

namespace WindowsFormsControls;

public partial class CustomForm : Form
{
    public CustomForm()
    {
        InitializeComponent();
    }

    protected DialogResult GenerateMessageBox(string text, string caption = null, MessageBoxButtons buttons = MessageBoxButtons.OK, MessageBoxIcon icon = MessageBoxIcon.None)
        => MessageBox.Show(text, caption ?? Text, buttons, icon);
}