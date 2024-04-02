using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WfApp.Infrastructure
{
    public class ShellGetFileInfo
    {
        public const uint SHGFI_ICON = 0x100;         // Gets the icon
        public const uint SHGFI_DISPLAYNAME = 0x200;  // Gets the Display name
        public const uint SHGFI_TYPENAME = 0x400;     // Gets the type name
        public const uint SHGFI_LARGEICON = 0x0;      // Large icon
        public const uint SHGFI_SMALLICON = 0x1;      // Small icon

        [DllImport("shell32.dll")]
        public static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, uint cbSizeFileInfo, uint uFlags);

        public static SHFILEINFO GetFileInfo(string path)
        {
            SHFILEINFO info = new SHFILEINFO();
            IntPtr icon;

            icon = SHGetFileInfo(path, 0, ref info, (uint)Marshal.SizeOf(info), SHGFI_ICON | SHGFI_TYPENAME | SHGFI_SMALLICON);

            return info;
        }
    }
}
