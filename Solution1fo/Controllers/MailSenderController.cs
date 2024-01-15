using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MailKit;
using MimeKit.Cryptography;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using System.IO;
using MimeKit.Utils;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Net.Mail;

namespace Homea.Controllers
{
    public class MailSenderController : Controller
    {
        private readonly string authorization = "";
        public MailSenderController(string auth)
        {
            authorization = auth;
        }

        public bool sendMail(string email, string content, string subject, IFormFile cv = null)
        {
            bool send = false;

            /*if (authorization != Environment.GetEnvironmentVariable("INTERN"))
            {
                return send;
            }*/

            var message = new MimeMessage();

            message.From.Add(new MailboxAddress("Solution1fo", "noreply@solution1fo.fr"));
            message.To.Add(new MailboxAddress("", email));
            message.Subject = subject;

            var builder = new BodyBuilder();
            content += " ";


            builder.HtmlBody = content;

            if (cv != null)
            {
                if (cv.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        cv.CopyTo(ms);
                        byte[] fileBytes = ms.ToArray();
                        builder.Attachments.Add(cv.FileName, fileBytes);
                    }
                }
            }

            message.Body = builder.ToMessageBody();

            try
            {
                using (var client = new MailKit.Net.Smtp.SmtpClient())
                {
                    client.Connect("solution1fo.fr", 25, MailKit.Security.SecureSocketOptions.StartTlsWhenAvailable);
                    client.Authenticate("solution1fo", "<Jmy6{5<OW<dm1iC*yId");

                    client.Send(message);
                    client.Disconnect(true);
                    send = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return send;
        }

        public bool sendtestMail()
        {
            bool send = false;
            string email = "damienchereault@gmail.com";
            string content = "test relay from api";
            string subject = "test relay";

            send = sendMail(email, content, subject);

            return send;
        }
    }
}
