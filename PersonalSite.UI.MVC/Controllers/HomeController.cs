using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using System.Net;
using PersonalSite.UI.MVC.Models;

namespace PersonalSite.UI.MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Resume()
        {
            return View();
        }

        public ActionResult Portfolio()
        {
            return View();
        }

        public ActionResult Links()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Contact(ContactViewModel cvm)
        {
            if (ModelState.IsValid)
            {
                string body = $"{cvm.Name} sent you the following message: <br/>" +
                    $"{cvm.Message} <strong>From:</strong> {cvm.Email}";
                MailMessage m = new MailMessage("admin@dillonfisher.com", "dillon.f12.df@gmail.com", cvm.Subject, body);

                m.IsBodyHtml = true;

                m.Priority = MailPriority.High;

                m.ReplyToList.Add(cvm.Email);

                SmtpClient client = new SmtpClient("mail.dillonfisher.com");

                client.Credentials = new NetworkCredential("admin@dillonfisher.com", "@Ilikecheese617");

                client.Port = 8889;

                try
                {
                    client.Send(m);
                }
                catch (Exception e)
                {
                    ViewBag.Message = e.StackTrace;
                }
                return View("EmailConfirmation");
            }
            return View(cvm);
        }
    }    
}