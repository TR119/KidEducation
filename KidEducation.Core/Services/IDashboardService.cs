using KidEducation.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidEducation.Core.Services
{
    public interface IDashboardService
    {
        Task<DashboardViewModel> GetDashboard();
    }
}
