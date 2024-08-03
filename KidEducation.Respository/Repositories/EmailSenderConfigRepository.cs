using KidEducation.Core.Model;
using KidEducation.Core.Primitives;
using KidEducation.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidEducation.Repository.Repositories
{
    public class EmailSenderConfigRepository : IEmailSenderConfigRepository
    {
        private readonly KidEducationDbContext _context;
        public EmailSenderConfigRepository(KidEducationDbContext context)
        {
            _context = context;
        }
        public async Task<string> GetEmailToId()
        {
            return await _context.EmailSenderConfigs.Select(s=>s.EmailToId).FirstOrDefaultAsync();
        }
        public async Task<EmailSenderConfig> GetEmailConfig()
        {
            return await _context.EmailSenderConfigs.FirstOrDefaultAsync();
        }
        public async Task<bool> UpdateEmailSenderConfig(EmailSenderConfig model)
        {
           _context.EmailSenderConfigs.Update(model);
            return await _context.SaveChangesAsync() > 0;
        }

       
    }
}
