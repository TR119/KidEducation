using KidEducation.Core.Model;
using KidEducation.Core.Primitives;
using KidEducation.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Linq.Dynamic.Core;

namespace KidEducation.Repository.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly KidEducationDbContext _context;
        public PostRepository(KidEducationDbContext context)
        {
            _context = context;
        }

       
        public async Task<IEnumerable<Posts>> GetPaging(JqueryDataTableModels request, int status, JqueryDataTableResponse response)
        {
            var queryAble = _context.Posts.AsNoTracking();

            if (!request.Search.IsNullOrEmpty())
            {
                queryAble = queryAble.Where(x => x.Title.Contains(request.Search) || x.CreateBy.Contains(request.Search));
            }
            response.recordsTotal = response.recordsFiltered = await queryAble.CountAsync();
            return await queryAble.OrderBy(request.Order).Skip(request.Skip).Take(request.Take).AsNoTracking()
                .ToListAsync();
        }
        public async Task<bool> Create(Posts post)
        {
            _context.Posts.Add(post);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Posts> GetById(int id)
        {
            var post = await _context.Posts.AsNoTracking().Where(x => x.Id == id).FirstOrDefaultAsync();
            return post;
        }

        public async Task<bool> Update(Posts post)
        {
            _context.Update(post);
            return await _context.SaveChangesAsync() >0;
        }

        public async Task<bool> Delete(int id)
        {
            var model = _context.Posts.Where(p => p.Id == id).FirstOrDefault();
            _context.Posts.Remove(model);
            return await _context.SaveChangesAsync() > 0;
        }


        public async Task<bool> DeleteMulti(IEnumerable<int> ids)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    foreach (var id in ids)
                    {
                        var model = _context.Posts.Where(p => p.Id == id).FirstOrDefault();
                        _context.Posts.Remove(model);
                    }
                    await _context.SaveChangesAsync();
                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }

        public async Task<Posts> GetByUrl(string url)
        {
			var post = await _context.Posts.Where(x => x.Status == true && x.Url == url).FirstOrDefaultAsync();
            post.TotalViews++;
            _context.Update(post);
            await _context.SaveChangesAsync();
			return post;
        }

        public async Task<List<Posts>> GetNewPosts()
        {
            return await _context.Posts.AsNoTracking().Where(x=>x.Status== true).OrderByDescending(post => post.CreateDate).Take(3).ToListAsync();
        }

		public async Task<List<Posts>> GetAllPosts(string search, bool? status = true)
		{
            if(status == true)
            {
                return await _context.Posts.AsNoTracking().Where(x=>x.Status == true).OrderByDescending(post => post.CreateBy.Contains(search) || post.Title.Contains(search)).ToListAsync();
            }
            return await _context.Posts.AsNoTracking().OrderByDescending(post => post.CreateBy.Contains(search)|| post.Title.Contains(search)).ToListAsync();
		}

		public async Task<List<Posts>> GetMostViewsPosts()
		{
			return await _context.Posts.AsNoTracking().Where(x => x.Status == true).OrderByDescending(post => post.TotalViews).Take(3).ToListAsync();
		}
		
	}
}
