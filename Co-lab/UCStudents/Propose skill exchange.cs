using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Co_LAB
{
    [System.ComponentModel.DesignerCategory("UserControl")]
    public partial class Propose_skill_exchange : UserControl
    {
        public Propose_skill_exchange()
        {
            InitializeComponent();
        }

        private void pnlProfileCard_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using var pen = new Pen(Color.FromArgb(42, 68, 52), 1.5f);
            using var path = CreateRoundedRectanglePath(new Rectangle(1, 1, pnlProfileCard.Width - 3, pnlProfileCard.Height - 3), 8);
            e.Graphics.DrawPath(pen, path);
        }

        private void pnlAvatar_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Circular dark background
            using var bgBrush = new SolidBrush(Color.FromArgb(22, 40, 30));
            e.Graphics.FillEllipse(bgBrush, 1, 1, 36, 36);

            using var borderPen = new Pen(Color.FromArgb(50, 78, 62), 1.5f);
            e.Graphics.DrawEllipse(borderPen, 1, 1, 36, 36);

            // White silhouette person icon
            using var whiteBrush = new SolidBrush(Color.White);
            // Head
            e.Graphics.FillEllipse(whiteBrush, 14, 8, 11, 11);
            // Shoulders
            using var path = new GraphicsPath();
            path.AddArc(7, 21, 24, 22, 180, 180);
            path.CloseFigure();
            e.Graphics.FillPath(whiteBrush, path);
        }

        private static GraphicsPath CreateRoundedRectanglePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int diameter = radius * 2;
            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}
