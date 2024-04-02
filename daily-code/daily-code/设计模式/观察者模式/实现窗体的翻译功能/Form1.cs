using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 实现窗体的翻译功能
{
    public partial class Form1 : BaseForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Form2().Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

      

        /// <summary>
        /// 切换成中文
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            ObsolotoMgr.CalltrnsHandler("zh-cn");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ObsolotoMgr.CalltrnsHandler("us-en");
        }
    }
}
