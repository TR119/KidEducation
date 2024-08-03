using KidEducation.Core.Model;
using KidEducation.Core.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidEducation.Core.Repositories
{
    public interface IPostRepository
    {
        Task<IEnumerable<Posts>> GetPaging(JqueryDataTableModels request, int status, JqueryDataTableResponse response);
        Task<bool> Create(Posts post);
        Task<Posts> GetById(int id);
        Task<bool> Update(Posts post);  
        Task<bool> Delete(int id);
        Task<bool> DeleteMulti(IEnumerable<int> id);
        Task<Posts> GetByUrl(string url);
        Task<List<Posts>> GetNewPosts();
        Task<List<Posts>> GetMostViewsPosts();
		Task<List<Posts>> GetAllPosts(string search, bool? status);
	}
}
