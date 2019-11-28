using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Models.ViewModel
{
    public class BookViewModel
    {
        public Book Books { get; set; }
        public IEnumerable<Author> Authors { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}
