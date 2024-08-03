using AutoMapper;
using KidEducation.Core.Repositories;
using KidEducation.Core.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidEducation.Repository.Repositories
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly KidEducationDbContext _context;
        private readonly IMapper _mapper;
        public DashboardRepository(KidEducationDbContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }
        public async Task<DashboardViewModel> GetDashboard()
        {
            var dashboard = new DashboardViewModel();
            dashboard.TotalContact = _context.Contacts.Count();
            dashboard.TotalContactToday = _context.Contacts.Count(x => x.CreatedDate.Value.Date == DateTime.Now.Date);
            dashboard.TotalPost = _context.Posts.Count();
            dashboard.TotalPostInMonth = _context.Posts.Count(x => x.CreateDate.Value.Month == DateTime.Now.Month);
            dashboard.ContactsToHandle = _mapper.Map<List<ContactViewModel>>(await _context.Contacts.Where(x => x.Status != 2).ToListAsync());
            dashboard.ContactsToday = _mapper.Map<List<ContactViewModel>>(await _context.Contacts.Where(x => x.CreatedDate.Value.Date == DateTime.Now.Date).ToListAsync());
            return dashboard;
        }

    }
}
