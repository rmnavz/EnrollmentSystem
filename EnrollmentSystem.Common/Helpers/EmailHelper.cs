using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EnrollmentSystem.Common.Helpers
{
    public class EmailHelper
    {
        private readonly NetworkCredential _NetworkCredential;
        private MailMessage _MailMessage;

        public EmailHelper()
        {
            _NetworkCredential = new NetworkCredential
            {
                UserName = "rmnavz@yandex.com",
                Password = "P@ssw0rd1234"
            };

            _MailMessage = new MailMessage();
        }

        //public async Task SendEmailAsync()
        //{
        //    var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
        //    message.Body = string.Format(body, model.FromName, model.FromEmail, model.Message);
        //    message.IsBodyHtml = true;
        //}

        public void NewAccountTemplate()
        {
            var body = "<p>New Account Created</p>";
            _MailMessage.Body = string.Format(body);
            _MailMessage.IsBodyHtml = true;
        }

        public async Task SendMail(string Subject, string Reciever, string Sender = "rmnavz@domain.com")
        {
            _MailMessage.To.Add(new MailAddress(Reciever));  // replace with valid value 
            _MailMessage.From = new MailAddress(Sender);  // replace with valid value
            _MailMessage.Subject = Subject;

            using (var smtp = new SmtpClient())
            {
                smtp.Credentials = _NetworkCredential;
                smtp.Host = "smtp.yandex.com";
                smtp.Port = 465;
                smtp.EnableSsl = true;
                await smtp.SendMailAsync(_MailMessage);
            }
        }

        public async Task SendMail(string Subject, IEnumerable<string> Recievers, string Sender = "rmnavz@domain.com")
        {
            foreach(var Reciever in Recievers)
            {
                _MailMessage.To.Add(new MailAddress(Reciever));  // replace with valid value 
            }
            _MailMessage.From = new MailAddress(Sender);  // replace with valid value
            _MailMessage.Subject = Subject;

            using (var smtp = new SmtpClient())
            {
                smtp.Credentials = _NetworkCredential;
                smtp.Host = "smtp.yandex.com";
                smtp.Port = 465;
                smtp.EnableSsl = true;
                await smtp.SendMailAsync(_MailMessage);
            }
        }
    }
}
