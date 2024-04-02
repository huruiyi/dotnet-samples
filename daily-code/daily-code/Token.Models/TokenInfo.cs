using System;

namespace Token.Models
{
    public class TokenInfo
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public int StaffId { get; set; }

        /// <summary>
        /// 用户名对应签名Token
        /// </summary>
        public Guid SignToken { get; set; }

        /// <summary>
        /// Token过期时间
        /// </summary>
        public DateTime ExpireTime { get; set; }
    }
}