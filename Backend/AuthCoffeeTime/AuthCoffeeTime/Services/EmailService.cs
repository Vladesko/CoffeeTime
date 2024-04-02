using AuthCoffeeTime.Interfaces;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System.Text;

namespace AuthCoffeeTime.Services
{
    public class EmailService : IEmailService
    {
        private readonly string BaseEmail;
        private readonly string CodeForAuthenticate;
        public EmailService()
        {
            using (var sr = new StreamReader("D:\\Passwords\\BaseEmail.txt", Encoding.UTF8, false))
            {
                BaseEmail = sr.ReadToEnd();
            }
            using (var sr = new StreamReader("D:\\Passwords\\Code.txt", Encoding.UTF8, false))
            {
                CodeForAuthenticate = sr.ReadToEnd();
            }
        }
        private async Task<int> CreateSecretCode()
        {
            Random random = new Random();
            string strForValue = string.Empty;

            for (int i = 0; i < 6; i++)
                strForValue += $"{random.Next(0, 10)}";

            int secretCode = Convert.ToInt32(strForValue);

            return secretCode;
        }
        public async Task<int> SendCode(string email)
        {
            int code = await CreateSecretCode();

            MimeMessage emailMessage = new MimeMessage();
            emailMessage.Sender = new MailboxAddress("Organization", BaseEmail);
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = "Confirm code";

            var body = new BodyBuilder();
            body.HtmlBody = $"<h1>Confirm your email</h1>\r\n    <h4 style=\"margin-top: 45px\">Coffee Time company invite you to stay \"Administrator\" in ours site</h4>\r\n    <h4>We send to you a code:</h4>\r\n    <h2>{code}</h2>\r\n    <h4>With this code you have site access</h4>";
            
            emailMessage.Body = body.ToMessageBody();

            using var clinet = new SmtpClient();
            await clinet.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            await clinet.AuthenticateAsync(BaseEmail, CodeForAuthenticate);
            await clinet.SendAsync(emailMessage);
            await clinet.DisconnectAsync(true);
            return code;
        }
    }
}
