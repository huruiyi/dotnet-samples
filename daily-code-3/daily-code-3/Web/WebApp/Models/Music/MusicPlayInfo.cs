using Newtonsoft.Json;

namespace WebApp.Models.Music
{
    /// <summary>
    /// 获取音乐链接信息
    /// </summary>
    public class MusicPlayInfo : MusicSummary
    {
        /// <summary>
        /// 歌词文件
        /// </summary>
        [JsonProperty("lrcLink")]
        public string LrcLink { get; set; }
        /// <summary>
        /// 播放时长
        /// </summary>
        [JsonProperty("time")]
        public int? Time { get; set; }
        /// <summary>
        /// 音乐链接
        /// </summary>

        [JsonProperty("songLink")]
        public string SongLink { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("showLink")]
        public string ShowLink { get; set; }
        /// <summary>
        /// 音乐格式
        /// </summary>
        [JsonProperty("format")]
        public string Format { get; set; }
        /// <summary>
        /// 文件大小
        /// </summary>
        [JsonProperty("size")]
        public int? size { get; set; }
    }
}