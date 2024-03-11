using System;
using System.Management;
using System.Windows.Forms;

namespace KeyGenerator
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.btnCreateKey.Enabled = false;

            ManagementClass mc = new ManagementClass("win32_processor");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                txtMachineCode.Text = mo.Properties["processorid"].Value + mo.Properties["processorid"].Value.ToString();
                break;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            frmIn fi = new frmIn();
            fi.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnRegistry_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Equals("") || txtEmail.Text.Equals(""))
            {
                MessageBox.Show("ÇëÌîÐ´×¢²áÐÅÏ¢£¡", "¾¯¸æ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                RegText rt = new RegText(txtName.Text);
                RegOperate ro = new RegOperate();
                rt.Email = txtEmail.Text;
                rt.MachineCode = txtMachineCode.Text;
                rt.RegCode = ro.GetRegCode(txtMachineCode.Text);
                ro.XmlWrite(rt);
                btnCreateKey.Enabled = true;
            }
        }

        private void btnCreateKey_Click(object sender, EventArgs e)
        {
            RegOperate ro = new RegOperate();
            ro.XmlToPassword();
            btnCreateKey.Enabled = false;
        }

        private void btnViewMkey_Click(object sender, EventArgs e)
        {
            new frmIn().ShowDialog();
        }
    }
}