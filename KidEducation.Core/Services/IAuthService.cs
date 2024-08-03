using App.Domain.Primitives;
using KidEducation.Core.Model;
using KidEducation.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidEducation.Core.Services
{
    public interface IAuthService
    {
        Task<(Account?,string)> LoginAsync(LoginViewModel viewModel);
        Task<ResponseJson> ChangePassword(int id,string oldPassword, string newPassword, string confirmPassword);
    }
}
