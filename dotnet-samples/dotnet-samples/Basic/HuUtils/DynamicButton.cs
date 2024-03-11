using System;
using System.Drawing;
using System.Windows.Forms;

namespace HuUtils
{
    public partial class DynamicButton : Form
    {
        public DynamicButton()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            int index = 0;
            Button btn;
            int row = 6;
            int col = 9;
            int width = 100;
            int height = 35;
            for (int i = 1; i <= row; i++)
            {
                for (int j = 1; j <= col; j++)
                {
                    index = j + col * (i - 1);
                    btn = new Button();
                    btn.Name = $"btnDemo{i * j}";
                    btn.Text = $"Demo{index}";
                    btn.Width = width;
                    btn.Height = height;
                    btn.Location = new Point(100 * (j - 1), 35 * (i - 1));
                    btn.Tag = index;
                    this.Controls.Add(btn);
                    btn.Click += Btn_Click;
                }
            }
            this.Width = width * col;
            this.Height = height * row;

            #region 添加一个按钮

            //Button btn = new Button();
            //btn.Name = "btnDemo1";
            //btn.Text = "Demo1";
            //btn.Width = 200;
            //btn.Height = 35;
            //btn.Location = new Point(10, 10);
            //this.Controls.Add(btn);
            //btn.Click += Btn_Click;

            #endregion 添加一个按钮
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            string demoNamespace = System.Reflection.MethodBase.GetCurrentMethod().Name;

            Button btn = sender as Button;
            // object obj=     Activator.CreateInstance(demoNamespace + "Form" + this.Tag.ToString().PadLeft(2, '0'),"Form"+ this.Tag.ToString().PadLeft(2, '0'));
            Control[] controls = this.FindForm().Controls.Find("btnTest", true);
            MessageBox.Show(btn.Text + "  " + btn.Tag + "  ", "标题", MessageBoxButtons.OK);
        }
    }
}