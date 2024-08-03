using KidEducation.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidEducation.Core.Repositories
{
    public interface ITableConfigRepository
    {
        Task<List<TableShowConfig>> GetConfigByName(string tableName);
    }
}
