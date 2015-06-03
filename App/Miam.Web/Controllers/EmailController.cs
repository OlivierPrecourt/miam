﻿using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Web.Mvc;
using SendGrid;

namespace Miam.Web.Controllers
{
    public partial class EmailController : Controller
    {
        [HttpGet]
        public virtual ActionResult Send()
        {
            return View();
        }

        [HttpPost, ActionName("Send")]
        public virtual ActionResult SendPost()
        {
            // Envoi de courriel avec l'api de Sendgrid) 
            var accountSendGrid = ConfigurationManager.AppSettings["mailAccountSendGrid"];
            var passwordSendGrid = ConfigurationManager.AppSettings["mailPasswordSenGrid"];
            var credentials = new NetworkCredential(accountSendGrid, passwordSendGrid);
            var transportWeb = new SendGrid.Web(credentials);

            SendGridMessage myMessage = new SendGridMessage();
            myMessage.AddTo("tomiamtest@yopmail.com");
            myMessage.From = new MailAddress("frommiamtest@yopmail.com", "Coordonateur de miam");
            myMessage.Subject = "le texte";
            myMessage.Text = "le message";

            transportWeb.Deliver(myMessage);

            return RedirectToAction(MVC.Home.Index());
        }
    }
}

