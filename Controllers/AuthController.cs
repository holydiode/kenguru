using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kenguru_four_;
using System.Text;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System.Net.Mail;
using System.Net;
using Xunit.Sdk;
using System.ComponentModel.DataAnnotations;

namespace Kenguru_four_.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth

        public ActionResult Index(sellers seller)
        {
            if (ModelState.IsValid)
            {
                PrepareVereficationEmail(seller.email, seller.password);
                return View("GoToMail");
            }
            return View(seller);

        }
        public ActionResult ControlVerefication(string email, string hash, string verefi)
        {

            if (string.Compare(hashed(email + hash), verefi) == 0)
                Made_seller(email, verefi);
            return View("Index", "Home");

        }

        //поменять алгоритм шифрования на адекватный
        private string PrepareVereficationLink(string email, string hash)
        {
            string verefi = hashed(email + hash);
            string link = Request.Url.GetLeftPart(UriPartial.Authority);
            link += Url.Action("/ControlVerefication", new { email, hash, verefi });
            return link;
        }


        [HttpPost]
        public void PrepareVereficationEmail(string email, string password)
        {
            string message = "Добрый день, для подтверждение вашего аккаунта пройдите по сылке:";
            string hash = hashed(hashed(password));
            message += PrepareVereficationLink(email, hash);
            SendEmail(email, "Подтверждение почтового адреса", message);
        }

        public void SendEmail(string receiver, string subject, string message)
        {

            MailAddress senderEmail = new MailAddress("sadar.kengu@mail.ru", "Садар");
            MailAddress receiverEmail = new MailAddress(receiver, "Receiver");
            string password = "adminadminadminadmin";
            string sub = subject;
            string body = message;
            SmtpClient smtp = new SmtpClient
            {
                Host = "smtp.mail.ru",
                Port = 2525,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(senderEmail.Address, password)
            };

            using (var mess = new MailMessage(senderEmail, receiverEmail)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(mess);
            }
        }

        public void Made_seller(string email, string hash)
        {
            kenguru dataBase = new kenguru();
            dataBase.sellers.Add(new sellers(email, hash));
            dataBase.SaveChanges();
        }

        private string hashed(string pasword)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(pasword));
            return Convert.ToBase64String(hash);
        }

    }
}
