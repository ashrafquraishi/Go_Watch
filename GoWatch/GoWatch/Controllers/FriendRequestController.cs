using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;

namespace GoWatch.Controllers
{
    public class FriendRequestController : Controller
    {
        // GET: FriendRequest
        public ActionResult Index()
        {
            //TODO: Figure out how to insert the e-mail address into this paramater

            MailMessage mail = new MailMessage("you@yourcompany.com", "test@test.com");
            SmtpClient client = new SmtpClient
            {
                Port = 25,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Host = "smtp.gmail.com"
            };
            mail.Subject = "Friend Request";
            mail.Body = "Hi, I want to add you as a friend.";
            client.Send(mail);

            return View();
        }
    }
}