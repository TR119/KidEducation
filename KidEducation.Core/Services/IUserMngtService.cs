using App.Domain.Primitives;
using KidEducation.Core.Primitives;
using KidEducation.Core.ViewModel;

namespace KidEducation.Core.Services
{
    public interface IUserMngtService
    {
        Task<JqueryDataTableResponse> GetByPaging(DataTableParamsRequest request, string status);
        Task<ResponseJson> Create(AccountViewModel viewModel);
        Task<ResponseJson> Update(AccountViewModel viewModel);
        Task<ResponseJson> Delete(string id);
    }
}
