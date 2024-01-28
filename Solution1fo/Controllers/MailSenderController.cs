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

        public bool sendMail(string email, string content, string subject, IFormFile file = null)
        {
            bool send = false;

            if (authorization != Environment.GetEnvironmentVariable("INTERN"))
            {
                return send;
            }
            if (email == "" || email == null)
            {
                send = false;
            }
            else
            {
                var message = new MimeMessage();

                message.From.Add(new MailboxAddress("Solution1fo", "noreply@solution1fo.fr"));
                message.To.Add(new MailboxAddress("", email));
                message.Subject = subject;

                var builder = new BodyBuilder();
                content += " ";


                builder.HtmlBody = content;

                if (file != null)
                {
                    if (file.Length > 0)
                    {
                        using (var ms = new MemoryStream())
                        {
                            file.CopyTo(ms);
                            byte[] fileBytes = ms.ToArray();
                            builder.Attachments.Add(file.FileName, fileBytes);
                        }
                    }
                }

                message.Body = builder.ToMessageBody();

                try
                {
                    using (var client = new MailKit.Net.Smtp.SmtpClient())
                    {
                        int port = 0;
                        if (Environment.GetEnvironmentVariable("SMTP_PORT") != null)
                        {
                            port = int.Parse(Environment.GetEnvironmentVariable("SMTP_PORT"));
                        }
                        client.Connect(Environment.GetEnvironmentVariable("SMTP"), port, MailKit.Security.SecureSocketOptions.StartTlsWhenAvailable);
                        client.Authenticate(Environment.GetEnvironmentVariable("SMTP_LOGIN"), Environment.GetEnvironmentVariable("SMTP_PWD"));

                        client.Send(message);
                        client.Disconnect(true);
                        send = true;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

            return send;
        }

        /*public bool sendtestMail()
        {
            bool send = false;
            string email = "damienchereault@gmail.com";
            string content = "test relay";
            string subject = "test relay";

            send = sendMail(email, content, subject);

            return send;
        }*/
    }
}
