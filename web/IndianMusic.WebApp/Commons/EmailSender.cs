using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration; // Or use IOptions for cleaner configuration access
using System.Net;
using System.Net.Mail;

namespace IndianMusic.Application
{
    public class EmailSenderFromApp : IEmailSenderFromApp
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<IEmailSenderFromApp> _logger; // Use the generic ILogger<T>

        //private readonly ILogger _logger;

        public EmailSenderFromApp(IConfiguration configuration, ILogger<IEmailSenderFromApp> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public async Task<bool> SendEmailGoogleAsync(string toEmail, string subject, string body)
        {

            var gmailUser = _configuration["EmailSettings:GmailUser"];
            var gmailAppPassword = _configuration["EmailSettings:GmailAppPassword"];

            var fromEmail = "indianmusicz123@gmail.com";
            var appPassword = "lntj rkfk grve hute"; // 16-digit app password from Gmail

            var mail = new MailMessage();
            mail.From = new MailAddress(fromEmail);
            mail.To.Add(toEmail);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;

            using (var smtp = new SmtpClient("smtp.gmail.com", 587))
            {
                smtp.Credentials = new NetworkCredential(fromEmail, appPassword);
                smtp.EnableSsl = true;

                try
                {
                    await smtp.SendMailAsync(mail);
                    _logger.LogInformation("An Email has been set to " + toEmail);
                    return true;
                }
                catch (Exception ex)
                {
                    _logger.LogInformation(ex.Message.ToString());
                    return false;
                }
            }
        }


        //public Task SendEmailAsync(string email, string subject, string htmlMessage)
        //{
        //    // Retrieve settings from configuration (e.g., appsettings.json or User Secrets)
        //    var gmailUser = _configuration["EmailSettings:GmailUser"];
        //    var gmailAppPassword = _configuration["EmailSettings:GmailAppPassword"];
        //    var smtpHost = "smtp.gmail.com";
        //    var smtpPort = 587; // Gmail's TLS port

        //    var message = new MailMessage(gmailUser, email, subject, htmlMessage)
        //    {
        //        IsBodyHtml = true
        //    };

        //    using (var client = new SmtpClient(smtpHost, smtpPort))
        //    {
        //        client.Credentials = new NetworkCredential(gmailUser, gmailAppPassword);
        //        client.EnableSsl = true; // Essential for Gmail

        //        try
        //        {
        //            return client.SendMailAsync(message);
        //        }
        //        catch (Exception ex)
        //        {
        //            // Log the exception (recommended)
        //            Console.WriteLine($"Error sending email: {ex.Message}");
        //            return Task.FromException(ex);
        //        }
        //    }
        //}
    }
}
