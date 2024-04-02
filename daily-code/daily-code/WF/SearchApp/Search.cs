using System;
using System.Windows.Forms;
using System.Text;
using System.Collections;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;
using System.Threading;

namespace SearchApp
{
    /// <summary>
    /// 搜索的相关代码
    /// </summary>
    public class Search
    {

        /// <summary>
        /// 搜索函数
        /// </summary>
        /// <param name="urlText">URL源文件</param>
        /// <param name="zzbds">正则表达式</param>
        /// <returns>结果集</returns>
        public ArrayList FindString(string urlText, string zzbds)
        {
            ArrayList searchResult = new ArrayList();
            Regex reg = new Regex(@"([\s<>'"":;；：&#%\*\\/])(" + zzbds + @")([\s<>'"":;&#\*%\\/])", RegexOptions.IgnoreCase);
            Match match = reg.Match(urlText);
            while (match.Success)
            {
                string strResult = match.Result("$2").ToString();
                searchResult.Add(strResult);
                match = match.NextMatch();
                Thread.Sleep(10);
            }
            return searchResult;
        }

        /// <summary>
        /// 深层搜索
        /// </summary>
        /// <returns>深层地址集合</returns>
        public ArrayList IsInNextSearch(string urlText,string keyWord)
        {
            ArrayList searchResult = new ArrayList();
            Regex reg = new Regex(@"(<a\s*href=.*)(" + keyWord + @"[^'""\s]*)('?""?.*>)", RegexOptions.IgnoreCase);
            Match match = reg.Match(urlText);
            while (match.Success)
            {
                string strResult = match.Result("$2").ToString();
                if (searchResult.Count > 0)
                {
                    bool flag = true; ;
                    for (int i = 0; i < searchResult.Count; i++)
                    {
                        if (strResult.Equals(searchResult[i]))
                        {
                            flag = false;
                            break;
                        }
                    }
                    if (flag)
                    {
                        searchResult.Add(strResult);
                    }
                }
                else
                {
                    searchResult.Add(strResult);
                }
                match = match.NextMatch();
                Thread.Sleep(10);
            }
            return searchResult;

        }

        /// <summary>
        /// 截取字符串
        /// </summary>
        /// <param name="url">网页URL</param>
        /// <returns>截取的根目录</returns>
        public string SubUrlHead(string url)
        {
            int last = url.LastIndexOf(@"/");
            string urlStrReturn = url.Substring(0, last + 1);
            return urlStrReturn;
        }

        /// <summary>
        /// 截取搜索关键字
        /// </summary>
        /// <param name="url">网页URL</param>
        /// <returns>用于搜索的关键字</returns>
        public string SubUrlRegexStr(string url)
        {
            int last = url.LastIndexOf(@"/");
            string urlEnd = url.Substring(last, url.Length-1-last);
            int mid = urlEnd.IndexOf(@".");
            string urlStrReturn = urlEnd.Substring(1, mid);
            return urlStrReturn;
        }

        /// <summary>
        /// 对url进行编码转换
        /// </summary>
        /// <param name="urlstring">url</param>
        /// <returns>转换后的url</returns>
        public string GetUrlEncode(string urlstring)
        {
            int chfrom = Convert.ToInt32("4e00", 16);    //范围（0x4e00～0x9fff）转换成int（chfrom～chend）
            int chend = Convert.ToInt32("9fff", 16);

            string urlEncode = "";
            for (int i = 0; i < urlstring.Length; i++)
            {
                if (urlstring[i] >= chfrom && urlstring[i] <= chend)
                {
                    urlEncode += HttpUtility.UrlEncode(urlstring[i].ToString(), Encoding.Default);
                }
                else
                {
                    urlEncode += urlstring[i];
                }
            }
            return urlEncode;
        }

        /// <summary>
        /// 写入结果集
        /// </summary>
        /// <param name="al">结果集</param>
        /// <param name="lv">要写入的ListView</param>
        public void WriteResult(ArrayList al, ListView lv, string url)
        {
            MyRegCode rc = new MyRegCode();
            if (al.Count > 0)
            {
                for (int i = 0; i < al.Count; i++)
                {
                    ListViewItem item = new ListViewItem();
                    string temp = al[i].ToString();
                    item.SubItems[0].Text = temp;
                    item.SubItems.Add(url);
                    lv.Items.Add(item);
                    Thread.Sleep(10);
                }
            }
        }


        /// <summary>
        /// 自动将结果集写入TXT文件
        /// </summary>
        public void WriteResultToTxt(ListView lv, string findType)
        {
            string path = @"\" + findType + DateTime.Now.Date.ToShortDateString() + ".txt";

            string filePath = System.Environment.CurrentDirectory + path;
            FileStream fileStream = new FileStream(filePath, FileMode.Append, FileAccess.Write);
            StreamWriter streamWriter = new StreamWriter(fileStream);
            for (int i = 0; i < lv.Items.Count; i++)
            {
                streamWriter.WriteLine(lv.Items[i].SubItems[0].Text);
            }
            streamWriter.Flush();
            streamWriter.Close();
            fileStream.Close();

        }

        /// <summary>
        /// 导入TXT文件url列表
        /// </summary>
        /// <param name="lv">显示的listview</param>
        /// <param name="path">导入文件的路径</param>
        public void ReadResultFromTxt(ListView lv, string path)
        {
            FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
            StreamReader streamReader = new StreamReader(fileStream);
            while (!streamReader.EndOfStream)
            {
                ListViewItem item = new ListViewItem();
                item.SubItems[0].Text = streamReader.ReadLine();
                lv.Items.Add(item);
            }
            streamReader.Close();
            fileStream.Close();
        }


        /// <summary>
        /// 得到网页源代码
        /// </summary>
        /// <returns>网页源文件</returns>
        public string GetUrlText(string url, string cook)
        {
            string urlText = "";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";

            //自己创建的Cookie
            request.Headers.Add("Cookie", cook);
            string postData ="id=2005&action=search&name=";
            byte[] byte1 = Encoding.ASCII.GetBytes(postData);
            request.ContentLength = byte1.Length;

            Stream postStream = request.GetRequestStream();
            postStream.Write(byte1, 0, byte1.Length);
            postStream.Close();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream resStream = response.GetResponseStream();
            StreamReader sr = new StreamReader(resStream, System.Text.Encoding.Default);
            urlText = sr.ReadToEnd();
            resStream.Close();
            sr.Close();
            return urlText;
            
        }

        /// <summary>
        /// 不带cookie得到url源码
        /// </summary>
        /// <param name="url">url</param>
        /// <returns>网页源文件</returns>
        public string GetUrlText(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream resStream = response.GetResponseStream();
            StreamReader sr = new StreamReader(resStream, System.Text.Encoding.Default);
            string urlText = sr.ReadToEnd();
            resStream.Close();
            sr.Close();
            return urlText;
        }

        /// <summary>
        /// 得到Cookie
        /// </summary>
        /// <param name="wb">浏览器</param>
        /// <returns>Cookie</returns>
        public string GetCookie(WebBrowser wb)
        { 
            string cookieStr = null;
           
            if (wb.Document != null && wb.Document.Cookie!=null)
            {  
                cookieStr = wb.Document.Cookie;
            }
            return cookieStr;
        }

    }
}
