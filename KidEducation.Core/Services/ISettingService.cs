using App.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidEducation.Core.Services
{
    public interface ISettingService
    {
        Task<ResponseJson> ChangePassword(string oldPassword, string newPassword, string confirmPassword);
    }
}
