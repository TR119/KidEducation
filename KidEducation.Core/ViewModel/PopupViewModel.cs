using Microsoft.AspNetCore.Http;

namespace KidEducation.Core.ViewModel
{
    public class PopupViewModel
    {
        public string Id { get; set; }
        public string? Image { get; set; }
        public string? StartTime { get; set; }
        public string? EndTime { get; set; }
        public string? PopupName { get; set; }
        public string? Url { get; set; }
        public bool? Status { get; set; }
        public IFormFile? FileImage { get; set; }    
    }
}
