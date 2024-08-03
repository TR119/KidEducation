using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidEducation.Core.Model
{
    public class TableShowConfig
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string? TableName { get; set; }
        [StringLength(50)]
        public string? ColumnName { get; set; }
        [StringLength(255)]
        public string? ColumnDescription { get; set; }
        public string? ColumnWidth { get; set; }
        public int? ColumnDataType { get; set; }
        public int? ColumnSTT { get; set; }
        public bool? IsDefault { get; set; }
        public bool? IsShow { get; set; }
        public bool? IsSort { get; set; }
        [StringLength(50)]
        public string? ColumnAlign { get; set; }
    }
}
