using System.Drawing.Printing;

namespace ZooBazaar_Windows_Forms_Application.controls
{
    internal class AnimalActivityTable : TableLayoutPanel
    {
        //Fields
        private string[] animalButtonsText;
        private AnimalTable animalTable;

        //Controls
        private AnimalButton[] _AnimalButtons;
        public AnimalActivityTable(AnimalTable animalTable)
        {

            //Fields
            this.animalTable = animalTable;
            animalButtonsText = new string[] { "Add New Animal" };

            //Controls
            _AnimalButtons = new AnimalButton[1];

            //Properties
            Dock = DockStyle.Fill;
            //Padding = Padding.Empty;
            //Margin = Padding.Empty;
            ColumnCount = _AnimalButtons.Length;
            for (int i = 0; i < _AnimalButtons.Length; i++)
            {
                ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            }


            RowCount = 1;
            RowStyles.Add(new RowStyle(SizeType.Percent, 100));



            //controls -> buttons
            for (int i = animalButtonsText.Length - 1; i >= 0; i--)
            {
                AnimalButton animalButton = new AnimalButton(i, animalButtonsText[i], this);
                _AnimalButtons[i] = animalButton;
                Controls.Add(animalButton, i, 0);
            }

            Dock = DockStyle.Fill;
            Margin = Padding.Empty;
            //BackColor = Color.Red;
        }
        public void ButtonClick(AnimalButton buttonClicked)
        {
            AnimalAdd animalAdd = new AnimalAdd(animalTable);
            animalAdd.Show();
        }
    }
}