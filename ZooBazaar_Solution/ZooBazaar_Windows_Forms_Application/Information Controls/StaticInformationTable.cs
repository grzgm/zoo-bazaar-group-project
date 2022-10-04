using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooBazaar_Windows_Forms_Application.Theme;
using ZooBazaar_Windows_Forms_Application.Information_Controls;
using ZooBazaar_DTO.DTOs;
using ZooBazaar_ClassLibrary;
using ZooBazaar_ClassLibrary.Interfaces;
using ZooBazaar_ClassLibrary.Menagers;
using ZooBazaar_Repositories.Interfaces;
using ZooBazaar_Repositories.Repositories;
using ZooBazaar_Windows_Forms_Application.Theme;
using ZooBazaar_DomainModels.Models;

namespace ZooBazaar_Windows_Forms_Application.controls
{
    internal class StaticInformationTable : TableLayoutPanel
    {
        private EmployeeInformationForm employeeInformationForm;

        //fields
        private SolidBrush highLightBrush;
        
        //conrols
        private CloseButton CloseButton;
        private Panel ButtonPanel;
        private EmployeeInformationTable employeeInformationTable;

        public StaticInformationTable(EmployeeInformationForm parent, Employee employee)
        {
            employeeInformationForm = parent;

            Dock = DockStyle.Fill;
            Margin = Padding.Empty;


            //table style
            ColumnCount = 3;
            ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100));
            ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 10));
            ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

            RowCount = 1;
            RowStyles.Add(new RowStyle(SizeType.Percent));

            //controls
            //EmployeeInformationTable
            employeeInformationTable = new EmployeeInformationTable(employee);
            Controls.Add(employeeInformationTable, 2, 0);
            //ButtonPanel
            ButtonPanel = new Panel();
            ButtonPanel.Dock = DockStyle.Fill;
            ButtonPanel.Margin = Padding.Empty;
            Controls.Add(ButtonPanel,0,0);

            
            //CloseButton
            CloseButton = new CloseButton(parent);
            ButtonPanel.Controls.Add(CloseButton);


            //events
            this.CellPaint += TableLayoutPanel_CellPaint;
        }


        private void TableLayoutPanel_CellPaint(object? sender, TableLayoutCellPaintEventArgs e)
        {
            if(e.Column == 0)
            {
                highLightBrush = new SolidBrush(ThemeColors.primaryColor);
                e.Graphics.FillRectangle(highLightBrush, e.CellBounds);
            }
            else if(e.Column == 1)
            {
                highLightBrush = new SolidBrush(ThemeColors.highlightColor);
                e.Graphics.FillRectangle(highLightBrush, e.CellBounds);
            }

        }
    }
}
