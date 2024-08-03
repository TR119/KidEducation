using App.Domain.Primitives;
using AutoMapper;
using KidEducation.Core.Model;
using KidEducation.Core.Primitives;
using KidEducation.Core.Repositories;
using KidEducation.Core.Services;
using KidEducation.Core.ViewModel;
using KidEducation.Utilities.Sercurity;
using Microsoft.AspNetCore.Http;
using Slugify;
using System.Security.Claims;

namespace KidEducation.Services.Services
{
    public class PostServices : IPostService
    {
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IPostRepository _postRepository;
        public PostServices(IPostRepository postRepositoy,IMapper mapper,IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _postRepository = postRepositoy;
            _mapper = mapper;
        }

        public async Task<JqueryDataTableResponse> GetByPaging(DataTableParamsRequest request, string status)
        {
            var response = new JqueryDataTableResponse { draw = request.Draw };
            var intStatus = !string.IsNullOrEmpty(status) ? int.Parse(EncryptDecrypt.Decrypt(status)) : 0;
            var models = await _postRepository.GetPaging(request.ConvertToJqueryDataTableModel(), intStatus, response);
            response.data = _mapper.Map<ICollection<ListPostViewModel>>(models);
            return response;
        }

        public async Task<ResponseJson> Create(PostViewModel viewModel, string subPath)
        {
            var response = new ResponseJson
            {
                Message = "Tạo bài viết thành công",
                Status = StatusCodes.Status200OK
            };

            var config = new SlugHelperConfiguration();
            // Add individual replacement rules
            config.StringReplacements.Add("&", "-");
            config.StringReplacements.Add(",", "-");
            // Keep the casing of the input string
            config.ForceLowerCase = false;
            var helper = new SlugHelper(config);

            //Get extension of file upload
            string extension = Path.GetExtension(viewModel.ThumnailFile.FileName);
            var filename = helper.GenerateSlug(viewModel.Title) + "-" + new Random().Next(1, 100) + extension;

            try
            {
                //Save avatar to server (~Upload/Image/..)
                using (var stream = new FileStream(subPath +"/"+ filename, FileMode.Create))
                {
                    await viewModel.ThumnailFile.CopyToAsync(stream);
                }
            }
            catch (Exception e)
            {
                response.Status = StatusCodes.Status500InternalServerError;
                response.Message = "Lỗi khi lưu file thumnail";
                return response;
            }

            if (string.IsNullOrEmpty(viewModel.CreateDate))
                viewModel.CreateDate = DateTime.Now.ToString("dd/MM/yyyy");
            if (string.IsNullOrEmpty(viewModel.CreateBy))
            {
                viewModel.CreateBy = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.Name).Value;
            }
            if (string.IsNullOrEmpty(viewModel.Url))
                viewModel.Url = helper.GenerateSlug(viewModel.Title);
            viewModel.Thumnail = filename;
            viewModel.UpdateDate = viewModel.CreateDate;

            var model = _mapper.Map<Posts>(viewModel);
            var isOk = await _postRepository.Create(model);
            if (!isOk)
            {
                response.Message = "Thêm mới bài viết thất bại";
                response.Status = StatusCodes.Status500InternalServerError;
                return response;
            }
            return response;
        }

        public async Task<PostViewModel> GetById(string id)
        {
            int postId = int.Parse(EncryptDecrypt.Decrypt(id));
            return _mapper.Map<PostViewModel>(await _postRepository.GetById(postId));
        }

        public async Task<ResponseJson> Update(PostViewModel viewModel, string subPath)
        {
            var response = new ResponseJson
            {
                Message = "Cập nhật bài viết thành công",
                Status = StatusCodes.Status200OK
            };

            var config = new SlugHelperConfiguration();
            // Add individual replacement rules
            config.StringReplacements.Add("&", "-");
            config.StringReplacements.Add(",", "-");
            // Keep the casing of the input string
            config.ForceLowerCase = false;
            var helper = new SlugHelper(config);


            if (viewModel.ThumnailFile != null)
            {
                //Get extension of file upload
                string extension = Path.GetExtension(viewModel.ThumnailFile.FileName);
                var filename = helper.GenerateSlug(viewModel.Title) + "-" + new Random().Next(1, 100) + extension;

                try
                {
                    using (var stream = new FileStream(subPath + "\\" + filename, FileMode.Create))
                    {
                        await viewModel.ThumnailFile.CopyToAsync(stream);
                    }

                }
                catch (Exception e)
                {
                    response.Status = StatusCodes.Status500InternalServerError;
                    response.Message = "Lỗi khi lưu file thumnail";
                    return response;
                }
                viewModel.Thumnail = filename;

            }

            viewModel.UpdateDate = DateTime.Now.ToString("dd/MM/yyyy");
            var claim = 

            viewModel.UpdateBy = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.Name).Value;
            if (string.IsNullOrEmpty(viewModel.Url))
                viewModel.Url = helper.GenerateSlug(viewModel.Title);
            var model = _mapper.Map<Posts>(viewModel);
            var isOk = await _postRepository.Update(model);
            if (!isOk)
            {
                response.Message = "Cập nhật bài viết thất bại";
                response.Status = StatusCodes.Status500InternalServerError;
                return response;
            }
            return response;
        }

        public async Task<ResponseJson> Delete(string id)
        {
            var response = new ResponseJson
            {
                Message = "Xóa bài viết thành công",
                Status = StatusCodes.Status200OK
            };
            int postId = int.Parse(EncryptDecrypt.Decrypt(id));
            var isOk = await _postRepository.Delete(postId);
            if (!isOk)
            {
                response.Status = StatusCodes.Status500InternalServerError;
                response.Message = "Xóa bài viết không thành công";
            }
            return response;
        }

        public async Task<ResponseJson> DeleteMulti(IEnumerable<string> idsEncrpt)
        {
            var response = new ResponseJson
            {
                Message = "Xóa bài viết thành công",
                Status = StatusCodes.Status200OK
            };
            var ids = new List<int>();
            foreach (var id in idsEncrpt)
            {
                var postId = int.Parse(EncryptDecrypt.Decrypt(id));
                ids.Add(postId);
            }

            var isOk = await _postRepository.DeleteMulti(ids);
            if (!isOk)
            {
                response.Status = StatusCodes.Status500InternalServerError;
                response.Message = "Xóa bài viết không thành công";
            }
            return response;
        }

        public async Task<PostViewModel> GetByUrl(string url)
        {
            return _mapper.Map<PostViewModel>(await _postRepository.GetByUrl(url));
        }

        public async Task<List<PostViewModel>> GetNewPosts()
        {
            return _mapper.Map<List<PostViewModel>>(await _postRepository.GetNewPosts());
        }

		public async Task<List<PostViewModel>> GetAllPosts(string search, bool? status)
		{
			return _mapper.Map<List<PostViewModel>>(await _postRepository.GetAllPosts(search, status));
		}

		public async Task<List<PostViewModel>> GetMostViewsPosts()
		{
			return _mapper.Map<List<PostViewModel>>(await _postRepository.GetMostViewsPosts());
		}
	}
}
