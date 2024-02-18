namespace attendanceSystem
{
    public partial class Login : Form
    {

        public Login()
        {
            InitializeComponent();
        }

        public void loginBtn_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;

            if (button != null)
            {
                textBox1.Text = DataManager.getUserXmlById(3).DocumentElement.InnerXml;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
