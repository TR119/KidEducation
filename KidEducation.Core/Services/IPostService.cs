using App.Domain.Primitives;
using KidEducation.Core.Model;
using KidEducation.Core.Primitives;
using KidEducation.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidEducation.Core.Services
{
    public interface IPostService
    {
        Task<JqueryDataTableResponse> GetByPaging(DataTableParamsRequest request, string status);
        Task<ResponseJson> Create(PostViewModel viewModel,string subPath);
        Task<PostViewModel> GetById(string id);
        Task<ResponseJson> Update(PostViewModel viewModel, string subPath);
        Task<ResponseJson> Delete(string id);
        Task<ResponseJson> DeleteMulti(IEnumerable<string> ids);
        Task<PostViewModel> GetByUrl(string url);
        Task<List<PostViewModel>> GetNewPosts();
        Task<List<PostViewModel>> GetMostViewsPosts();
		Task<List<PostViewModel>> GetAllPosts(string search, bool? status);

	}
}
