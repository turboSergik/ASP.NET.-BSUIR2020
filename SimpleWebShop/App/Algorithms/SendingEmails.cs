using MimeKit;
using MailKit.Net.Smtp;
using System.Threading.Tasks;

namespace SimpleWebShop.App.Algorithms
{
    public static class SendingEmails
    {
        public static async Task SendEmailAsync(string email, string subject = "", string message = "")
        {

            if (subject.Length == 0) subject = "Успешная регистрация";
            if (message.Length == 0) message = "Вы успешно зарегестрировались на сайте simpleWebShop!";

            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("Администрация сайта", "sergey.piskunasp.net@gmail.com"));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            using (var client = new SmtpClient())
            {
                client.CheckCertificateRevocation = false;
                client.Connect("smtp.gmail.com", 465, true);
                await client.AuthenticateAsync("sergey.piskunasp.net@gmail.com", "trashpassword228322");
                await client.SendAsync(emailMessage);

                await client.DisconnectAsync(true);
            }
        }
    }
}
