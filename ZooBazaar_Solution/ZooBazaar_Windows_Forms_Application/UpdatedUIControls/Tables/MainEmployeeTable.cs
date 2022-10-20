using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ZooBazaar_Windows_Forms_Application.UpdatedUIControls.Theme;

namespace ZooBazaar_Windows_Forms_Application.UpdatedUIControls.Tables
{
    internal class MainEmployeeTable : TableLayoutPanel
    {
        private AddForm addForm;

        private EmployeeFilterTable filterTable;
        private ElementTable elementTable;
        private ActionTable actionTable;
        private AddNewButton addButton;
        public MainEmployeeTable()
        {

            //fields
            elementTable = new ElementTable(0);
            filterTable = new EmployeeFilterTable(elementTable);
            actionTable = new ActionTable();
            addButton = new AddNewButton(this);

            actionTable.Controls.Add(addButton);
            //properties
            Dock = DockStyle.Fill;
            BackColor = Color.Transparent;


            ColumnCount = 1;
            ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            RowCount = 5;
            RowStyles.Add(new RowStyle(SizeType.Absolute, 50));
            RowStyles.Add(new RowStyle(SizeType.Absolute, 1));
            RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            RowStyles.Add(new RowStyle(SizeType.Absolute, 1));
            RowStyles.Add(new RowStyle(SizeType.Absolute, 150));

            //events
            this.CellPaint += TableLayoutPanel_CellPaint;


            //Controls
            Controls.Add(filterTable,0,0);
            Controls.Add(elementTable,0,2);
            Controls.Add(actionTable,0,4);
            

        }

        public void OpenAddForm()
        {
            addForm = new AddForm(0);
            addForm.Text = "New Employee";
            addForm.Show();
        }

        private void TableLayoutPanel_CellPaint(object? sender, TableLayoutCellPaintEventArgs e)
        {
            SolidBrush brush;
            if (e.Row % 2 != 0)
            {
                brush = new SolidBrush(ThemeColors.secondaryColor);
                e.Graphics.FillRectangle(brush, e.CellBounds);
            }
            else
            {
                brush = new SolidBrush(Color.Transparent);
                e.Graphics.FillRectangle(brush, e.CellBounds);
            }
        }
    }
}
