using KidEducation.Core.Model;
using KidEducation.Core.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidEducation.Core.Repositories
{
    public interface IPopupRepository
    {
        Task<PopUp> GetPopup();
        Task<PopUp> GetPopupToShow();
        Task<bool> Create(PopUp post);
        Task<bool> Update(PopUp post);
    }
}
