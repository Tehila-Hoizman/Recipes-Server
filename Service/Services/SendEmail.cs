using Common.Entity;
using MailKit.Security;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace Service.Services
{
    public class SendEmailService
    {
        public string readData(string urlPage)
        {
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            string pat = Path.GetDirectoryName(Uri.UnescapeDataString(uri.Path));
            string full = Path.Combine(pat, urlPage);
            string htmlBody = "";
            using (var reader = new StreamReader(full))
            {
                htmlBody = reader.ReadToEnd();
            }
            ;
            return htmlBody;

        }
        public async Task SendEmail(string to, string name, string htmlBody, string Subject)
        {
            try
            {
                using (var s = new SmtpClient())
                {
                    await s.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                    //כתובת מייל
                    //סיסמה של אפליקציה
                    await s.AuthenticateAsync("delicious.recipes.website@gmail.com", "otpj pafk gkep xcfw");
                    var email = new MimeMessage();
                    //השם של החברה
                    // הכתובת מייל של החברה
                    email.From.Add(new MailboxAddress("Delicious", "delicious.recipes.website@gmail.com"));
                    email.To.Add(new MailboxAddress(name, to));
                    var bodyBuilder = new BodyBuilder();
                    bodyBuilder.HtmlBody = htmlBody;

                    email.Body = bodyBuilder.ToMessageBody();
                    email.Subject = Subject;
                    s.CheckCertificateRevocation = false;
                    ////כתובת מייל
                    ////סיסמה של אפליקציה
                    await s.SendAsync(email);
                    await s.DisconnectAsync(true);

                }

                Console.WriteLine("Mail Sent Successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to send email: {ex.Message}");
            }
        }
        public void SendMailToManager( EmailDto emailDto)//kind: 1=Sharing, 2=ContactRouting
        {
            string subject = "יצירת קשר ";
            string htmlBody = readData("html/Contact.html");
            htmlBody = htmlBody.Replace("{email}", emailDto.Email);
            htmlBody = htmlBody.Replace("{name}", emailDto.Name);
            htmlBody = htmlBody.Replace("{content}", emailDto.Content);

            // הכתובת למי שולחים
            // שם אליו שולחים
            // גוף המייל כל  מה שעשינו עד כה
            // כותרת המייל
            SendEmail("delicious.recipes.website@gmail.com", "", htmlBody, subject);
        }

    }
}
