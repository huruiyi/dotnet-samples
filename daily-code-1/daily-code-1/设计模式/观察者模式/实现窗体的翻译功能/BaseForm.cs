using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace 实现窗体的翻译功能
{
    using System.Windows.Forms;
    public class BaseForm : Form
    {
        public BaseForm()
        {
            ObsolotoMgr.trnsHandler += Transformor;
        }

        /// <summary>
        /// 负责接收语言参数，将当前页面上的所有lable控件的text翻译成英文
        /// </summary>
        /// <param name="lang"></param>
        public virtual void Transformor(string lang)
        {
            Label tmp;
            foreach (Control item in this.Controls)
            {
                if (item is Label)
                {
                    tmp = item as Label;
                    if (lang == "zh-cn")
                    {
                         tmp.Text = "确认";
                    }
                    else if (lang == "us-en")
                    {
                        tmp.Text = "OK";
                    }
                }
                else
                {
                    TransformorSub(lang, item);
                }
            }
        }

        private void TransformorSub(string lang, Control ctl)
        {
            Label tmp;
            foreach (Control item in ctl.Controls)
            {
                if (item is Label)
                {
                    tmp = item as Label;
                    if (lang == "zh-cn")
                    {
                        tmp.Text = "确认";
                    }
                    else if (lang == "us-en")
                    {
                        tmp.Text = "OK";
                    }
                }
                else
                {
                    TransformorSub(lang, item);
                }
            }
        }
    }
}
