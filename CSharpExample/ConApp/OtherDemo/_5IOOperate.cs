using System;
using System.IO;
using System.Text;
using System.Threading;

namespace ConApp.OtherDemo
{
    internal class _5IOOperate
    {
        private static void AddText(FileStream fs, string value)
        {
            byte[] info = new UTF8Encoding(true).GetBytes(value);
            fs.Write(info, 0, info.Length);
        }

        private static void EndReadCallback(IAsyncResult asyncResult)
        {
        }

        private static void EndWriteCallback(IAsyncResult asyncResult)
        {
        }

        private static void Main5(string[] args)
        {
            /*
               const string path = @"D:\temp.txt";

            if (File.Exists(path))
            {
                File.Delete(path);
            }

            using (FileStream fs = File.Create(path))
            {
                AddText(fs, "This is some text");
                AddText(fs, "This is some more text,");
                AddText(fs, "\r\nand this is on a new line");
                AddText(fs, "\r\n\r\nThe following is a subset of characters:\r\n");

                for (int i = 1; i < 120; i++)
                {
                    AddText(fs, Convert.ToChar(i).ToString());
                }
            }

            using (FileStream fs = File.OpenRead(path))
            {
                byte[] b = new byte[1024];
                UTF8Encoding temp = new UTF8Encoding(true);
                while (fs.Read(b, 0, b.Length) > 0)
                {
                    Console.WriteLine(temp.GetString(b));
                }
            }

             */

            #region CanRead and CanWrite

            //const string path = @"D:\temp.txt";
            //FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read);
            //if (fs.CanRead && fs.CanWrite)
            //{
            //    Console.WriteLine("MyFile.txt can be both written to and read from.");
            //}
            //else if (fs.CanRead)
            //{
            //    Console.WriteLine("MyFile.txt is not writable.");
            //}

            #endregion CanRead and CanWrite

            #region CanSeek 获取一个值，该值指示当前流是否支持查找。

            //const string path = @"D:\temp.txt";

            //// Delete the file if it exists.
            //if (File.Exists(path))
            //{
            //    File.Delete(path);
            //}

            ////Create the file.
            //using (FileStream fs = File.Create(path))
            //{
            //    Console.WriteLine(
            //       fs.CanSeek
            //           ? "The stream connected to {0} is seekable."
            //           : "The stream connected to {0} is not seekable.", path);
            //}

            #endregion CanSeek 获取一个值，该值指示当前流是否支持查找。

            #region MyRegion

            // Create a synchronization object that gets
            // signaled when verification is complete.
            ManualResetEvent manualEvent = new ManualResetEvent(false);

            // Create random data to write to the file.
            byte[] writeArray = new byte[100000];
            new Random().NextBytes(writeArray);

            FileStream fStream =
                new FileStream("Test#@@#.dat", FileMode.Create,
                FileAccess.ReadWrite, FileShare.None, 4096, true);

            Console.WriteLine("fStream was {0}opened asynchronously.",
                fStream.IsAsync ? "" : "not ");

            // Asynchronously write to the file.     new  State(fStream, writeArray, manualEvent)
            IAsyncResult asyncResult = fStream.BeginWrite(writeArray, 0, writeArray.Length, new AsyncCallback(EndWriteCallback), null);

            // Concurrently do other work and then wait
            // for the data to be written and verified.
            manualEvent.WaitOne(5000, false);

            #endregion MyRegion

            #region 下面的示例说明如何逐字节地向文件中写入数据，然后验证数据是否被正确写入。

            //const string fileName = @"D:\temp.txt";

            //// Create random data to write to the file.
            //byte[] dataArray = new byte[100000];
            //new Random().NextBytes(dataArray);

            //using (FileStream fileStream = new FileStream(fileName, FileMode.Create))
            //{
            //    for (int i = 0; i < dataArray.Length; i++)
            //    {
            //        fileStream.WriteByte(dataArray[i]);
            //    }

            //    fileStream.Seek(0, SeekOrigin.Begin);

            //    for (int i = 0; i < fileStream.Length; i++)
            //    {
            //        if (dataArray[i] != fileStream.ReadByte())
            //        {
            //            Console.WriteLine("Error writing data.");
            //            return;
            //        }
            //    }
            //    Console.WriteLine("The data was written to {0} and verified.", fileStream.Name);
            //}

            #endregion 下面的示例说明如何逐字节地向文件中写入数据，然后验证数据是否被正确写入。

            #region 下面的示例通过使用多个 SeekOrigin 值与 Seek 方法从文件向后读取文本。

            //const string fileName = @"D:\temp.txt";
            //FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            //long offset;

            //// read the file backwards using SeekOrigin.Begin...
            //for (offset = fs.Length - 1; offset >= 0; offset--)
            //{
            //    fs.Seek(offset, SeekOrigin.Begin);
            //    Console.Write(Convert.ToChar(fs.ReadByte()));
            //}
            //Console.WriteLine();

            //// read the file backwards using SeekOrigin.End...
            //for (offset = 1; offset <= fs.Length; offset++)
            //{
            //    fs.Seek(-offset, SeekOrigin.End);
            //    Console.Write(Convert.ToChar(fs.ReadByte()));
            //}
            //Console.WriteLine();

            //// read the file backwards using SeekOrigin.Current...
            //fs.Seek(0, SeekOrigin.End);
            //for (offset = 0; offset < fs.Length; offset++)
            //{
            //    fs.Seek(-1, SeekOrigin.Current);
            //    Console.Write(Convert.ToChar(fs.ReadByte()));
            //    fs.Seek(-1, SeekOrigin.Current);
            //}
            //Console.WriteLine();
            //fs.Close();

            #endregion 下面的示例通过使用多个 SeekOrigin 值与 Seek 方法从文件向后读取文本。

            #region 下面的示例从 FileStream 读取内容，并将其写入到另一个 FileStream。

            //// Specify a file to read from and to create.
            //string pathSource = @"c:\tests\source.txt";
            //string pathNew = @"c:\tests\newfile.txt";

            //try
            //{
            //    using (FileStream fsSource = new FileStream(pathSource,
            //        FileMode.Open, FileAccess.Read))
            //    {
            //        // Read the source file into a byte array.
            //        byte[] bytes = new byte[fsSource.Length];
            //        int numBytesToRead = (int)fsSource.Length;
            //        int numBytesRead = 0;
            //        while (numBytesToRead > 0)
            //        {
            //            // Read may return anything from 0 to numBytesToRead.
            //            int n = fsSource.Read(bytes, numBytesRead, numBytesToRead);

            //            // Break when the end of the file is reached.
            //            if (n == 0)
            //                break;

            //            numBytesRead += n;
            //            numBytesToRead -= n;
            //        }
            //        numBytesToRead = bytes.Length;

            //        // Write the byte array to the other FileStream.
            //        using (FileStream fsNew = new FileStream(pathNew,
            //            FileMode.Create, FileAccess.Write))
            //        {
            //            fsNew.Write(bytes, 0, numBytesToRead);
            //        }
            //    }
            //}
            //catch (FileNotFoundException ioEx)
            //{
            //    Console.WriteLine(ioEx.Message);
            //}

            #endregion 下面的示例从 FileStream 读取内容，并将其写入到另一个 FileStream。

            Console.ReadKey();
        }
    }
}