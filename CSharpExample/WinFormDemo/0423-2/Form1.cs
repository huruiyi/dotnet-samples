using System;
using System.Windows.Forms;

namespace _0423_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ListViewItem lvi0 = new ListViewItem("小强", 0);
            ListViewItem lvi1 = new ListViewItem("旺财", 1);
            ListViewItem lvi2 = new ListViewItem("大黄", 2);
            ListViewItem lvi3 = new ListViewItem("小牛", 3);
            ListViewItem lvi4 = new ListViewItem("笨笨", 4);
            listView2.Items.Add(lvi0);
            listView2.Items.Add(lvi1);
            listView2.Items.Add(lvi2);
            listView2.Items.Add(lvi3);
            listView2.Items.Add(lvi4);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listView2.View = View.SmallIcon;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listView2.View = View.LargeIcon;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listView2.Items[0].SubItems.AddRange(new string[] { "111111", "男", "18" });
            listView2.Items[1].SubItems.AddRange(new string[] { "222222", "女", "19" });
            listView2.Items[2].SubItems.AddRange(new string[] { "333333", "男", "20" });
            listView2.Items[3].SubItems.AddRange(new string[] { "444444", "女", "30" });
            listView2.Items[4].SubItems.AddRange(new string[] { "555555", "男", "40" });
            listView2.View = View.Details;
        }
    }
}