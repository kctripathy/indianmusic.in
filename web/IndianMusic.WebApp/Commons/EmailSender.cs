using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration; // Or use IOptions for cleaner configuration access
using System.Net;
using System.Net.Mail;
using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;


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

            var gmailUser = _configuration["Authentication:Google:GmailUser"];
            var gmailAppPassword = _configuration["Authentication:Google:GmailAppPassword"];

            var mail = new MailMessage();
            mail.From = new MailAddress(gmailUser);
            mail.To.Add(toEmail);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;

            using (var smtp = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587))
            {
                smtp.Credentials = new NetworkCredential(gmailUser, gmailAppPassword);
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


        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var gmailUser = _configuration["Authentication:Google:GmailUser"];
            var gmailAppPassword = _configuration["Authentication:Google:GmailAppPassword"];

            var smtpHost = "smtp.gmail.com";
            var smtpPort = 587; // Gmail's TLS port

            var message = new MailMessage(gmailUser, email, subject, htmlMessage)
            {
                IsBodyHtml = true
            };

            using (var client = new System.Net.Mail.SmtpClient(smtpHost, smtpPort))
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


        public async Task<bool> SendEmailAsync(string receipientName, string recipientEmail, string subject, string body)
        {
            try
            {
                var smtpHost = _configuration["MailServer:SMTPHost"];
                var smtpPort = int.Parse(_configuration["MailServer:SMTPPort"]);
                var userName = _configuration["MailServer:UserName"];
                var userEmail = _configuration["MailServer:UserEmail"];
                var userPassword = _configuration["MailServer:UserPassword"];

                var message = new MimeMessage();

                // Sender details (Must match your SMTP login details)
                message.From.Add(new MailboxAddress(userName, userEmail));
                message.To.Add(new MailboxAddress(receipientName, recipientEmail));
                //
                message.Subject = subject;

                // Set the body content (use TextPart for plain text or BodyBuilder for HTML)
                message.Body = new TextPart("html") { Text = body };

                using (var client = new MailKit.Net.Smtp.SmtpClient())
                {
                    // 1. Connect to the Host.co.in SMTP server
                    await client.ConnectAsync(smtpHost, smtpPort, SecureSocketOptions.SslOnConnect);

                    // 2. Authenticate
                    await client.AuthenticateAsync(userEmail, userPassword);

                    // 3. Send the email
                    await client.SendAsync(message);
                    await client.DisconnectAsync(true); // Disconnect and dispose
                }
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message.ToString());
                return false;
            }
            
        }

         
    }
}
