using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooBazaar_Windows_Forms_Application.UpdatedUIControls.Theme;

namespace ZooBazaar_Windows_Forms_Application.UpdatedUIControls.Buttons
{
    internal class ActionBaseButton : Button
    {

        private int borderSize;
        private int borderRadius;
        private Color borderColor;
        public ActionBaseButton()
        {
            Dock = DockStyle.Right;
            Height = 100;
            Width = 400;
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            Margin = new Padding(25);
            BackColor = ThemeColors.highlightColor;
            borderRadius = this.Height;
            TextAlign = ContentAlignment.MiddleCenter;
            Font = new Font("Calibri", 24, FontStyle.Bold);
            ForeColor = ThemeColors.primaryColor;
        }

        private GraphicsPath GetFigurePath(RectangleF rect, float radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.Width - radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.Width - radius, rect.Height - radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();

            return path;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            RectangleF rectsurface = new RectangleF(0, 0, this.Width, this.Height);
            RectangleF rectBorder = new RectangleF(1, 1, this.Width - 0.8f, this.Height - 1);

            if (borderRadius > 2)
            {
                using (GraphicsPath pathSurface = GetFigurePath(rectsurface, borderRadius))
                using (GraphicsPath pathBorder = GetFigurePath(rectBorder, borderRadius - 1F))
                using (Pen penSurface = new Pen(this.Parent.BackColor, 2))
                using (Pen penBorder = new Pen(borderColor, borderSize))
                {
                    penBorder.Alignment = PenAlignment.Inset;

                    this.Region = new Region(pathSurface);

                    pevent.Graphics.DrawPath(penSurface, pathSurface);

                    if (borderSize >= 1)
                    {
                        pevent.Graphics.DrawPath(penBorder, pathBorder);
                    }
                }

            }
        }
    }
}
