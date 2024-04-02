using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MyNotepad
{    
    public partial class MainForm : Form
    {
        Boolean textChangedFlag = false;
        public MainForm()
        {
            InitializeComponent();
        }
        // 下载于www.mycodes.net
        private void 新建NToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String tempText="";
            DialogResult dialogResult=DialogResult.None;
            for(int i=0;i<this.Text.Length;i++)
            {
                if (this.Text.Substring(i, 6).Equals(" - 记事本"))
                {
                    tempText=this.Text.Substring(0,i);
                    break;
                }                    
            }
            if ((!this.Text.Equals("无标题 - 记事本")) || (!mainTextBox.Text.Equals("")))
            {
                dialogResult = MessageBox.Show("是否将更改保存到 " + tempText, "记事本", MessageBoxButtons.YesNoCancel, MessageBoxIcon.None);
            }
            if (dialogResult == DialogResult.Yes)
                保存SToolStripMenuItem_Click(sender,e);
            if (dialogResult != DialogResult.Cancel)
            {
                this.Text = "无标题 - 记事本";
                mainTextBox.Text = "";
            }
        }

        private void 打开OToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.FileName = "";
            DialogResult dialogResult=openFileDialog.ShowDialog();
            saveFileDialog.FileName = openFileDialog.FileName;
            if(dialogResult==DialogResult.OK)
            {
                StreamReader streamReader = new StreamReader(openFileDialog.FileName, System.Text.Encoding.Default);
                int fileNameStatiIndex=0;
                int fileNameLength=0;
                for(int i=openFileDialog.FileName.Length-1;i>=0;i--)
                {
                    if(openFileDialog.FileName.Substring(i,1).Equals("\\"))
                    {
                        fileNameStatiIndex=i+1;
                        break;
                    }
                    else
                        fileNameLength++;
                }
                this.Text = openFileDialog.FileName.Substring(fileNameStatiIndex, fileNameLength)+" - 记事本";
                mainTextBox.Text = streamReader.ReadToEnd();
                streamReader.Dispose();
            }              
        }

        private void 查看帮助HToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("winhlp32");
        }

        private void 关于记事本ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutForm().Show();
        }

        private void 自动换行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainTextBox.WordWrap = !mainTextBox.WordWrap;
            if (mainTextBox.WordWrap)
                自动换行ToolStripMenuItem.Image = MyNotepad.Properties.Resources.selected;
            else
                自动换行ToolStripMenuItem.Image = null;
        }

        private void 状态栏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = !statusStrip.Visible;
            if (statusStrip.Visible)
            {
                状态栏ToolStripMenuItem.Image = MyNotepad.Properties.Resources.selected;
                mainTextBox.Size = new Size(mainTextBox.Size.Width, mainTextBox.Size.Height - 22);
            }
            else
            {
                状态栏ToolStripMenuItem.Image = null;
                mainTextBox.Size = new Size(mainTextBox.Size.Width, mainTextBox.Size.Height + 22);
            }
        }

        private void 保存SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.Text.Equals("无标题 - 记事本"))
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    mainTextBox.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.PlainText);
                    int fileNameStatiIndex = 0;
                    int fileNameLength = 0;
                    for (int i = saveFileDialog.FileName.Length - 1; i >= 0; i--)
                    {
                        if (saveFileDialog.FileName.Substring(i, 1).Equals("\\"))
                        {
                            fileNameStatiIndex = i + 1;
                            break;
                        }
                        else
                            fileNameLength++;
                    }
                    this.Text = saveFileDialog.FileName.Substring(fileNameStatiIndex, fileNameLength) + " - 记事本";
                }
            }
            else
            {
                FileInfo fileInfo = new FileInfo(saveFileDialog.FileName);
                fileInfo.Delete();
                mainTextBox.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.PlainText);
            }
        }

        private void 另存为AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!this.Text.Equals("无标题 - 记事本"))
            {
                int i=0;
                for (;i<this.Text.Length;i++)
                {
                    if(this.Text.ElementAt(i) == '.')
                        break;
                }
                saveFileDialog.FileName = this.Text.Substring(0,i);    
            }
            if(saveFileDialog.ShowDialog()==DialogResult.OK)
            {
                mainTextBox.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.PlainText);
            }
        }

        private void 退出XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void 时间日期DToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainTextBox.Text += DateTime.Now.ToString();
        }

        private void 全选AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainTextBox.SelectAll();
        }

        private void 复制ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!mainTextBox.SelectedText.Equals(""))
                Clipboard.SetDataObject(mainTextBox.SelectedText);
        }

        private void 粘贴PToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IDataObject iDataObject = Clipboard.GetDataObject();
            if (iDataObject.GetDataPresent(DataFormats.Text))
                mainTextBox.SelectedText = (String)iDataObject.GetData(DataFormats.Text);
        }

        private void 剪切XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!mainTextBox.SelectedText.Equals(""))
            {
                Clipboard.SetDataObject(mainTextBox.SelectedText);
                mainTextBox.SelectedText = "";
            }
        }

        private void mainTextBox_SelectionChanged(object sender, EventArgs e)
        {
            if (!mainTextBox.SelectedText.Equals(""))
            {
                复制ToolStripMenuItem.Enabled = true;
                剪切XToolStripMenuItem.Enabled = true;
                删除LToolStripMenuItem.Enabled = true;
            }
            else
            {
                复制ToolStripMenuItem.Enabled = false;
                剪切XToolStripMenuItem.Enabled = false;
                删除LToolStripMenuItem.Enabled = false;
            }
            int selstart = this.mainTextBox.SelectionStart;
            int count = 0;
            int rowNum = 1;
            foreach (char ch in mainTextBox.Text)
            {
                count++;
                if (ch == '\n')
                {
                    rowNum++;
                }
                if (count > selstart)
                {
                    break;
                }
            }
            int j = 0;
            try
            {
                j = this.mainTextBox.Text.LastIndexOf("\n", selstart - 1 > 1 ? selstart - 1 : 1);
            }
            catch
            {

            }
            int lineNum = selstart - j;
            this.toolStripStatusLabel.Text = "|    第 " + rowNum.ToString() + " 行，第 " + lineNum.ToString() + " 列";
        }

        private void 撤销UToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textChangedFlag)
                mainTextBox.Undo();
            else
            {
                mainTextBox.Redo();
                textChangedFlag = true;
                return;
            }
            textChangedFlag = false;
        }

        private void mainTextBox_TextChanged(object sender, EventArgs e)
        {            
            if(mainTextBox.CanUndo)
                撤销UToolStripMenuItem.Enabled = true;
            textChangedFlag = true;
            if(!mainTextBox.Text.Equals(""))
            {
                查找FToolStripMenuItem.Enabled = true;
                查找下一个NToolStripMenuItem.Enabled = true;
            }
            else
            {
                查找FToolStripMenuItem.Enabled = false;
                查找下一个NToolStripMenuItem.Enabled = false;
            }
        }

        private void 删除LToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainTextBox.SelectedText = "";
        }

        private void mainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            String tempText = "";
            DialogResult dialogResult = DialogResult.None;
            for (int i = 0; i < this.Text.Length; i++)
            {
                if (this.Text.Substring(i, 6).Equals(" - 记事本"))
                {
                    tempText = this.Text.Substring(0, i);
                    break;
                }
            }
            if ((!this.Text.Equals("无标题 - 记事本")) || (!mainTextBox.Text.Equals("")))
            {
                dialogResult = MessageBox.Show("是否将更改保存到 " + tempText, "记事本", MessageBoxButtons.YesNoCancel, MessageBoxIcon.None);
            }
            if (dialogResult == DialogResult.Yes)
                保存SToolStripMenuItem_Click(sender, e);
            if (dialogResult != DialogResult.Cancel)
            {
                this.Text = "无标题 - 记事本";
                mainTextBox.Text = "";
            }
        }

        private void 字体FToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FontSelecterForm().Show();
        }

        private void mainTextBox_FontChanged(object sender, EventArgs e)
        {
            
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            Passer.fontNow = mainTextBox.Font.Name.ToString();
            Passer.fontSizeNow = mainTextBox.Font.Size.ToString();
            Passer.fontStyleNow = mainTextBox.Font.Style.ToString();
        }

        private void mainForm_Activated(object sender, EventArgs e)
        {
            float temp;
            float.TryParse(Passer.fontSizeNow,out temp);
            FontStyle fontStyle=FontStyle.Regular;
            switch(Passer.fontStyleNow)
            {
                case "常规": fontStyle=FontStyle.Regular; break;
                case "粗体": fontStyle=FontStyle.Bold; break;
                case "倾斜": fontStyle=FontStyle.Italic; break;
                case "粗体 倾斜": fontStyle=(FontStyle.Bold|FontStyle.Italic); break;
            }
            switch(Passer.fontSizeNow)
            {
                case "初号": temp=42;break;
                case "小初": temp=36;break;
                case "一号": temp=26;break;
                case "小一": temp=24;break;
                case "二号": temp=22;break;
                case "小二": temp=18;break;
                case "三号": temp=16;break;
                case "小三": temp=15;break;
                case "四号": temp=14;break;
                case "小四": temp=12;break;
                case "五号": temp=10.5F;break;
                case "小五": temp=9;break;
                case "六号": temp=7.5F;break;
                case "小六": temp=6.5F;break;
                case "七号": temp=5.5F;break;
                case "八号": temp=5;break;
            }
            mainTextBox.Font = new Font(Passer.fontNow, temp, fontStyle);
        }

        private void 打印ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new PrintForm().Show();
        }

        private void 页面设置UToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new PageConfigForm().Show();
        }

        private void 转到GToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new GoForm().Show();
        }

        private void 查找FToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FindForm().Show();
        }

        private void 查找下一个NToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FindForm().Show();
        }

        private void 替换RToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ReplaceForm().Show();
        }
    }
    public static class Passer
    {
        public static String fontNow;
        public static String fontStyleNow;
        public static String fontSizeNow;
    }
}