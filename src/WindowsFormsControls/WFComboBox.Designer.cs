using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WindowsFormsControls
{
    public partial class WFComboBox
    {
        private ComboBox cmbList;
        private Label lblText;
        private Button btnIcon;

        private void InitializeComponents()
        {
            Font font = Font;

            cmbList = new ComboBox();
            lblText = new Label();
            btnIcon = new Button();
            SuspendLayout();

            //cmbList
            cmbList.BackColor = ListBackColor;
            cmbList.Font = new Font(font.Name, 12F);
            cmbList.ForeColor = ListTextColor;
            cmbList.SelectedIndexChanged += new EventHandler(ComboBox_SelectedIndexChanged);
            cmbList.TextChanged += new EventHandler(Combobox_TextChanged);

            //btnIcon
            btnIcon.Dock = DockStyle.Right;
            btnIcon.FlatStyle = FlatStyle.Flat;
            btnIcon.FlatAppearance.BorderSize = 0;
            btnIcon.BackColor = BackColor;
            btnIcon.Size = new Size(30, 30);
            btnIcon.Cursor = Cursors.Hand;
            btnIcon.Click += new EventHandler(IconButton_Click);
            btnIcon.Paint += new PaintEventHandler(IconButton_Paint);

            //lblText
            lblText.Dock = DockStyle.Fill;
            lblText.AutoSize = false;
            lblText.BackColor = BackColor;
            lblText.TextAlign = ContentAlignment.MiddleLeft;
            lblText.Padding = new Padding(8, 0, 0, 0);
            lblText.Font = new Font(font.Name, 12F);
            lblText.Click += new EventHandler(Surface_Click);

            //User Controls
            Controls.Add(lblText);
            Controls.Add(btnIcon);
            Controls.Add(cmbList);
            MinimumSize = new Size(200, 30);
            Size = new Size(200, 30);
            ForeColor = Color.DimGray;
            Padding = new Padding(BorderSize);
            base.BackColor = BorderColor;
            ResumeLayout();
            AdjustComboBoxDimensions();
        }

        private void Surface_Click(object sender, EventArgs e)
        {
            cmbList.Select();
            if (cmbList.DropDownStyle == ComboBoxStyle.DropDownList)
            {
                cmbList.DroppedDown = true;
            }
        }
        private void IconButton_Paint(object sender, PaintEventArgs e)
        {
            int width = btnIcon.Width;
            int height = btnIcon.Height;
            int iconWidth = 14;
            int iconHeight = 6;
            Rectangle rectIcon = new Rectangle((width - iconWidth) / 2, (height - iconHeight) / 2,
                iconWidth, iconHeight);
            Graphics graphics = e.Graphics;

            using var path = new GraphicsPath();
            using var pen = new Pen(_iconColor, 2);

            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            path.AddLine(rectIcon.X, rectIcon.Y, rectIcon.X + (iconWidth / 2), rectIcon.Bottom);
            path.AddLine(rectIcon.X + (iconWidth / 2), rectIcon.Bottom, rectIcon.Right, rectIcon.Y);
            graphics.DrawPath(pen, path);
        }
        private void IconButton_Click(object sender, EventArgs e)
        {
            //Opens dropdown list
            cmbList.Select();
            cmbList.DroppedDown = true;
        }
        private void Combobox_TextChanged(object sender, EventArgs e)
        {
            //refresh text
            lblText.Text = cmbList.Text;
        }
        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectedIndexChanged != null)
            {
                SelectedIndexChanged.Invoke(sender, e);
            }

            lblText.Text = cmbList.Text;
        }
    }
}