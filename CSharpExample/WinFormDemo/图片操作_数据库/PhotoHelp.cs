using System.IO;

namespace 图片操作_数据库
{
    internal class PhotoHelp
    {
        public byte[] AddPhoto(string pathName)
        {
            FileStream stream = new FileStream(pathName, FileMode.Open, FileAccess.Read);
            byte[] buffbyte = new byte[stream.Length];
            stream.Read(buffbyte, 0, (int)stream.Length);
            stream.Close();
            return buffbyte;
        }
    }
}