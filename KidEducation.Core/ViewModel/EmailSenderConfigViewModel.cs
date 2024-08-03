using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidEducation.Core.ViewModel
{
    public class EmailSenderConfigViewModel
    {
        public string? Id { get; set; }
        public string? EmailId { get; set; }
        public string? EmailToId { get; set; }
        public string? Name { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Host { get; set; }
        public string? Port { get; set; }
        public bool UseSSL { get; set; }
    }
}
