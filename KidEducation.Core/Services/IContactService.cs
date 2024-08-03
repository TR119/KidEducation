using App.Domain.Primitives;
using KidEducation.Core.Primitives;
using KidEducation.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidEducation.Core.Services
{
    public interface IContactService
    {
        Task<JqueryDataTableResponse> GetByPaging(DataTableParamsRequest request, string status);
        Task<List<ContactViewModel>> GetAllContacts();
        Task<ResponseJson> Create(ContactViewModel viewModel);
        Task<ResponseJson> Update(string id);
    }
}
