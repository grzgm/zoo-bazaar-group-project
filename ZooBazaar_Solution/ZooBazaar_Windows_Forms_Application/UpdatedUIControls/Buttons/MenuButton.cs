using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ZooBazaar_Windows_Forms_Application.UpdatedUIControls.Tables;
using ZooBazaar_Windows_Forms_Application.UpdatedUIControls.Theme;


namespace ZooBazaar_Windows_Forms_Application.UpdatedUIControls.Buttons
{
    internal class MenuButton : Button
    {
        int id;

        MainMenuTable parentTable;

        public MenuButton(int id, MainMenuTable parentTable)
        {
            this.id = id;   
            this.parentTable = parentTable;

            
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
                    //this.BackgroundImage = Properties.Resources.HabitatIcon;
                    break;
                case 4:
                    //this.BackgroundImage = Properties.Resources.ZoneIcon;
                    break;
                case 5:
                    //this.BackgroundImage = Properties.Resources.StockIcon;
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

            //events
            this.Click += new System.EventHandler(this.MenuButton_Click);
        }

        private void MenuButton_Click(object? sender, EventArgs e)
        {
            parentTable.ButtonClick(this);
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
            path.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height);
            this.Region = new System.Drawing.Region(path);
            base.OnPaint(pevent);
        }
    }
}
