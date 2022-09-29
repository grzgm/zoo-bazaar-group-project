using ZooBazaar_Windows_Forms_Application.controls;

namespace ZooBazaar_Windows_Forms_Application
{
    public partial class Form1 : Form
    {
        private MainMenuTable mainMenutable;

        public Form1()
        {
            InitializeComponent();
            mainMenutable = new MainMenuTable();

            Size = new Size(1920 , 1080);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Controls.Add(mainMenutable);
        }
    }
}