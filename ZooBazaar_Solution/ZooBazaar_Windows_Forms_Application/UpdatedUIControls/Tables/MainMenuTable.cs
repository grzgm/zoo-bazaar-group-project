using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ZooBazaar_Windows_Forms_Application.UpdatedUIControls.Theme;
using ZooBazaar_Windows_Forms_Application.UpdatedUIControls.Buttons;
using ZooBazaar_Windows_Forms_Application.UpdatedUIControls.Tables;


namespace ZooBazaar_Windows_Forms_Application.UpdatedUIControls.Tables
{
    internal class MainMenuTable : TableLayoutPanel
    {
        MenuButton[] menuButtons;

        MainScheduleTable mainScheduleTable;
        MainEmployeeTable mainEmployeeTable;
        MainAnimalTable mainAnimalTable;
        MainZoneTable mainZoneTable;
        MainHabitatTable mainHabitatTable;
        MainStockTable mainStockTable;

        Label tabLabel;




        public MainMenuTable()
        {
            //controls
            menuButtons = new MenuButton[6];

            mainScheduleTable = new MainScheduleTable();
            mainEmployeeTable = new MainEmployeeTable();
            mainAnimalTable = new MainAnimalTable();
            mainZoneTable = new MainZoneTable();
            mainHabitatTable = new MainHabitatTable();
            mainStockTable = new MainStockTable();

            tabLabel = new Label();
            tabLabel.Dock = DockStyle.Fill;
            tabLabel.Padding = Padding.Empty;
            tabLabel.BackColor = ThemeColors.highlightColor;
            tabLabel.TextAlign = ContentAlignment.MiddleLeft;
            tabLabel.Font = new Font("Calibri", 14, FontStyle.Bold);
            tabLabel.ForeColor = ThemeColors.primaryColor;
            tabLabel.Text = "Test";

            Controls.Add(tabLabel, 2,0 );

            //controls -> buttons
            Panel panel = new Panel();
            panel.Dock = DockStyle.Fill;
            panel.Padding = Padding.Empty;
            panel.Margin = new Padding(0,51,0,0);
            panel.BackColor = ThemeColors.foregroundColor;
            for (int i = menuButtons.Length - 1; i >= 0; i--)
            {
                //create panel
                Panel buttonPanel = new Panel();
                buttonPanel.Dock = DockStyle.Top;
                buttonPanel.Height = 100;
                buttonPanel.Padding = new Padding(10);
                buttonPanel.Margin = Padding.Empty;
                buttonPanel.BackColor = ThemeColors.foregroundColor;

                MenuButton menuButton = new MenuButton(i, this);
                menuButtons[i] = menuButton;
                buttonPanel.Controls.Add(menuButton);
                panel.Controls.Add(buttonPanel);
            }
            Controls.Add(panel, 0, 1);


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

        public void ButtonClick(MenuButton buttonClicked)
        {

            Controls.Remove(GetControlFromPosition(2, 1));
            for (int i = 0; i < menuButtons.Length; i++)
            {
                if (menuButtons[i] == buttonClicked)
                {

                    menuButtons[i].BackColor = ThemeColors.highlightColor;

                    switch (i)
                    {
                        case 0:
                            Controls.Add(mainScheduleTable, 2, 1);
                            tabLabel.Text = "Schedule";
                            break;
                        case 1:
                            Controls.Add(mainEmployeeTable, 2, 1);
                            tabLabel.Text = "Employees";
                            break;
                        case 2:
                            Controls.Add(mainAnimalTable, 2, 1);
                            tabLabel.Text = "Animals";
                            break;
                        case 3:
                            Controls.Add(mainHabitatTable, 2, 1);
                            tabLabel.Text = "Habitats";
                            break;
                        case 4:
                            Controls.Add(mainZoneTable, 2, 1);
                            tabLabel.Text = "Zones";
                            break;
                        case 5:
                            Controls.Add(mainStockTable, 2, 1);
                            tabLabel.Text = "Stock";
                            break;
                    }
                }
                else
                {
                    menuButtons[i].BackColor = ThemeColors.menuButtonColor;
                }
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
