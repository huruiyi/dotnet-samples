using Newtonsoft.Json;

namespace WebApp.Models.Music
{
    /// <summary>
    /// 获取音乐详细信息
    /// </summary>
    public class MusicDetails : MusicSummary
    {
        /// <summary>
        /// 音乐封面1
        /// </summary>
        [JsonProperty("songPicSmall")]
        public string SongPicSmall { get; set; }
        /// <summary>
        /// 音乐封面2
        /// </summary>
        [JsonProperty("songPicBig")]
        public string SongPicBig { get; set; }
        /// <summary>
        /// 音乐封面3
        /// </summary>
        [JsonProperty("songPicRadio")]
        public string SongPicRadio { get; set; }
    }
}