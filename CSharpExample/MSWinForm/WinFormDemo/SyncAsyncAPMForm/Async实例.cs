using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormDemo.SyncAsyncAPMForm
{
    public partial class Async实例 : Form
    {
        public Async实例()
        {
            InitializeComponent();
        }

        private async void btnClick_Click(object sender, EventArgs e)
        {
            long length = await AccessWebAsync();

            OtherWork();

            this.richTextBox1.Text += String.Format("\n 回复的字节长度为:  {0}.\r\n", length);
            txbMainThreadID.Text = Thread.CurrentThread.ManagedThreadId.ToString();
        }

        // 使用C# 5.0中提供的async 和await关键字来定义异步方法
        // 从代码中可以看出C#5.0 中定义异步方法就像定义同步方法一样简单。
        // 使用async 和await定义异步方法不会创建新线程,
        // 它运行在现有线程上执行多个任务.
        // 此时不知道大家有没有一个疑问的？在现有线程上(即UI线程上)运行一个耗时的操作时，
        // 为什么不会堵塞UI线程的呢？
        // 这个问题的答案就是 当编译器看到await关键字时，线程会
        private async Task<long> AccessWebAsync()
        {
            MemoryStream content = new MemoryStream();

            HttpWebRequest webRequest = WebRequest.Create("http://msdn.microsoft.com/zh-cn/") as HttpWebRequest;
            if (webRequest != null)
            {
                using (WebResponse response = await webRequest.GetResponseAsync())
                {
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        await responseStream.CopyToAsync(content);
                    }
                }
            }

            txbAsynMethodID.Text = Thread.CurrentThread.ManagedThreadId.ToString();
            return content.Length;
        }

        private void OtherWork()
        {
            richTextBox1.Text += "\r\n等待服务器回复中.................\n";
        }

        private async void btnAsync_Click(object sender, EventArgs e)
        {
            Task<int> getLengthTask = AccessTheWebAsync();
            int contentLength2 = await getLengthTask;

            int contentLength = await AccessTheWebAsync();

            richTextBox1.Text += $"\r\nLength of the downloaded string: {contentLength}.\r\n";
        }

        private async Task<int> AccessTheWebAsync()
        {
            HttpClient client = new HttpClient();

            Task<string> getStringTask = client.GetStringAsync("http://msdn.microsoft.com");

            OtherWork();

            string urlContents = await getStringTask;

            return urlContents.Length;
        }
    }
}