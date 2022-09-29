using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooBazaar_Windows_Forms_Application.controls
{
    internal class MainMenuTable : TableLayoutPanel
    {
        //Fields
        private string[] menuButtonsText;

        //Controls
        private MainScheduleTable mainScheduleTable;
        private MenuButton[] menuButtons;

        //Color
        SolidBrush highlightBrush;

        public MainMenuTable()
        {
            //Fields
            menuButtonsText = new string[] { "s", "e", "a" };

            //Controls
            mainScheduleTable = new MainScheduleTable();
            menuButtons = new MenuButton[3];



            //controls -> buttons
            for (int i = menuButtonsText.Length - 1; i >= 0; i--)
            {
                MenuButton menuButton = new MenuButton(i, menuButtonsText[i], this);
                menuButtons[i] = menuButton;
                Controls.Add(menuButton, 0, 1);
            }


            //Properties
            Dock = DockStyle.Fill;
            ColumnCount = 3;
            ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100));
            ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 10));
            ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));


            RowCount = 2;
            RowStyles.Add(new RowStyle(SizeType.Absolute, 50));
            RowStyles.Add(new RowStyle(SizeType.Percent, 100));



            //Colors
            highlightBrush = new SolidBrush(Color.Green);

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
                    switch (i)
                    {
                        case 0:
                            Controls.Add(mainScheduleTable, 2, 1);
                            break;
                        case 1:
                            break;
                        case 2:
                            break;
                    }
                }
            }
            //depending on what button load connected table
        }


        private void TableLayoutPanel_CellPaint(object? sender, TableLayoutCellPaintEventArgs e)
        {
            if (e.Row == 0 && e.Column == 2)
            {
                e.Graphics.FillRectangle(highlightBrush, e.CellBounds);
            }


            if (e.Column == 1)
            {
                e.Graphics.FillRectangle(highlightBrush, e.CellBounds);
            }
        }

    }
}
