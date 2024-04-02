using MimeKit;
using MailKit.Net.Smtp;

namespace ConApp.Samples
{
    public class MailDemo
    {
        public static void Send()
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("胡睿毅", "807776962@qq.com"));
            message.To.Add(new MailboxAddress("胡一刀", "38761770@qq.com"));
            message.Subject = "How are you ?";

            message.Body = new TextPart("plain")
            {
                Text = @"Hey Chandler,
                        I just wanted to let you know that Monica and I were going to go play some paintball, you in?
                        -- Joey"
            };

            var client = new SmtpClient();
            client.Connect("smtp.qq.com", 587, false);
            client.Authenticate("807776962@qq.com", "rvcwelbqaasfbdeh");
            client.Send(message);
            client.Disconnect(true);
        }
    }
}
