using KidEducation.Core.Repositories;
using KidEducation.Core.Services;
using KidEducation.Core.ViewModel;
using KidEducation.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidEducation.Services.Services
{
    public class DashboardService: IDashboardService
    {
        private readonly KidEducationDbContext _dbContext;
        private readonly IDashboardRepository _dashboardRepository;
        public DashboardService(KidEducationDbContext dbContext,IDashboardRepository dashboardRepository)
        {
            _dbContext = dbContext;
            _dashboardRepository = dashboardRepository;
        }
        public async Task<DashboardViewModel> GetDashboard()
        {
            return await _dashboardRepository.GetDashboard();
        }
       
    }
}
