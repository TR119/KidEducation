
using KidEducation.Core.Model;
using KidEducation.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace KidEducation.Repository.Repositories
{
    public class PopupRepository : IPopupRepository
    {
        private readonly KidEducationDbContext _context;
        public PopupRepository(KidEducationDbContext context)
        {
            _context = context;
        }
       public async Task<bool> Create(PopUp popUp)
        {
            _context.Popups.Add(popUp);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<PopUp> GetPopup()
        {
            return await _context.Popups.AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<bool> Update(PopUp post)
        {
            _context.Popups.Update(post);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<PopUp> GetPopupToShow()
        {
            return await _context.Popups.AsNoTracking().FirstOrDefaultAsync(x => x.StartTime <= DateTime.Now && x.EndTime > DateTime.Now && x.Status==true);
        }

    }
}
