using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace ConApp
{
    public partial class Program
    {
        #region 01:获取电脑已安装软件

        [DllImport("msi.dll", SetLastError = true)]
        public static extern int MsiEnumProducts(int iProductIndex, StringBuilder lpProductBuf);

        [DllImport("msi.dll", SetLastError = true)]
        public static extern int MsiGetProductInfo(string szProduct, string szProperty, StringBuilder lpValueBuf, ref int pcchValueBuf);

        public static void GetCurrentInstall()
        {
            StringBuilder result = new StringBuilder();
            for (int index = 0; ; index++)
            {
                StringBuilder productCode = new StringBuilder(39);
                if (MsiEnumProducts(index, productCode) != 0)
                {
                    break;
                }

                foreach (string property in new string[] { "ProductName", "Publisher", "VersionString", })
                {
                    int charCount = 512;
                    StringBuilder value = new StringBuilder(charCount);

                    if (MsiGetProductInfo(productCode.ToString(), property, value, ref charCount) == 0)
                    {
                        value.Length = charCount;
                        result.AppendLine(value.ToString());
                    }
                }
                result.AppendLine();
            }
            Console.WriteLine(result.ToString());
        }

        #endregion 01:获取电脑已安装软件

        #region 02:设置鼠标位置

        //BOOL WINAPI SetCursorPos(
        //  _In_ int X,
        //  _In_ int Y
        //);

        [DllImport("User32.dll")]
        public static extern bool SetCursorPos(int x, int y);

        public static void SetCursorPosDemo()
        {
            int x = 0;
            int y = 0;
            int time = 0;
            while (true)
            {
                SetCursorPos(x, y);
                Thread.Sleep(100);
                x += 10;
                y += 10;
                time++;
                if (time == 100)
                {
                    break;
                }
            }
        }

        #endregion 02:设置鼠标位置

        #region 03:获取鼠标位置

        public struct Point
        {
            public int x;
            public int y;
        }

        //BOOL WINAPI GetCursorPos(
        //  _Out_ LPPOINT lpPoint
        //);

        [DllImport("User32.dll")]
        public static extern bool GetCursorPos(out Point p);

        public static void GetPostition()
        {
            Point p;
            GetCursorPos(out p);
            Console.WriteLine(p.x + " " + p.y);
        }

        #endregion 03:获取鼠标位置

        #region 04:SetClipboardData

        //HANDLE WINAPI SetClipboardData(
        //_In_ UINT   uFormat,
        //_In_opt_ HANDLE hMem
        //);

        #endregion 04:SetClipboardData

        #region 05:ShowCursor

        [DllImport("User32.dll")]
        public static extern int ShowCursor(bool flag);

        //int WINAPI ShowCursor(
        //_In_ BOOL bShow
        //);

        public static void TestShowCursor()
        {
            int i = 1;
            while (true)
            {
                if (i % 2 == 0)
                {
                    ShowCursor(false);
                }
                else
                {
                    ShowCursor(true);
                }
                i++;
            }
        }

        #endregion 05:ShowCursor
    }
}