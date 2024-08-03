using System.ComponentModel.DataAnnotations;

namespace KidEducation.Core.Model
{
    public class Posts
    {
        [Key]
        public int Id { get; set; }
        [StringLength(250)]
        public string? Title { get; set; }
        [StringLength(250)]
        public string? Thumnail { get; set; }
        [MaxLength]
        public string? Content { get; set; }
        [StringLength(250)]
        public string? Description { get; set; }
        [StringLength(100)]
        public string? CreateBy { get; set; }
        [StringLength(100)]
        public string? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? CreateDate { get; set; } = DateTime.Now;
        public string? Url { get; set; }
        public int? TotalViews { get; set; }
        [StringLength(250)]
        public string? MetaKeyword { get; set; }
        public bool? Status { get; set; } //true: display, false:hid
    }
}
