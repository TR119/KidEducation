using KidEducation.Core.Model;
using KidEducation.Core.Primitives;
using KidEducation.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Linq.Dynamic.Core;

namespace KidEducation.Repository.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly KidEducationDbContext _context;
        public AccountRepository(KidEducationDbContext context)
        {
           _context = context;
        }

        public async Task<bool> Create(Account account)
        {
            await _context.Accounts.AddAsync(account);
            return await _context.SaveChangesAsync() >0;
        }

        public async Task<bool> Delete(int id)
        {
            var account = await _context.Accounts.Where(x=>x.Id == id).FirstOrDefaultAsync();
            if (account == null)
            {
                return false;
            }
            _context.Accounts.Remove(account);
            return await _context.SaveChangesAsync()>0;
        }

        public async Task<Account> GetById(int id)
        {
            return await _context.Accounts.FindAsync(id);
        }

        public async Task<bool> Update(Account account)
        {
            _context.Accounts.Update(account);
            return await _context.SaveChangesAsync() >0;
            
        }


        public async Task<IEnumerable<Account>> GetPaging(JqueryDataTableModels request, int status, JqueryDataTableResponse response)
        {
            var queryAble = _context.Accounts.AsNoTracking().Where(x=>x.IsAdmin != true);

            if (!request.Search.IsNullOrEmpty())
            {
                queryAble = queryAble.Where(x => x.Fullname.Contains(request.Search));
            }
            response.recordsTotal = response.recordsFiltered = await queryAble.CountAsync();
            return await queryAble.OrderBy(request.Order).Skip(request.Skip).Take(request.Take).AsNoTracking()
                .ToListAsync();
        }

        public async Task<Account> GetByUsername(string username)
        {
            return await _context.Accounts.AsNoTracking().Where(o => o.Username == username).FirstOrDefaultAsync();
        }

        public async Task<bool> ChangePassword(int id, string newPassword)
        {
            var account = await _context.Accounts.FindAsync(id);
            account.Password = newPassword;
            _context.Accounts.Update(account);
            return await _context.SaveChangesAsync() > 0;
        }

        public Task<bool> CheckOldPassword(int id, string oldPassword)
        {
            return _context.Accounts.AnyAsync(x => x.Id == id && x.Password == oldPassword);
        }
    }
}
