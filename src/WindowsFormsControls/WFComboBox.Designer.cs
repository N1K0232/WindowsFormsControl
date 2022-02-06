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
            cmbList = new ComboBox();
            lblText = new Label();
            btnIcon = new Button();
            SuspendLayout();

            //combobox
            cmbList.BackColor = _listBackColor;
            cmbList.Font = new Font(this.Font.Name, 12F);
            cmbList.ForeColor = _listTextColor;
            cmbList.SelectedIndexChanged += new EventHandler(ComboBox_SelectedIndexChanged);
            cmbList.TextChanged += new EventHandler(Combobox_TextChanged);

            //btnIcon
            btnIcon.Dock = DockStyle.Right;
            btnIcon.FlatStyle = FlatStyle.Flat;
            btnIcon.FlatAppearance.BorderSize = 0;
            btnIcon.BackColor = _backColor;
            btnIcon.Size = new Size(30, 30);
            btnIcon.Cursor = Cursors.Hand;
            btnIcon.Click += new EventHandler(IconButton_Click);
            btnIcon.Paint += new PaintEventHandler(IconButton_Paint);

            //lblText
            lblText.Dock = DockStyle.Fill;
            lblText.AutoSize = false;
            lblText.BackColor = _backColor;
            lblText.TextAlign = ContentAlignment.MiddleLeft;
            lblText.Padding = new Padding(8, 0, 0, 0);
            lblText.Font = new Font(this.Font.Name, 12F);
            lblText.Click += new EventHandler(Surface_Click);

            //User Controls
            this.Controls.Add(lblText);
            this.Controls.Add(btnIcon);
            this.Controls.Add(cmbList);
            this.MinimumSize = new Size(200, 30);
            this.Size = new Size(200, 30);
            this.ForeColor = Color.DimGray;
            this.Padding = new Padding(_borderSize);
            base.BackColor = _borderColor;
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