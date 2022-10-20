using ZooBazaar_Windows_Forms_Application.controls;

namespace ZooBazaar_Windows_Forms_Application
{
    public partial class Form1 : Form
    {
        ZooBazaar_MainForm updatedUIForm;

        private MainMenuTable mainMenutable;

        public Form1()
        {
            InitializeComponent();
            updatedUIForm = new ZooBazaar_MainForm();
            updatedUIForm.Show();


            mainMenutable = new MainMenuTable();
            Text = "Menager";
            Size = new Size(1920 , 1080);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Controls.Add(mainMenutable);
        }
    }
}