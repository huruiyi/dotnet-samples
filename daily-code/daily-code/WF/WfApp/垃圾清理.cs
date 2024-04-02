using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace WfApp
{
    public partial class 垃圾清理 : Form
    {
        public 垃圾清理()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearRecycle.Clear(true, this);
        }
    }

    internal class ClearRecycle
    {
        [DllImportAttribute("shell32.dll")]
        private static extern int SHEmptyRecycleBin(IntPtr handle, string root, int falgs);

        private const int SHERB_NOCONFIRMATION = 0x000001;
        private const int SHERB_NOPROGRESSUI = 0x000002;
        private const int SHERB_NOSOUND = 0x000004;

        /// <summary>
        /// 清空回收站
        /// </summary>
        /// <param name="tip">是否提示</param>
        /// <param name="form">当前窗体，一般传入this</param>
        public static void Clear(bool tip, Form form)
        {
            DialogResult result;
            if (tip)
                result = MessageBox.Show("确定要清空回收站吗?", "友情提示", MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Information);
            else
                result = DialogResult.Yes;
            if (result == DialogResult.Yes)
            {
                SHEmptyRecycleBin(form.Handle, "", SHERB_NOCONFIRMATION + SHERB_NOPROGRESSUI + SHERB_NOSOUND);
            }
        }
    }
}