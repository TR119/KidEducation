using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidEducation.Core.ViewModel
{
    public class AccountViewModel
    {
        public string Id {  get; set; }
        [Required(ErrorMessage ="Nhập thông tin")]
        public string Fullname { get; set; }
        [Required(ErrorMessage = "Nhập thông tin")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Nhập thông tin")]
        public string Password { get; set; }
    }
}
