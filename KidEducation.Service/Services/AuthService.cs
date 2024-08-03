using App.Domain.Primitives;
using KidEducation.Core.Model;
using KidEducation.Core.Repositories;
using KidEducation.Core.Services;
using KidEducation.Core.ViewModel;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidEducation.Services.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAccountRepository _accountRepository;

        public AuthService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<ResponseJson> ChangePassword(int id,string oldPassword, string newPassword, string confirmPassword)
        {
            var response = new ResponseJson()
            {
                Status = StatusCodes.Status200OK,
                Message = "Đổi mật khẩu thành công"
            };
            if (newPassword != confirmPassword)
            {
                response.Status = StatusCodes.Status400BadRequest;
                response.Message = "Mật khẩu mới không trùng khớp";
                return response;
            }
            var isOldPasswordCorrect = await _accountRepository.CheckOldPassword(id, oldPassword);
            if(!isOldPasswordCorrect)
            {
                response.Status = StatusCodes.Status400BadRequest;
                response.Message = "Mật khẩu cũ không chính xác";
                return response;
            }

            var result = await _accountRepository.ChangePassword(id, newPassword);

            if(!result)
            {
                response.Status = StatusCodes.Status400BadRequest;
                response.Message = "Đổi mật khẩu thất bại";
            }
            return response;
        }

        public async Task<(Account?,string)> LoginAsync(LoginViewModel viewModel)
        {
            var user = await _accountRepository.GetByUsername(viewModel.Username);
            if (user != null)
            {
                if (user.Password == viewModel.Password)
                    return (user, "Đăng nhập thành công");
                else
                    return (user, "Tài khoản hoặc mật khẩu không chính xác");
            }
            else
                return (null,"Không tồn tại thông tin tài khoản trong hệ thống");
        }
    }
}
