using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsControls
{
    public class CustomForm : Form
    {
        public CustomForm()
        {
            MaximizeBox = false;
            MinimizeBox = false;
            ControlBox = false;
            BackColor = Color.White;
            ForeColor = Color.Black;
        }

        protected DialogResult GenerateMessageBox(string text, string caption = null, MessageBoxButtons buttons = MessageBoxButtons.OK, MessageBoxIcon icon = MessageBoxIcon.None)
            => MessageBox.Show(text, caption ?? Text, buttons, icon);
    }
}