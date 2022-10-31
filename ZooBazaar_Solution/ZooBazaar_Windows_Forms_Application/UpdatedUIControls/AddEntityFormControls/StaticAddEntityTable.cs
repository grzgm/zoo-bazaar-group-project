using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ZooBazaar_Windows_Forms_Application.UpdatedUIControls.Theme;

namespace ZooBazaar_Windows_Forms_Application.UpdatedUIControls.AddEntityControls
{
    internal class StaticAddEntityTable : TableLayoutPanel
    {
        private EmployeePropertiesTable employeePropertiesTable;
        private AnimalPropertiesTable animalPropertiesTable;
        private HabitatPropertiesTable habitatPropertiesTable;
        private ZonePropertiesTable zonePropertiesTable;


        private Label tabLabel;

        public StaticAddEntityTable()
        {
            tabLabel = new Label();
            tabLabel.Dock = DockStyle.Fill;
            tabLabel.Padding = Padding.Empty;
            tabLabel.BackColor = ThemeColors.highlightColor;
            tabLabel.TextAlign = ContentAlignment.MiddleLeft;
            tabLabel.Font = new Font("Calibri", 14, FontStyle.Bold);
            tabLabel.ForeColor = ThemeColors.primaryColor;


            Controls.Add(tabLabel, 2, 0);

            //properties
            Dock = DockStyle.Fill;
            Padding = Padding.Empty;
            Margin = Padding.Empty;

            ColumnCount = 3;
            ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100));
            ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 10));
            ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

            RowCount = 2;
            RowStyles.Add(new RowStyle(SizeType.Absolute, 50));
            RowStyles.Add(new RowStyle(SizeType.Percent, 100));

            //events
            this.CellPaint += TableLayoutPanel_CellPaint;
        }
        
        public StaticAddEntityTable(int entityId, AddForm addForm) : this()
        {
            switch (entityId)
            {
                case 0: //Employee
                    tabLabel.Text = "New Employee";
                    employeePropertiesTable = new EmployeePropertiesTable(addForm);
                    Controls.Add(employeePropertiesTable, 2, 1);
                    break;
                case 1: //Animal
                    tabLabel.Text = "New Animal";
                    animalPropertiesTable = new AnimalPropertiesTable();
                    Controls.Add(animalPropertiesTable, 2, 1);
                    break;
                case 2: //Habitat
                    tabLabel.Text = "New Habitat";
                    habitatPropertiesTable = new HabitatPropertiesTable();
                    Controls.Add(habitatPropertiesTable, 2, 1);
                    break;
                case 3: //Zone
                    tabLabel.Text = "New Zone";
                    zonePropertiesTable = new ZonePropertiesTable();
                    Controls.Add(zonePropertiesTable, 2, 1);
                    break;
                case 4: //Stock
                    break;
            }
            
        }
      
        private void TableLayoutPanel_CellPaint(object? sender, TableLayoutCellPaintEventArgs e)
        {
            SolidBrush brush;
            if (e.Row == 0 && e.Column == 2)
            {
                brush = new SolidBrush(ThemeColors.highlightColor);
                e.Graphics.FillRectangle(brush, e.CellBounds);
            }
            else if (e.Column == 1)
            {
                brush = new SolidBrush(ThemeColors.highlightColor);
                e.Graphics.FillRectangle(brush, e.CellBounds);
            }
            else if (e.Column == 0)
            {
                brush = new SolidBrush(ThemeColors.foregroundColor);
                e.Graphics.FillRectangle(brush, e.CellBounds);
            }
            else if (e.Column == 2 && e.Row == 1)
            {
                brush = new SolidBrush(ThemeColors.backgroundColor);
                e.Graphics.FillRectangle(brush, e.CellBounds);
            }
        }
    }
}
