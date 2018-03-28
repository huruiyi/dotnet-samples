using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormDemo.SyncAsyncAPMForm
{
    public partial class ASyncSyncForm : Form
    {
        public ASyncSyncForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 500000; i++)
            {
                Console.WriteLine("X");
            }

            MessageBox.Show("同步Ok");
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            await TestAsync();
        }

        private async Task TestAsync()
        {
            await Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < 20000; i++)
                {
                    Console.WriteLine("X");
                }
            });
        }
    }
}