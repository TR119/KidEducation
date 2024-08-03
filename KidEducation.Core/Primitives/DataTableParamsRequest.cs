using KidEducation.Core.Model;
using KidEducation.Core.ViewModel;


namespace KidEducation.Core.Primitives
{
    public class DataTableParamsRequest
    {
        public int Draw { get; set; }
        public int Start { get; set; }
        public int Length { get; set; }
        public List<ColumnRequestItem> Columns { get; set; }
        public List<OrderRequestItem> Order { get; set; }
        public SearchRequestItem Search { get; set; }
        public object FilterData { get; set; }
    }

    public class ColumnRequestItem
    {
        public string Data { get; set; }
        public string Name { get; set; }
        public bool Searchable { get; set; }
        public bool Orderable { get; set; }
        public SearchRequestItem Search { get; set; } = new SearchRequestItem();
    }

    public class OrderRequestItem
    {
        public int Column { get; set; }
        public string Dir { get; set; }
    }

    public class SearchRequestItem
    {
        public string Value { get; set; }
        public bool Regex { get; set; }
    }

    public class JqueryDataTableResponse
    {
        public int draw { get; set; }
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }
        public object data { get; set; } 
        public string error { get; set; }
    }

    public class JqueryDataTableModels
    {
        public int Skip { get; set; }
        public int Take { get; set; }
        public string Order { get; set; }
        public string Search { get; set; }
    }
    public static class JqueryDatatableDataHelper
    {
        /*public static string GetColConfigJson(List<HeThong_TableConfig> listColConfig)
        {
            return JsonConvert.SerializeObject(listColConfig
                .Select(x => new { x.ColumnName, x.ColumnDataType, x.ColumnAlign, x.ColumnDescription }).ToList());
        }

        public static string GetColConfigJson(List<TableConfigViewModel> listColConfig) => JsonConvert.SerializeObject(listColConfig
            .Select(x => new { x.ColumnName, x.ColumnDataType, x.ColumnAlign, x.ColumnDescription }).ToList());

        public static async Task<List<HeThong_TableConfig>> GetColConifg(string tableName)
        {
            try
            {
                return await new TableConfigService().GetForDataTable(tableName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }*/

        public static JqueryDataTableModels ConvertToJqueryDataTableModel(this DataTableParamsRequest request)
        {
            var models = new JqueryDataTableModels();
            models.Skip = request.Start;
            models.Take = request.Length;
            models.Search = request.Search.Value;
            models.Order = request.Order == null ? "1" : request.Columns[request.Order[0].Column].Data
                                                         + (request.Order[0].Dir.Equals("desc") ? " descending" : "");
            return models;
        }
    }


}
