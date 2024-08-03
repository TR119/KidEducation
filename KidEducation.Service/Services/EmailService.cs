using KidEducation.Core.Model;
using KidEducation.Core.Primitives;
using KidEducation.Core.Repositories;
using KidEducation.Core.Services;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidEducation.Services.Services
{
    public class EmailService : IEmailService
    {
        private readonly IEmailSenderConfigRepository _emailSenderConfigRepository;
        public EmailService( IEmailSenderConfigRepository emailSenderConfigRepository)
        {
            _emailSenderConfigRepository = emailSenderConfigRepository;
        }

        public async Task<string> GetEmailTo(){
            return await _emailSenderConfigRepository.GetEmailToId();
        }

        public async Task<bool> UpdateEmailConfig(EmailSenderConfig? emailSenderConfig)
        {
            return await _emailSenderConfigRepository.UpdateEmailSenderConfig(emailSenderConfig);
        }

        public async Task<bool> SendEmailAsync(EmailData emailData)
        {
            try
            {
                EmailSenderConfig emailSenderConfig = await _emailSenderConfigRepository.GetEmailConfig();
                //MimeMessage - a class from Mimekit
                MimeMessage email_Message = new MimeMessage();
                MailboxAddress email_From = new MailboxAddress(emailSenderConfig.Name, emailSenderConfig.EmailId);
                email_Message.From.Add(email_From);
                MailboxAddress email_To = new MailboxAddress(emailData.EmailToName, emailData.EmailToId);
                email_Message.To.Add(email_To);
                email_Message.Subject = emailData.EmailSubject;
                BodyBuilder emailBodyBuilder = new BodyBuilder();
                emailBodyBuilder.TextBody = emailData.EmailBody;
                email_Message.Body = emailBodyBuilder.ToMessageBody();
                //this is the SmtpClient class from the Mailkit.Net.Smtp namespace, not the System.Net.Mail one
                SmtpClient MailClient = new SmtpClient();
                MailClient.Connect(emailSenderConfig.Host, emailSenderConfig.Port, MailKit.Security.SecureSocketOptions.StartTls);
                MailClient.Authenticate(emailSenderConfig.EmailId, emailSenderConfig.Password);
                MailClient.Send(email_Message);
                MailClient.Disconnect(true);
                MailClient.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                // Exception Details
                return false;
            }
        }

        public async Task<EmailSenderConfig> GetEmailConfig()
        {
            return await _emailSenderConfigRepository.GetEmailConfig();
        }
    }
}
