using KidEducation.Core.Model;
using KidEducation.Core.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidEducation.Core.Repositories
{
    public interface IEmailSenderConfigRepository
    {

        Task<string> GetEmailToId();
        Task<EmailSenderConfig> GetEmailConfig();
        Task<bool> UpdateEmailSenderConfig(EmailSenderConfig? emailConfiguration);
    }
}
