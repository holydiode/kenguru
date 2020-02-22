using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MimeKit;
using MailKit.Net.Smtp;
using System.Threading.Tasks;
namespace Kenguru_four_.HtmlHelpers
{
    public class EmailService
    {
        public void SendEmail(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("Администрация сайта", "sadar.kengu@yandex.ru"));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            using (var client = new SmtpClient())
            {
                 client.Connect("smtp.yandex.ru", 25, false);
                 client.Authenticate("sadar.kengu@yandex.ru", "adminadminadmin");
                 client.Send(emailMessage);
                client.Disconnect(true);
            }
        }
    }
}