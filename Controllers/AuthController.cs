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
using System.Threading.Tasks;
using Kenguru_four_.HtmlHelpers;
using Kenguru_four_.Models;

namespace Kenguru_four_.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth

        [HttpPost]
        public RedirectResult ControlEnter(string email, string password)
        {
            string hash = hashed(hashed(password));

            if (ControlUser(email, hash)) {
                return Redirect(Request.Url.GetLeftPart(UriPartial.Authority) + "/seller");
            }
            else
            {
                return Redirect(Url.Action("/Enter", new {warning = true}));
            }
        }

        public bool ControlUser(string email, string hash)
        {
            KenguruDB database = new KenguruDB();
            List<Seller> users = database.Sellers.Where(t => string.Compare(t.email, email) == 0).ToList();
            if (users.Count == 0)
            {
                return false;
            }
            else
            {
                Seller user = users[0];
                if (string.Compare(user.password, hash) == 0)
                {
                    Session["user"] = new User(user.id, hash);
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public ActionResult Enter(bool worning = false)
        {
            ViewBag.worning = worning;
            return View();
        }


        public ActionResult Index(SellerIVM ivm)
        {
            KenguruDB db = new KenguruDB();
      
            if (ModelState.IsValid )
            {
                var emails = db.Sellers.Select(x => x.email);
                foreach(string email in emails)
                    if(email == ivm.seller.email)
                    {
                        ModelState.AddModelError("ivm.seller.email", "Пользователь с таким именем уже зарегестрирован");
                        return View(ivm);
                    }

                PrepareVereficationEmail(ivm.seller.email, ivm.password);
                return View("GoToMail");
            }
         
            return View(ivm);

        }
        public RedirectResult ControlVerefication(string email, string hash, string verefi)
        {
            KenguruDB dataBase = new KenguruDB();
            List<Seller> tryed = dataBase.Sellers.Where(t => String.Compare(t.email, email) == 0).ToList();
            if (tryed.Count > 0)
            {
                return Redirect("~/home");
            }

            if (string.Compare(hashed(email + hash), verefi) == 0)
                Made_seller(email, hash);

            tryed = dataBase.Sellers.Where(t => String.Compare(t.email, email) == 0).ToList();

            Session["User"] = new User(tryed[0].id, hash);

            return Redirect("~/seller/property");
        }


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
            string message = "Добрый день, для подтверждение вашего аккаунта пройдите по сcылке:";
            string hash = hashed(hashed(password));
            message += PrepareVereficationLink(email, hash);
            EmailService emailService = new EmailService();
            emailService.SendEmail(email, "Подтверждение почтового адреса(2)", message);
        }

      
        public void SendEmail(string receiver, string subject, string message)
        {
            MailAddress senderEmail = new MailAddress("sadar.kengu@yandex.ru", "Садар");
            MailAddress receiverEmail = new MailAddress(receiver, "Receiver");
            string password = "adminadminadmin";
            string sub = subject;
            string body = message;
            SmtpClient smtp = new SmtpClient
            {
                Host = "smtp.yandex.ru",
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
            KenguruDB dataBase = new KenguruDB();
            dataBase.Sellers.Add(new Seller(email, hash));
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
