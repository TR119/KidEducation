using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidEducation.Core.ViewModel
{
    public class ListPostViewModel
    {
        public string Id { get; set; }
        public string? Title { get; set; }
        public string? CreateBy { get; set; }
        public string? UpdateDate { get; set; }
        public int? TotalViews { get; set; }
        public bool? Status { get; set; } //true: display, false:hide
    }

    public class PostViewModel
    {
        public string? Id { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tiêu đề")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập nội dung")]
        public string? Content { get; set; }
        public IFormFile? ThumnailFile { get; set; }
        public string? Thumnail { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập mô tả")]
        public string? Description { get; set; }
        public string? CreateBy { get; set; }
        public string? UpdateBy { get; set; }
        public string? UpdateDate { get; set; }
        public string? CreateDate { get; set; }
        public string? Url{ get; set; }
        public int TotalViews { get; set; }
        public string? MetaKeyword { get; set; }
        public bool Status { get; set; } = true;
    }

    public class PostCardViewModel
    {
        public string? Title { get; set; }
        public string? Thumnail { get; set; }
        public string? Description { get; set; }
        public string? CreateDate { get; set; }
        public string? Slug { get; set; }
    }


    public class PostDetailViewModel
    {
        public string? Title { get; set; }
        public string? CreateBy { get; set; }
        public string? CreateDate { get; set; }
        public string? Description { get; set; }
        public string? Content { get; set; }
        public int TotalViews { get; set; }
        public string? Slug { get; set; }
        public string? MetaKeyword { get; set; }
        public List<RelatedPostsViewModel> listRelated { get; set; }
    }

    public class RelatedPostsViewModel
    {
        public string? Title { get; set; }
        public string? Thumnail { get; set; }
        public string? Description { get; set; }
        public string? Url { get; set; }
    }
}
