using System;
using System.IO;
using System.Net;
using System.Text;

namespace Net.Tools.Http
{
    public class HttpHelper
    {
        public static string GetRequest(string requestUrl, string requestData, string contentType, string codingType, int timeout, out string error)
        {
            string result = "";
            error = "";
            long elapsed = 0;
            string responseData = string.Empty;
            //Post请求地址
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestUrl);
                //相应请求的参数
                byte[] data = Encoding.GetEncoding(codingType).GetBytes(requestData);
                request.Method = "Post";
                request.ContentType = contentType;
                request.ContentLength = data.Length;
                request.Timeout = timeout;
                request.ServicePoint.Expect100Continue = false;
                //请求流
                Stream requestStream = request.GetRequestStream();
                requestStream.Write(data, 0, data.Length);
                requestStream.Close();
                //响应流
                HttpWebResponse m_Response = (HttpWebResponse)request.GetResponse();
                Stream responseStream = m_Response.GetResponseStream();
                StreamReader streamReader = new StreamReader(responseStream, Encoding.GetEncoding(codingType));
                //获取返回的信息
                result = streamReader.ReadToEnd();
                streamReader.Close();
                responseStream.Close();
            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.Timeout)
                {
                    error = string.Format("请求超时[{0}],请求地址：{1}", elapsed, requestUrl);
                }
                else
                {
                    error = string.Format("{0},请求地址：{1}", ex.Message, requestUrl);
                }
                result = error;
                responseData = ex.ToString();
            }
            catch (Exception ex)
            {
                error = string.Format("请求接口异常,请求地址：{0}", requestUrl);
                result = error;
                responseData = ex.ToString();
            }
            if (string.IsNullOrWhiteSpace(responseData))
            {
                responseData = result;
            }

            return responseData;
        }
    }
}