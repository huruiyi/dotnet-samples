using System.Windows.Forms;

namespace FormExample
{
    public partial class WelcomForm : Form
    {
        public WelcomForm()
        {
            InitializeComponent();
        }

        private void WelcomForm_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }
    }
}