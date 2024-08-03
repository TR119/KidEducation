using KidEducation.Core.Model;
using Microsoft.EntityFrameworkCore;


namespace KidEducation.Repository
{
    public class KidEducationDbContext : DbContext
    {
        public KidEducationDbContext(DbContextOptions<KidEducationDbContext> options)
            :base(options)
        {
            
        }
        #region Dbset
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Posts> Posts { get; set; }
        public DbSet<PopUp> Popups { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<TableShowConfig> TableShowConfigs{ get; set; }
        public DbSet<EmailSenderConfig> EmailSenderConfigs { get; set; }
        #endregion
    }
}
