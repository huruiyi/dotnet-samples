using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Http;
using CsQuery;
using Newtonsoft.Json;
using WebApp.Models.Music;
using WebApp.Utility;

namespace WebApp.Controllers
{
    /// <summary>
    /// 百度音乐API
    /// </summary>
    [AccessKey]
    [RoutePrefix("api/music")]
    public class MusicController : ApiController
    {
        /// <summary>
        /// 搜索音乐（百度提供API）
        /// </summary>
        /// <remarks>搜索音乐（百度提供API）</remarks>
        /// <param name="param">分页参数</param>
        /// <returns></returns>

        [HttpGet, Route("search")]
        public List<MusicSummary> Search([FromUri]PageParams param)
        {
            List<MusicSummary> list = new List<MusicSummary>();
            string url = $"http://music.baidu.com/search/song?s=1&key={param.Keyword ?? ""}&jump=0&start={(param.Current - 1) * param.Size}&size={param.Size}&third_type=0";
            CQ csquery = Http.GetHttpValue(url);
            CQ items = csquery.Find("li.bb-dotimg");
            for (int i = 0; i < items.Length; i++)
            {
                CQ item = items.Eq(i);
                CQ csTitle = item.Find("span.song-title a");
                string title = csTitle.Attr("title");
                string ids = Regex.Match(csTitle.Attr("data-songdata") ?? "", "\\d+").Value;
                MusicSummary summary = new MusicSummary
                {
                    ArtistName = item.Find("span.author_list").Text().Trim(),
                    AlbumName = item.Find("span.album-title").Text().Trim(),
                    SongName = title,
                    SongId = Convert.ToInt32(ids)
                };
                list.Add(summary);
            }
            return list;
        }

        /// <summary>
        /// 获取音乐详细信息
        /// </summary>
        /// <remarks>根据 /music/search 搜索出的音乐id 获取音乐详细信息</remarks>
        /// <param name="ids">音乐Id 使用逗号分隔</param>
        /// <returns></returns>
        [HttpGet, Route("details/{ids}")]
        public List<MusicDetails> Details(string ids)
        {
            string content = GetMusic(ids, "songinfo");
            List<MusicDetails> result = new List<MusicDetails>();
            Regex regex = new Regex(@"\[.*\]");
            Match match = regex.Match(content);
            if (match.Success)
                result = JsonConvert.DeserializeObject<List<MusicDetails>>(match.Value);
            return result;
        }

        /// <summary>
        /// 获取播放音乐的链接信息
        /// </summary>
        /// <remarks>根据 /music/search 搜索出的音乐id 获取音乐详细信息</remarks>
        /// <param name="ids">音乐Id 使用逗号分隔</param>
        /// <returns></returns>
        [HttpGet, Route("play/{ids}")]
        public List<MusicPlayInfo> MusicPlay(string ids)
        {
            string content = GetMusic(ids, "songlink");
            List<MusicPlayInfo> result = new List<MusicPlayInfo>();
            Regex regex = new Regex(@"\[.*\]");
            Match match = regex.Match(content);
            if (match.Success)
                result = JsonConvert.DeserializeObject<List<MusicPlayInfo>>(match.Value);
            return result;
        }

        private string GetMusic(string ids, string key)
        {
            Dictionary<string, string> post = new Dictionary<string, string>
            {
                {"songIds", ids}
            };
            return Http.PostHttpValue("http://play.baidu.com/data/music/" + key, post);
        }

        /// <summary>
        /// [upload] 上传文件
        /// </summary>
        /// <remarks>[upload] 上传文件</remarks>
        /// <returns></returns>
        [HttpPost, System.Web.Mvc.Route("upload")]
        public Object Upload()
        {
            var files = HttpContext.Current.Request.Files;
            return new { state = 0 };
        }
    }
}