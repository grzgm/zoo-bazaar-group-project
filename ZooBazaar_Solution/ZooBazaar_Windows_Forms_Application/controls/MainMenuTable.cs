using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooBazaar_Windows_Forms_Application.Schedule;
using ZooBazaar_Windows_Forms_Application.Theme;

namespace ZooBazaar_Windows_Forms_Application.controls
{
    internal class MainMenuTable : TableLayoutPanel
    {
        //Fields
        private string[] menuButtonsText;

        //Controls
        //private Schedule.MainScheduleTable mainScheduleTable;
        private MainEmployeeTable mainEmployeeTable;
        private MainAnimalTable mainAnimalTable;
        private MenuButton[] menuButtons;
        private Panel buttonPanel;
        private Label tabLabel;

        //Color
        SolidBrush primaryBrush;
        SolidBrush highlightBrush;

        public MainMenuTable()
        {
            //Fields
            menuButtonsText = new string[] { "s", "e", "a" };

            //Controls
            //mainScheduleTable = new Schedule.MainScheduleTable();
            mainEmployeeTable = new MainEmployeeTable();
            mainAnimalTable = new MainAnimalTable();
            menuButtons = new MenuButton[3];

            buttonPanel = new Panel();
            buttonPanel.Dock = DockStyle.Fill;
            buttonPanel.Padding = Padding.Empty;
            Controls.Add(buttonPanel, 0, 1);

            tabLabel = new Label();
            tabLabel.Dock = DockStyle.Fill;
            tabLabel.Padding = Padding.Empty;
            tabLabel.BackColor = ThemeColors.highlightColor;
            tabLabel.TextAlign = ContentAlignment.MiddleLeft;
            tabLabel.Font = new Font("Calibri", 14, FontStyle.Bold);
            tabLabel.Text = "Test";

            Controls.Add(tabLabel, 2, 0);




            //controls -> buttons
            for (int i = menuButtonsText.Length - 1; i >= 0; i--)
            {
                MenuButton menuButton = new MenuButton(i, menuButtonsText[i], this);
                menuButtons[i] = menuButton;
                buttonPanel.Controls.Add(menuButton);
            }

            //Debug Employees fast render
            //Controls.Add(mainScheduleTable, 2, 1);
            //Controls.Add(mainEmployeeTable, 2, 1);
            //Controls.Add(mainAnimalTable, 2, 1);


            //Properties
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



            //Colors
            primaryBrush = new SolidBrush(ThemeColors.primaryColor);
            highlightBrush = new SolidBrush(ThemeColors.highlightColor);

            //Events
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
                            //Controls.Add(mainScheduleTable, 2, 1);
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
                    }
                }
                else
                {
                    menuButtons[i].BackColor = ThemeColors.primaryColor;
                }
            }
        }


        private void TableLayoutPanel_CellPaint(object? sender, TableLayoutCellPaintEventArgs e)
        {
            if (e.Row == 0 && e.Column == 2)
            {
                e.Graphics.FillRectangle(highlightBrush, e.CellBounds);
            }
            else if (e.Column == 1)
            {
                e.Graphics.FillRectangle(highlightBrush, e.CellBounds);
            }
            else
            {
                e.Graphics.FillRectangle(primaryBrush, e.CellBounds);
            }
        }

    }
}
