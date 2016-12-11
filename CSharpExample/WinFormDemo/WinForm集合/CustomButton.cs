using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForm集合
{
   
    public class CustomButton : Button
    {
        public delegate void MyEventHandler(object sender, EventArgs e);

        [Description("我的自定义事件"), Browsable(true)]
        public event MyEventHandler MyEventHandlerColorChange;//ColorChange会在属性窗口显示

        protected virtual void OnColorChange(EventArgs e)
        {
            if (MyEventHandlerColorChange != null)
                MyEventHandlerColorChange(this, e);
        }

        public MyEventHandler 点击事件;

        [Browsable(true), Description("测试,我的自定义控件"), DefaultValue(Eenum.A2), Localizable(true), DisplayName("第一")]
        public Eenum A { get; set; }

        public CustomButton()
        {
            base.Click += CustomButton_Click;
        }

        private void CustomButton_Click(object sender, EventArgs e)
        {
            if (点击事件 != null)
            {
                点击事件(sender, e);
            }
        }
    }

    public enum Eenum
    {
        A1, A2, A3, A4
    }
}