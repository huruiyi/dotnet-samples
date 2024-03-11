using System.Net;

namespace WinApp.Utils
{
    public class HttpHelper
    {
        /// <summary>
        /// 下载方法(带进度条)
        /// </summary>
        /// <param name="url">服务器URL地址</param>
        /// <param name="fileName">存放到本地的路径</param>
        /// <param name="progressBar">进度条</param>
        public static void DownFile(string url, string fileName, ProgressBar progressBar)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                long totalBytes = response.ContentLength;
                progressBar.Maximum = (int)totalBytes;
                Stream st = response.GetResponseStream();
                Stream so = new FileStream(fileName, FileMode.Create);
                long totalDownloadedByte = 0;
                byte[] by = new byte[1024];
                int readSize = st.Read(by, 0, (int)by.Length);
                while (readSize > 0)
                {
                    totalDownloadedByte = readSize + totalDownloadedByte;
                    Application.DoEvents();
                    so.Write(by, 0, readSize);
                    progressBar.Value = (int)totalDownloadedByte;
                    readSize = st.Read(by, 0, (int)by.Length);
                }

                so.Close();
                st.Close();
                MessageBox.Show("下载完毕!", "下载提示：", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }
        }

        public static void Down(string url, string fileName, ProgressBar progressBar)
        {
            //打开上次下载的文件或新建文件
            long lStartPos = 0;
            FileStream fs;
            if (File.Exists(fileName))
            {
                //打开原有文件
                fs = File.OpenWrite(fileName);
                lStartPos = fs.Length;
                fs.Seek(lStartPos, System.IO.SeekOrigin.Current); //移动文件流中的当前指针
            }
            else
            {
                //新建文件
                fs = new FileStream(fileName, FileMode.Create);
                lStartPos = 0;
            }

            try
            {
                //请求
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
                if (lStartPos > 0)
                    request.AddRange((int)lStartPos); //设置Range值
                //响应
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                long totalBytes = response.ContentLength;
                //进度条最大值 = 剩余字节 + 已下载字节
                progressBar.Maximum = (int)totalBytes + (int)lStartPos;
                //进度条当前值 = 已下载字节
                progressBar.Value = (int)lStartPos;
                //获取服务器 文件流
                Stream st = response.GetResponseStream();
                //设置本地文件
                Stream so = fs;
                //进度条累加变量 = 已下载字节
                long totalDownloadedByte = lStartPos;
                byte[] by = new byte[1024];
                int osize = st.Read(by, 0, (int)by.Length);
                //循环读取文件
                while (osize > 0)
                {
                    //累加
                    totalDownloadedByte = osize + totalDownloadedByte;
                    Application.DoEvents();
                    //写入文件
                    so.Write(by, 0, osize);
                    //设置进度条
                    progressBar.Value = (int)totalDownloadedByte;
                    //读取服务器文件流
                    osize = st.Read(by, 0, (int)by.Length);
                }
                so.Close();
                st.Close();
                fs.Close();
                MessageBox.Show("下载完毕!", "下载提示：", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }
            catch (WebException webex)
            {
                fs.Close();
                switch (webex.Status)
                {
                    case WebExceptionStatus.ProtocolError:
                        progressBar.Maximum = 100;
                        progressBar.Value = 100;
                        break;
                }
            }
            catch (Exception ex)
            {
                fs.Close();
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }
        }
    }
}