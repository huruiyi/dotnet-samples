using Newtonsoft.Json;

namespace Token.Models
{
    public class TokenResultMsg : HttpResponseMsg
    {
        public TokenInfo Result
        {
            get
            {
                if (StatusCode == (int)StatusCodeEnum.Success)
                {
                    return JsonConvert.DeserializeObject<TokenInfo>(Data.ToString());
                }

                return null;
            }
        }
    }
}