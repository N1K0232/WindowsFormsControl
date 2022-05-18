namespace TestControls
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            ConfigureClickMethod();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            DialogResult result = GenerateMessageBox(button.Text);
        }
        private DialogResult GenerateMessageBox(string buttonText)
        {
            string message = "You clicked the " + buttonText;
            string caption = Text;
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            MessageBoxIcon icon = MessageBoxIcon.Information;
            return MessageBox.Show(message, caption, buttons, icon);
        }
    }
}