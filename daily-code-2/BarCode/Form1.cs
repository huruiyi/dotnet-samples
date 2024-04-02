using BarCode.Utils;

using System;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;

namespace BarCode
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        public void btnPrint_Click(object sender, EventArgs e)
        {
            this.printDocument1.DefaultPageSettings.PaperSize = new PaperSize("Custom", 113, 63);
            this.printDocument1.DefaultPageSettings.Margins.Left = 20;
            this.printDocument1.DefaultPageSettings.Margins.Top = 40;
            this.printDialog1.Document = this.printDocument1;
            if (this.printDialog1.ShowDialog() == DialogResult.OK)
            {
                this.printDocument1.Print();
            }
        }


        public void InitPainter(Graphics eGraphics)
        {
            Pen pen = new Pen(Color.Black, 2f);
            Font font1 = new Font("宋体", 20f, FontStyle.Bold, GraphicsUnit.Point, (byte)134);
            Font font2 = new Font("宋体", 10f, FontStyle.Bold, GraphicsUnit.Point, (byte)134);
            Font font3 = new Font("宋体", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte)134);
            Font font4 = new Font("宋体", 10f, FontStyle.Regular, GraphicsUnit.Point, (byte)134);
            Font font5 = new Font("黑体", 20f, FontStyle.Bold, GraphicsUnit.Point, (byte)134);
            Font font6 = new Font("黑体", 16f, FontStyle.Bold, GraphicsUnit.Point, (byte)134);
            Font font7 = new Font("黑体", 10f, FontStyle.Bold, GraphicsUnit.Point, (byte)134);
            Font font8 = new Font("黑体", 8f, FontStyle.Regular, GraphicsUnit.Point, (byte)134);
            Font font9 = new Font("黑体", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte)134);
            Font font10 = new Font("黑体", 22f, FontStyle.Bold, GraphicsUnit.Point, (byte)134);


            if (File.Exists(Directory.GetCurrentDirectory() + "\\ACN_log.gif"))
            {
                Bitmap bitmap = new Bitmap("ACN_log.gif");
                eGraphics.DrawImage((Image)bitmap, 38, 5, 38, 38);
            }
            eGraphics.DrawString("中 间 制 品", font6, Brushes.Black, 146f, 11f);
            eGraphics.DrawString("代号", font9, Brushes.Black, 8f, 38f);
            eGraphics.DrawString("品名规格", font9, Brushes.Black, 133f, 38f);
            eGraphics.DrawString("容器号", font9, Brushes.Black, 8f, 58f);
            eGraphics.DrawString("总重量", font9, Brushes.Black, 133f, 58f);

            eGraphics.DrawString("生产批号", font9, Brushes.Black, 8f, 78f);
            eGraphics.DrawString("容器重", font9, Brushes.Black, 133f, 78f);

            eGraphics.DrawString("干燥剂", font9, Brushes.Black, 8f, 98f);
            eGraphics.DrawString("净重", font9, Brushes.Black, 133f, 98f);

            eGraphics.DrawString("称量人", font9, Brushes.Black, 8f, 118f);
            eGraphics.DrawString("数量", font9, Brushes.Black, 133f, 118f);
            eGraphics.DrawString("确认人", font9, Brushes.Black, 8f, 138f);
            eGraphics.DrawString("生产日期", font9, Brushes.Black, 133f, 138f);
            eGraphics.DrawString("备注", font9, Brushes.Black, 8f, 158f);
            HHTCode128Rendering.Height = 35;
            string str8 = "&870320210872$M-3611000001090000";
            int barcodeImagePrintWidth12 = HHTCode128Rendering.GetBarcodeImagePrintWidth(str8, 1, true);
            Image image12 = HHTCode128Rendering.MakeBarcodeImage(str8, 1, true);
            eGraphics.DrawImage(image12, (390 - barcodeImagePrintWidth12) / 2 + 10, 180, barcodeImagePrintWidth12, HHTCode128Rendering.Height);
            eGraphics.DrawString(str8, font9, Brushes.Black, (float)((390 - str8.Length * 6) / 2 + 20), 215f);
            eGraphics.DrawString("XYZ条码", font9, Brushes.Black, 165f, 225f);
            Point[] points14 = new Point[5]
            {
            new Point(6, 10),
            new Point(405, 10),
            new Point(405, 240),
            new Point(6, 240),
            new Point(6, 10)
            };
            eGraphics.DrawLines(pen, points14);
            eGraphics.DrawLine(pen, new Point(6, 35), new Point(405, 35));
            eGraphics.DrawLine(pen, new Point(6, 55), new Point(405, 55));
            eGraphics.DrawLine(pen, new Point(6, 75), new Point(405, 75));
            eGraphics.DrawLine(pen, new Point(6, 95), new Point(405, 95));
            eGraphics.DrawLine(pen, new Point(6, 115), new Point(405, 115));
            eGraphics.DrawLine(pen, new Point(6, 135), new Point(405, 135));
            eGraphics.DrawLine(pen, new Point(6, 155), new Point(405, 155));
            eGraphics.DrawLine(pen, new Point(6, 175), new Point(405, 175));
            eGraphics.DrawLine(pen, new Point(64, 35), new Point(64, 55));
            eGraphics.DrawLine(pen, new Point(132, 35), new Point(132, 55));
            eGraphics.DrawLine(pen, new Point(195, 35), new Point(195, 55));
            eGraphics.DrawLine(pen, new Point(64, 55), new Point(64, 75));
            eGraphics.DrawLine(pen, new Point(132, 55), new Point(132, 75));
            eGraphics.DrawLine(pen, new Point(195, 55), new Point(195, 75));
            eGraphics.DrawLine(pen, new Point(64, 75), new Point(64, 95));
            eGraphics.DrawLine(pen, new Point(132, 75), new Point(132, 95));
            eGraphics.DrawLine(pen, new Point(195, 75), new Point(195, 95));
            eGraphics.DrawLine(pen, new Point(64, 95), new Point(64, 115));
            eGraphics.DrawLine(pen, new Point(132, 95), new Point(132, 115));
            eGraphics.DrawLine(pen, new Point(195, 95), new Point(195, 115));
            eGraphics.DrawLine(pen, new Point(64, 115), new Point(64, 135));
            eGraphics.DrawLine(pen, new Point(132, 115), new Point(132, 135));
            eGraphics.DrawLine(pen, new Point(195, 115), new Point(195, 135));
            eGraphics.DrawLine(pen, new Point(64, 135), new Point(64, 155));
            eGraphics.DrawLine(pen, new Point(132, 135), new Point(132, 155));
            eGraphics.DrawLine(pen, new Point(195, 135), new Point(195, 155));
            eGraphics.DrawLine(pen, new Point(64, 155), new Point(64, 175));
        }

        public void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            InitPainter(e.Graphics);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            InitPainter(e.Graphics);
        }
    }
}