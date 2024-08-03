using App.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidEducation.Core.Services
{
    public interface ITableConfigService
    {
        Task<ResponseJson> GetForDataTable(string tableName);
    }
}
