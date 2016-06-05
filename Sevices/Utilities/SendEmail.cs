using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ExcelManageITService.Utilities
{
    class SendEmail
    {
        public void Sendemail(String toMail, String subject, String body)
        {
            MailMessage mail = new MailMessage();
            mail.To.Add(toMail);
            mail.From = new MailAddress("donotreply@excelmanageit.com");
            mail.Subject =subject;
            
            mail.Body = body;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential
            ("nusisscrs@gmail.com", "test123#");// Enter seders User name and password
            smtp.EnableSsl = true;
            smtp.Send(mail);
        }
    }
}
