using IWshRuntimeLibrary;
using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Shell;

namespace WinFormDemo
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

            WshShell shell = new WshShell();
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(path);

            //设置快捷方式的目标所在的位置
            shortcut.TargetPath = Assembly.GetExecutingAssembly().Location;

            //应用程序的工作目录
            //当用户没有指定一个具体的目录时，快捷方式的目标应用程序将使用该属性所指定的目录来装载或保存文件。
            shortcut.WorkingDirectory = Environment.CurrentDirectory;

            //目标应用程序窗口类型(1.Normal window普通窗口,3.Maximized最大化窗口,7.Minimized最小化)
            shortcut.WindowStyle = 1;

            shortcut.Description = "鼠标停留在上面时显示的说明文字";

            //可以自定义快捷方式图标.(如果不设置,则将默认为当前程序的图标.)
            shortcut.IconLocation = shortcut.TargetPath + ",-32512";

            //设置应用程序的启动参数(如果应用程序支持的话)
            //shortcut.Arguments = "/myword /d4s";

            shortcut.Save();
        }
    }
}