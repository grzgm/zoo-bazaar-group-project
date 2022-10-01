using System.Drawing;

namespace ZooBazaar_Windows_Forms_Application.controls
{
    internal class AnimalDetailsTable : TableLayoutPanel
    {
        private Label _animalName;
        private Label _animalSpecies;
        private Label _animalHabitat;
        private Label _animalZone;
        private List<Label> _labels;
        private Button _animalMoreInfo;
        public AnimalDetailsTable(string name, string species, string habitat, string zone)
        {
            //assigning controls
            _labels = new List<Label>();

            _animalName = new Label();
            _animalName.Text = name;
            _labels.Add(_animalName);

            _animalSpecies = new Label();
            _animalSpecies.Text = species;
            _labels.Add(_animalSpecies);

            _animalHabitat = new Label();
            _animalHabitat.Text = habitat;
            _labels.Add(_animalHabitat);

            _animalZone = new Label();
            _animalZone.Text = zone;
            _labels.Add(_animalZone);

            foreach (Label _label in _labels)
            {
                _label.Dock = DockStyle.Fill;
                _label.BackColor = Color.LightGray;
                _label.Margin = Padding.Empty;
                _label.TextAlign = ContentAlignment.MiddleLeft;
            }

            _animalMoreInfo = new Button();
            _animalMoreInfo.Text = "...";
            _animalMoreInfo.Dock = DockStyle.Fill;
            _animalMoreInfo.Height = 50;
            _animalMoreInfo.BackColor = Color.Green;
            _animalMoreInfo.FlatStyle = FlatStyle.Flat;
            _animalMoreInfo.FlatAppearance.BorderSize = 0;
            _animalMoreInfo.TextAlign = ContentAlignment.MiddleCenter;
            _animalMoreInfo.Font = new Font("Calibri", 14, FontStyle.Bold);
            _animalMoreInfo.Margin = Padding.Empty;
            _animalMoreInfo.TextAlign = ContentAlignment.MiddleCenter;

            //properties
            Dock = DockStyle.Fill;
            Margin = Padding.Empty;


            //Table styles
            RowCount = 1;
            RowStyles.Add(new RowStyle(SizeType.Absolute, 50));

            ColumnCount = 5;
            ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50));

            //Adding controls
            Controls.Add(_animalName, 0, 0);
            Controls.Add(_animalSpecies, 1, 0);
            Controls.Add(_animalHabitat, 2, 0);
            Controls.Add(_animalZone, 3, 0);
            Controls.Add(_animalMoreInfo, 4, 0);
        }
    }
}