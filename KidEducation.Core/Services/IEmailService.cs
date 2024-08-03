using KidEducation.Core.Model;
using KidEducation.Core.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidEducation.Core.Services
{
    public interface IEmailService
    {
        Task<bool> SendEmailAsync(EmailData EmailData);
        Task<string> GetEmailTo();
        Task<EmailSenderConfig> GetEmailConfig();
        Task<bool> UpdateEmailConfig(EmailSenderConfig emailSenderConfig);
    }
}
