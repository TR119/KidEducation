using App.Domain.Primitives;
using AutoMapper;
using KidEducation.Core.Repositories;
using KidEducation.Core.Services;
using KidEducation.Core.ViewModel;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidEducation.Services.Services
{
    public class TableConfigService : ITableConfigService
    {
        private readonly IMapper _mapper;
        private readonly ITableConfigRepository _tableConfigRepository;
        public TableConfigService( IMapper mapper, ITableConfigRepository tableConfigRepository)
        {
            _tableConfigRepository = tableConfigRepository;
            _mapper = mapper;
        }

        public async Task<ResponseJson> GetForDataTable(string tableName)
        {
            var response = new ResponseJson
            {
                Status = StatusCodes.Status200OK,
                Message = "Thành công"
            };
            var listColumnView = await _tableConfigRepository.GetConfigByName(tableName);
            response.Data = _mapper.Map<List<TableConfigJQuery>>(listColumnView.OrderBy(x => x.ColumnSTT).ToList());
            return response;
        }
    }
}
