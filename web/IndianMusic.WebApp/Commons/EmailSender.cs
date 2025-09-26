using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianMusic.Application
{
    using System.Net;
    using System.Net.Mail;
    using Microsoft.AspNetCore.Identity.UI.Services;
    using Microsoft.Extensions.Configuration; // Or use IOptions for cleaner configuration access

    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _configuration;

        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            // Retrieve settings from configuration (e.g., appsettings.json or User Secrets)
            var gmailUser = _configuration["EmailSettings:GmailUser"];
            var gmailAppPassword = _configuration["EmailSettings:GmailAppPassword"];
            var smtpHost = "smtp.gmail.com";
            var smtpPort = 587; // Gmail's TLS port

            var message = new MailMessage(gmailUser, email, subject, htmlMessage)
            {
                IsBodyHtml = true
            };

            using (var client = new SmtpClient(smtpHost, smtpPort))
            {
                client.Credentials = new NetworkCredential(gmailUser, gmailAppPassword);
                client.EnableSsl = true; // Essential for Gmail

                try
                {
                    return client.SendMailAsync(message);
                }
                catch (Exception ex)
                {
                    // Log the exception (recommended)
                    Console.WriteLine($"Error sending email: {ex.Message}");
                    return Task.FromException(ex);
                }
            }
        }
    }
}
