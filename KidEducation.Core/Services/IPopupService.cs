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
    public interface IPopupService
    {
        Task<ResponseJson> CreateOrUpdate(PopupViewModel viewModel, string subPath);
        Task<PopupViewModel> GetPopup();
        Task<PopupViewModel> GetPopupToShow();
        Task<ResponseJson> Update(PopupViewModel viewModel, string subPath);
    }
}
