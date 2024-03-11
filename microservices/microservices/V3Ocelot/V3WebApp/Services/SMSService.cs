using RestTemplateCore;
using RuPeng.HystrixCore;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using V3WebApp.Models;

namespace V3WebApp.Services
{
    public class SMSService
    {
        [HystrixCommand(nameof(Send_LX))]
        public virtual async Task Send_MI(string phoneNum, string msg)
        {
            SendSMSReq req = new SendSMSReq
            {
                phoneNum = phoneNum,
                msg = msg
            };
            using (var http = new HttpClient())
            {
                RestTemplate rest = new RestTemplate(http);
                var resp = await rest.PostAsync("http://MsgService/api/SMS/Send_MI", req);
                if (resp.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    throw new Exception("发送错误，状态码" + resp.StatusCode);
                }
            }
        }

        [HystrixCommand(nameof(Send_HW))]
        public virtual async Task Send_LX(string phoneNum, string msg)
        {
            SendSMSReq req = new SendSMSReq
            {
                phoneNum = phoneNum,
                msg = msg
            };
            using (var http = new HttpClient())
            {
                RestTemplate rest = new RestTemplate(http);
                var resp = await rest.PostAsync("http://MsgService/api/SMS/Send_LX", req);
                if (resp.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    throw new Exception("发送错误，状态码" + resp.StatusCode);
                }
            }
        }

        public virtual async Task Send_HW(string phoneNum, string msg)
        {
            SendSMSReq req = new SendSMSReq
            {
                phoneNum = phoneNum,
                msg = msg
            };
            using (var http = new HttpClient())
            {
                RestTemplate rest = new RestTemplate(http);
                var resp = await rest.PostAsync("http://MsgService/api/SMS/Send_HW", req);
                if (resp.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    throw new Exception("发送错误，状态码" + resp.StatusCode);
                }
            }
        }
    }
}