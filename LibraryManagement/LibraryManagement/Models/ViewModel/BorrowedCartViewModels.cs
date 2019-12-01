using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Models.ViewModel
{
    public class BorrowedCartViewModels
    {
        public List<Book> Books { get; set; }
        public Process Process { get; set; }
    }
}
