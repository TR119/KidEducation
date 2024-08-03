using KidEducation.Core.Model;
using KidEducation.Core.Repositories;
using Microsoft.EntityFrameworkCore;


namespace KidEducation.Repository.Repositories
{
    public class TableConfigRepository:ITableConfigRepository
    {
        KidEducationDbContext _context;
        public TableConfigRepository(KidEducationDbContext context) 
        {
            _context = context;
        }

        public async Task<List<TableShowConfig>> GetConfigByName(string tableName)
        {
            return await _context.TableShowConfigs.Where(x => x.TableName == tableName && x.IsShow == true).OrderBy(x => x.ColumnSTT).ToListAsync();
        }
    }
}
