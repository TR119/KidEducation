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
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;
        public ContactService(IContactRepository contactRepository,IMapper mapper)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
        }


        public async Task<JqueryDataTableResponse> GetByPaging(DataTableParamsRequest request, string status)
        {
            var response = new JqueryDataTableResponse { draw = request.Draw };
            var intStatus = !string.IsNullOrEmpty(status) ? int.Parse(EncryptDecrypt.Decrypt(status)) : 0;
            var models = await _contactRepository.GetPaging(request.ConvertToJqueryDataTableModel(), intStatus, response);
            response.data = _mapper.Map<ICollection<ContactViewModel>>(models);
            return response;
        }

        public async Task<ResponseJson> Create(ContactViewModel viewModel)
        {
            var response = new ResponseJson
            {
                Message = "Gửi yêu cầu thành công",
                Status = StatusCodes.Status200OK
            };
            var model = _mapper.Map<Contact>(viewModel);
            var isOk = await _contactRepository.Create(model);
            if (!isOk)
            {
                response.Message = "Gửi yêu cầu thất bại";
                response.Status = StatusCodes.Status500InternalServerError;
                return response;
            }
            return response;
        }

        public async Task<List<ContactViewModel>> GetAllContacts()
        {
            return _mapper.Map<List<ContactViewModel>>(await _contactRepository.GetAllContacts());  
        }

        public async Task<ResponseJson> Update(string id)
        {
            var response = new ResponseJson
            {
                Message = "Thành công",
                Status = StatusCodes.Status200OK
            };
            var contactId = int.Parse(EncryptDecrypt.Decrypt(id));
            var isOk = await _contactRepository.Update(contactId);
            if (!isOk)
            {
                response.Message = "Có lỗi xảy ra khi cập nhật";
                response.Status = StatusCodes.Status500InternalServerError;
                return response;
            }
            return response;
        }
    }
}
