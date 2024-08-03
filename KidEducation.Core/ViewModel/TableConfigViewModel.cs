namespace KidEducation.Core.ViewModel
{
    public class TableConfigViewModel
    {
        public string ColumnID { get; set; }
        public string TableName { get; set; }
        public string ColumnName { get; set; }
        public string ColumnDescription { get; set; }
        public string ColumnWidth { get; set; }
        public short? ColumnDataType { get; set; }
        public short? ColumnSTT { get; set; }
        public bool? IsDefault { get; set; }
        public bool? IsShow { get; set; }
        public bool? IsSort { get; set; }
        public string ColumnAlign { get; set; }
    }

    public class TableConfigJQuery
    {
        public string ColumnName { get; set; }
        public string ColumnDescription { get; set; }
        public string ColumnWidth { get; set; }
        public int? ColumnDataType { get; set; }
        public string ColumnAlign { get; set; }
        public bool? IsSort { get; set; }
    }
}
