using MailKit.Net.Smtp;
using MimeKit;

namespace ConApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("胡睿毅爸爸", "807776962@qq.com"));
            message.To.Add(new MailboxAddress("石丹", "38761770@qq.com"));
            message.Subject = "How are you ?";

            message.Body = new TextPart("plain")
            {
                Text = @"Hey Chandler,
I just wanted to let you know that Monica and I were going to go play some paintball, you in?
-- Joey"
            };

            using var client = new SmtpClient();
            client.Connect("smtp.qq.com", 587, false);
            client.Authenticate("807776962@qq.com", "rvcwelbqaasfbdeh");
            client.Send(message);
            client.Disconnect(true);
        }
    }
}