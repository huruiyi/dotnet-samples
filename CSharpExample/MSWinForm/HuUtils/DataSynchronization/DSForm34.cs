using System;
using System.Windows.Forms;

namespace HuUtils.DataSynchronization
{
    public partial class DsForm34 : Form
    {
        public DsForm34()
        {
            InitializeComponent();
        }


        public DSForm3 F1Demo { get; set; }

        public DSForm4 F2Demo { get; set; }

        private void Button1_Click(object sender, EventArgs e)
        {
            DSForm3 form1 = new DSForm3();
            F1Demo = form1;
            form1.Show();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (F2Demo != null)
            {
                F2Demo.Show();
            }
            else
            {
                DSForm4 form2 = new DSForm4();
                F2Demo = form2;

                //if (F1Demo.SendMsg == null)
                //{
                //    F1Demo.SendMsg = new Action<string>(f.SetText);
                //}
                //else
                //{
                //    //F1Demo.SendMsg -= f.SetText;
                //    //F1Demo.SendMsg += f.SetText;
                //}

                //注册事件响应方法
                F1Demo.AfterSendText += form2.AfterRecieveData;

                F1Demo.F2Demo = form2;

                F1Demo.ListOb.Add(form2);

                //事件触发只能在 类型内部触发。不能在类的外面触发事件。这就是事件的优势。
                //F1Demo.AfterSendText(this, null);

                form2.Show();
            }
        }
    }
}
