using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidEducation.Core.Model
{
    public class PopUp
    {
        public int Id { get; set; }
        public string? Image { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string? PopupName { get; set; }
        public string? Url { get; set; }
        public bool? Status { get; set; }
    }
}
