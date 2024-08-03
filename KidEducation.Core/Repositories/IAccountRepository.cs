using KidEducation.Core.Model;
using KidEducation.Core.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidEducation.Core.Repositories
{
    public interface IAccountRepository
    {
        Task<Account> GetByUsername(string username);
        Task<IEnumerable<Account>> GetPaging(JqueryDataTableModels request, int status, JqueryDataTableResponse response);
        Task<bool> Create(Account post);
        Task<bool> Update(Account post);
        Task<bool> Delete(int id);
        Task<bool>ChangePassword (int id, string newPassword);
        Task<bool> CheckOldPassword (int id, string oldPassword);
    }
}
