using System.Net;
using System.Net.Mail;

namespace Blog.Web.Mvc.Services
{
    public class EmailService
    {
        public void Send(string toMail, string subject, string body)
        {
            // SmtpClient: Sunucu ayarları
            var client = new SmtpClient("sandbox.smtp.mailtrap.io", 587)
            {
                // Cem hoca Username: 3fcb198edaf1e4  Password:  1818d6d691d359
                // Ali Burhan Username: f36c9b1690b89a  Password:  173067f30c9825
                Credentials = new NetworkCredential("f36c9b1690b89a", "173067f30c9825"),
                EnableSsl = true
            };

            // MailMessage: Mail ayarları
            var mail = new MailMessage()
            {
                From = new MailAddress("BlogWebMvc@domain.com", "BlogWebMvc"),
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };

            mail.To.Add(new MailAddress(toMail));
            //mail.CC.Add(new MailAddress(toMail));
            //mail.Bcc.Add("cmg.web@gmail.com");

            client.Send(mail);
        }
    }
}

