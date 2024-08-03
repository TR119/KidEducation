using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidEducation.Core.ViewModel
{
    public class DashboardViewModel
    {
        public int TotalContact { get; set; }
        public int TotalContactToday { get; set; }
        public int TotalPost { get; set; }
        public int TotalVisitor { get; set; }
        public int TotalPostInMonth { get; set; }
        public int TotalVisitorToday{ get; set; }
        public List<ContactViewModel> ContactsToHandle { get; set; }
        public List<ContactViewModel> ContactsToday { get; set;}
    }
}
