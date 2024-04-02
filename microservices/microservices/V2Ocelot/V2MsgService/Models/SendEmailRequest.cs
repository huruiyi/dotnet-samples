namespace V2MsgService.Models
{
    public class SendEmailRequest
    {
        public string Email { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}