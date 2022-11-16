using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooBazaar_DomainModels.Models;
using ZooBazaar_Windows_Forms_Application.Theme;
using ZooBazaar_Windows_Forms_Application.UpdatedUIControls.Tables;

namespace ZooBazaar_Windows_Forms_Application.UpdatedUIControls.Buttons
{
    internal class InfoButton : Button
    {

        private int borderSize;
        private int borderRadius;
        private Color borderColor;

        private InfoForm infoForm;

        private Employee currentEmployee;
        private Animal currentAnimal;
        private Habitat currentHabitat;
        private Zone currentZone;

        public InfoButton() 
        {
            //properties
            Dock = DockStyle.Fill;
            BackColor = ThemeColors.highlightColor;
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            TextAlign = ContentAlignment.MiddleCenter;
            Font = new Font("Calibri", 14, FontStyle.Bold);
            Margin = Padding.Empty;

            this.BackgroundImage = Properties.Resources.InfoIcon;
            this.BackgroundImageLayout = ImageLayout.Stretch;

            borderRadius = 10;
        }

        public InfoButton(ElementTable elementTable, Employee employee) : this() 
        {
            currentEmployee = employee;
            this.Click += new System.EventHandler(this.EmployeeInfo_OnClick);
        }
        public InfoButton(ElementTable elementTable, Animal animal) : this()
        {
            currentAnimal = animal;
        }
        public InfoButton(ElementTable elementTable, Habitat habitat) : this()
        {
            currentHabitat = habitat;
        }
        public InfoButton(ElementTable elementTable, Zone zone) : this()
        {
            currentZone = zone;
        }


        private void EmployeeInfo_OnClick(object sender, EventArgs e)
        {
            InfoForm infoForm = new InfoForm(currentEmployee);
            infoForm.Show();
        }

        private void AnimalInfo_OnClick(object sender, EventArgs e)
        {
            InfoForm infoForm = new InfoForm(currentAnimal);
            infoForm.Show();

        }
        private void HabitatInfo_OnClick(object sender, EventArgs e)
        {
            InfoForm infoForm = new InfoForm(currentHabitat);
            infoForm.Show();

        }
        private void ZoneInfo_OnClick(object sender, EventArgs e)
        {
            InfoForm infoForm = new InfoForm(currentZone);
            infoForm.Show();

        }


        //create rounded corners
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
