using App.Domain.Primitives;
using AutoMapper;
using KidEducation.Core.Model;
using KidEducation.Core.Repositories;
using KidEducation.Core.Services;
using KidEducation.Core.ViewModel;
using KidEducation.Utilities.Sercurity;
using Microsoft.AspNetCore.Http;
using Slugify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidEducation.Services.Services
{
    public class PopupService : IPopupService
    {
        private readonly IPopupRepository _popupRepository;
        private readonly IMapper _mapper;
        public PopupService(IPopupRepository popupRepository, IMapper mapper)
        {
            _popupRepository = popupRepository;
            _mapper = mapper;
        }
        public async Task<ResponseJson> CreateOrUpdate(PopupViewModel viewModel, string subPath)
        {
            var response = new ResponseJson
            {
                Message = "Thêm popup thành công",
                Status = StatusCodes.Status200OK
            };

            if(viewModel.FileImage != null)
            {
                var config = new SlugHelperConfiguration();
                // Add individual replacement rules
                config.StringReplacements.Add("&", "-");
                config.StringReplacements.Add(",", "-");
                // Keep the casing of the input string
                config.ForceLowerCase = false;
                var helper = new SlugHelper(config);

                //Get extension of file upload
                string extension = Path.GetExtension(viewModel.FileImage.FileName);
                var filename = "/" + viewModel.Image + "_" + new Random().Next(1, 100) + extension;
                try
                {
                    //Save avatar to server (~Upload/Image/..)
                    using (var stream = new FileStream(subPath + filename, FileMode.Create))
                    {
                        await viewModel.FileImage.CopyToAsync(stream);
                    }
                }
                catch (Exception e)
                {
                    response.Status = StatusCodes.Status500InternalServerError;
                    response.Message = "Lỗi khi lưu file ";
                    return response;
                }
                viewModel.Image = filename;
            }
            
            var model = _mapper.Map<PopUp>(viewModel);
            var isOk = false;
            if (model.Id == 0)
                isOk= await _popupRepository.Create(model);
            else
                isOk= await _popupRepository.Update(model);
            if (!isOk)
            {
                response.Message = "Thêm popup thất bại";
                response.Status = StatusCodes.Status500InternalServerError;
                return response;
            }
            return response;
        }


        public async Task<PopupViewModel> GetPopup()
        {
            return _mapper.Map<PopupViewModel>(await _popupRepository.GetPopup());
        }

        public async Task<PopupViewModel> GetPopupToShow()
        {
            return _mapper.Map<PopupViewModel>(await _popupRepository.GetPopupToShow());
        }


        public async Task<ResponseJson> Update(PopupViewModel viewModel, string subPath)
        {
            var response = new ResponseJson
            {
                Message = "Cập nhật thành công",
                Status = StatusCodes.Status200OK
            };
            var model = _mapper.Map<PopUp>(viewModel);
            var isOk = await _popupRepository.Update(model);
            if (!isOk)
            {
                response.Message = "Cập nhật thất bại";
                response.Status = StatusCodes.Status500InternalServerError;
                return response;
            }
            return response;
        }
    }
}
