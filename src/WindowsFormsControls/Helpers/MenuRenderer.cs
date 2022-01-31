using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WindowsFormsControls.Helpers
{
    public class MenuRenderer : ToolStripProfessionalRenderer
    {
        private readonly Color primaryColor;
        private readonly Color textColor;
        private readonly int arrowThickness;

        public MenuRenderer(bool isMainMenu, Color primaryColor, Color textColor)
            : base(new MenuColorTable(isMainMenu, primaryColor))
        {
            this.primaryColor = primaryColor;
            this.textColor = textColor;
            arrowThickness = isMainMenu ? 3 : 2;
        }

        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            base.OnRenderItemText(e);
            e.Item.ForeColor = e.Item.Selected ? Color.White : textColor;
        }
        protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
        {
            base.OnRenderArrow(e);
            Graphics graphics = e.Graphics;
            ToolStripItem item = e.Item;
            Rectangle arrowRectangle = e.ArrowRectangle;
            DrawArrow(graphics, item, arrowRectangle);
        }

        private void DrawArrow(Graphics graphics, ToolStripItem item, Rectangle arrowRectangle)
        {
            Size arrowSize = new(5, 12);
            Color arrowColor = item.Selected ? Color.White : primaryColor;
            Point location = arrowRectangle.Location;
            Rectangle rectangle = new(location.X, (arrowRectangle.Height - arrowSize.Height) / 2,
                arrowSize.Width, arrowSize.Height);

            using var path = new GraphicsPath();
            using var pen = new Pen(arrowColor, arrowThickness);

            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            path.AddLine(rectangle.Left, rectangle.Top, rectangle.Right, rectangle.Top + rectangle.Height / 2);
            path.AddLine(rectangle.Right, rectangle.Top + rectangle.Height / 2, rectangle.Left, rectangle.Top + rectangle.Height);
            graphics.DrawPath(pen, path);
        }
    }
}