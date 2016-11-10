using System;
using System.Windows.Forms;

namespace FormPositionExample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void buttonCustomPosition_Click(object sender, EventArgs e)
        {
            int x = 0, y = 0;
            int.TryParse(textBox1.Text, out x);
            int.TryParse(textBox2.Text, out y);
            Form2 fm = new Form2(x, y);
            fm.ShowDialog();
        }

        private void buttonCustomShape_Click(object sender, EventArgs e)
        {
            Form2 fm = new Form2(true);
            fm.ShowDialog();
        }

        private void buttonCenter_Click(object sender, EventArgs e)
        {
            Form2 fm = new Form2();
            fm.ShowDialog();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
    }
}