namespace V1MsgService.Models
{
    public class SendSMSRequest
    {
        public string PhoneNum { get; set; }
        public string Msg { get; set; }
    }
}