using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooBazaar_Windows_Forms_Application.Theme;


namespace ZooBazaar_Windows_Forms_Application.controls
{
    internal class MenuButton : Button
    {
        private int id;
        private MainMenuTable mainMenuTable;

        public MenuButton(int id, string t, MainMenuTable mainMenuTable)
        {
            //fields
            this.id = id;
            this.mainMenuTable = mainMenuTable;

            //set icon
            switch (id)
            {
                case 0:
                    this.BackgroundImage = Properties.Resources.ScheduleIcon;
                    break;
                case 1:
                    this.BackgroundImage = Properties.Resources.EmployeesIcon;
                    break;
                case 2:
                    this.BackgroundImage = Properties.Resources.AnimalsIcon;
                    break;
                case 3:
                    break;
                case 4:
                    break;
            }
            this.BackgroundImageLayout = ImageLayout.Stretch;


            //properties
            Dock = DockStyle.Top;
            Height = 80;
            Width = 80;
            BackColor = ThemeColors.menuButtonColor;
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            //Text = t.ToUpper();
            TextAlign = ContentAlignment.MiddleCenter;
            Font = new Font("Calibri", 14, FontStyle.Bold);


            //events
            this.Click += new System.EventHandler(this.MenuButton_Click);
        }

        private void MenuButton_Click(object? sender, EventArgs e)
        {
            mainMenuTable.ButtonClick(this);
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
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0,0,ClientSize.Width,ClientSize.Height);
            this.Region = new System.Drawing.Region(path);
            base.OnPaint(pevent);
        }
    }
}
