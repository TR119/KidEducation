using App.Domain.Primitives;
using AutoMapper;
using KidEducation.Core.Model;
using KidEducation.Core.Primitives;
using KidEducation.Core.Repositories;
using KidEducation.Core.Services;
using KidEducation.Core.ViewModel;
using KidEducation.Utilities.Sercurity;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidEducation.Services.Services
{
    public class UserMngtService : IUserMngtService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;
        public UserMngtService(IAccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        public async Task<ResponseJson> Create(AccountViewModel viewModel)
        {
            var response = new ResponseJson
            {
                Message = "Thêm người dùng thành công",
                Status = StatusCodes.Status200OK
            };
            var model = _mapper.Map<Account>(viewModel);
            var isOk = await _accountRepository.Create(model);
            if (!isOk)
            {
                response.Message = "Thêm người dùng thất bại";
                response.Status = StatusCodes.Status500InternalServerError;
                return response;
            }
            return response;
        }

        public async Task<ResponseJson> Delete(string id)
        {
            var response = new ResponseJson
            {
                Message = "Xóa người dùng thành công",
                Status = StatusCodes.Status200OK
            };
            int accountId = int.Parse(EncryptDecrypt.Decrypt(id));
            var isOk = await _accountRepository.Delete(accountId);
            if (!isOk)
            {
                response.Status = StatusCodes.Status500InternalServerError;
                response.Message = "Xóa người dùng không thành công";
            }
            return response;
        }

        public async Task<JqueryDataTableResponse> GetByPaging(DataTableParamsRequest request, string status)
        {
            var response = new JqueryDataTableResponse { draw = request.Draw };
            var intStatus = !string.IsNullOrEmpty(status) ? int.Parse(EncryptDecrypt.Decrypt(status)) : 0;
            var models = await _accountRepository.GetPaging(request.ConvertToJqueryDataTableModel(), intStatus, response);
            response.data = _mapper.Map<ICollection<AccountViewModel>>(models);
            return response;
        }

        public async Task<ResponseJson> Update(AccountViewModel viewModel)
        {
            var response = new ResponseJson
            {
                Message = "Thêm người dùng thành công",
                Status = StatusCodes.Status200OK
            };
            var model = _mapper.Map<Account>(viewModel);
            var isOk = await _accountRepository.Update(model);
            if (!isOk)
            {
                response.Message = "Thêm người dùng thất bại";
                response.Status = StatusCodes.Status500InternalServerError;
                return response;
            }
            return response;
        }
    }
}
