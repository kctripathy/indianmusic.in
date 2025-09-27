using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianMusic.Application
{
    public interface IEmailSenderFromApp
    {
        Task<bool> SendEmailGoogleAsync(string toEmail, string subject, string body);
    }
}
