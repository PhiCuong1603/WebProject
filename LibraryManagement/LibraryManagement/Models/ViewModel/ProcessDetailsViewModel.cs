using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Models.ViewModel
{
    public class ProcessDetailsViewModel
    {
        public Process Process { get; set; }
        public List<ApplicationUser> Librarian { get; set; }
        public List<Book> Books { get; set; }
    }
}
