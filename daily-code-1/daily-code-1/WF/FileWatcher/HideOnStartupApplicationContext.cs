using System;
using System.Windows.Forms;
namespace FileWatcher
{
    class HideOnStartupApplicationContext : ApplicationContext
    {
        private Form mainFormInternal;

        // 构造函数，主窗体被存储在mainFormInternal
        public HideOnStartupApplicationContext(Form mainForm)
        {
            this.mainFormInternal = mainForm;
            this.mainFormInternal.Closed += mainFormInternal_Closed;
        }

        void mainFormInternal_Closed(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
