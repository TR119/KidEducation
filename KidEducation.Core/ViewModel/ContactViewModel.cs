using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidEducation.Core.ViewModel
{
    public class ContactViewModel
    {
        public string Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Message { get; set; }
        public string? CreatedDate { get; set; }
        public string? Service { get; set; }
        public string? Status { get; set; }  
    }
}
