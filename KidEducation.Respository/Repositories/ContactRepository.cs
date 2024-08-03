using KidEducation.Core.Model;
using KidEducation.Core.Primitives;
using KidEducation.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Linq.Dynamic.Core;

namespace KidEducation.Repository.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly KidEducationDbContext _context;
        public ContactRepository(KidEducationDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Contact>> GetPaging(JqueryDataTableModels request, int status, JqueryDataTableResponse response)
        {
            var queryAble = _context.Contacts.AsNoTracking();

            if (!request.Search.IsNullOrEmpty())
            {
                queryAble = queryAble.Where(x => x.Name.Contains(request.Search) || x.Service.Contains(request.Search));
            }
            response.recordsTotal = response.recordsFiltered = await queryAble.CountAsync();
            return await queryAble.OrderBy(request.Order).Skip(request.Skip).Take(request.Take).AsNoTracking()
                .ToListAsync();
        }

        public async Task<bool> Create(Contact contact)
        {
           _context.Contacts.Add(contact);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<Contact>> GetAllContacts()
        {
           return await _context.Contacts.AsNoTracking().ToListAsync();
        }

        public async Task<bool> Update(int id)
        {
            var contact = await _context.Contacts.Where(x=>x.Id == id).FirstOrDefaultAsync();
            contact.Status = 2;
            _context.Contacts.Update(contact);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
