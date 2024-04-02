using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Windows.Forms;

namespace HuUtils
{
    public partial class 系统字体 : Form
    {
        private FontFamily[] fonts;

        public 系统字体()
        {
            InitializeComponent();
        }

        private void BtnGetFonts_Click(object sender, EventArgs e)
        {
            String fontPath = Path.Combine(Directory.GetParent(Application.ExecutablePath).FullName, "系统支持的字体.txt");

            InstalledFontCollection fontCollection = new InstalledFontCollection();
            fonts = fontCollection.Families;
            lvFonts.DataSource = fonts;

            List<String> family = new List<string>();
            foreach (FontFamily item in fonts)
            {
                family.Add(item.Name);
            }
            if (!File.Exists(fontPath))
            {
                File.Create(fontPath);
            }
            File.WriteAllLines(fontPath, family.ToArray());
            System.Diagnostics.Process.Start("explorer.exe", fontPath);
        }

        private void 系统字体_Load(object sender, EventArgs e)
        {
        }
    }
}