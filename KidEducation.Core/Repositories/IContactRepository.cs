using KidEducation.Core.Model;
using KidEducation.Core.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidEducation.Core.Repositories
{
    public interface IContactRepository
    {
        Task<IEnumerable<Contact>> GetPaging(JqueryDataTableModels request, int status, JqueryDataTableResponse response);
        Task<List<Contact>> GetAllContacts();
        Task<bool> Create(Contact contact);
        Task<bool> Update(int id);
    }
}
