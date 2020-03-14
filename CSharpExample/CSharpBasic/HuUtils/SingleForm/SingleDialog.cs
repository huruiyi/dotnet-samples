using System.Windows.Forms;

namespace HuUtils.SingleForm
{
    public partial class SingleDialog : Form
    {
        private SingleDialog() 
        {
            InitializeComponent();
        }
        private static SingleDialog show=null; 
        public static SingleDialog dg() 
        {
            if (show == null || show.IsDisposed) 
            {
                show = new SingleDialog();
            }
            return show;
        }
        public static SingleDialog dlg() 
        {
            show = new SingleDialog();
            return show;
        }
    }
}
