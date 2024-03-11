/* Windows Script Host Object Model 
using IWshRuntimeLibrary;*/
using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Shell;

namespace HuUtils
{
    public partial class ShellDemo : Form
    {
        public ShellDemo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string libraryName = "我的库";
            string doc2 = @"D:\Temp\doc2";
            string doc1 = @"D:\Temp\doc1";
            ShellLibrary library = new ShellLibrary(libraryName, true)
            {
                doc2,
                doc1
            };

            string defaultSaveFolderPath = library.DefaultSaveFolder; // 默认保存到的文件夹，是第一个添加进库的目录
            library.DefaultSaveFolder = doc1;// 更改默认保存到的文件夹

            library.IconResourceId = new IconReference(Assembly.GetExecutingAssembly().Location, -32512);

            ShellLibrary lib = ShellLibrary.Load(libraryName, true); // 第二个参数isReadOnly表示是否允许改动库
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(Environment.GetEnvironmentVariable(@"USERPROFILE"), "Links", "我的快捷方式.lnk");
            MessageBox.Show(path);
        }
    }
}