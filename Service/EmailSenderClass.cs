using System.Net.Mail;
using System.Net;

namespace EmailSender.MVC.Service
{
    public class EmailSenderClass
    {
            public bool SendEmail(string toEmail, string userName)
            {
                var otpCode = new Random().Next(100000, 999999).ToString();
                var smtpServer = "smtp.gmail.com";
                var port = 587;
                var username = "aamaruf2000@gmail.com";
                var password = Environment.GetEnvironmentVariable("gmail_pass", EnvironmentVariableTarget.User);
                var fromEmail = "aamaruf2000@gmail.com";

                try
                {
                    using (var client = new SmtpClient(smtpServer, port))
                    {
                        client.EnableSsl = true;
                        client.Credentials = new NetworkCredential(username, password);

                        var mail = new MailMessage
                        {
                            From = new MailAddress(fromEmail),
                            Subject = "Welcome to Our App!",
                            Body = $"<h2>Congratulations, {userName}!</h2><p>Your account has been created successfully.</p>",

                            IsBodyHtml = true
                        };
                        mail.To.Add(toEmail);
                        client.Send(mail);
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    // Log the exception
                    return false;
                }
            }
    
    }
}
