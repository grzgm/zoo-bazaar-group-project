using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooBazaar_DomainModels.Models;
using ZooBazaar_Windows_Forms_Application.UpdatedUIControls.Theme;

namespace ZooBazaar_Windows_Forms_Application.UpdatedUIControls.InfoFormControls
{
    public class StaticInfoTable : TableLayoutPanel
    {
        private InfoForm infoForm;

        private InfoTable infoTable;
        private Label tabLabel;

        public StaticInfoTable(InfoForm parentForm)
        {
            infoForm = parentForm;

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

        public StaticInfoTable(InfoForm parentForm, Employee employee) : this(parentForm)
        {
            infoTable = new InfoTable(infoForm, employee);
            Controls.Add(infoTable, 2, 1);
        }
        public StaticInfoTable(InfoForm parentForm, Animal animal) : this(parentForm)
        {
            infoTable = new InfoTable(infoForm, animal);
            Controls.Add(infoTable, 2, 1);
        }
        public StaticInfoTable(InfoForm parentForm, Habitat habitat) : this(parentForm)
        {
            infoTable = new InfoTable(infoForm, habitat);
            Controls.Add(infoTable, 2, 1);
        }
        public StaticInfoTable(InfoForm parentForm, Zone zone) : this(parentForm)
        {
            infoTable = new InfoTable(infoForm, zone);
            Controls.Add(infoTable, 2, 1);
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

