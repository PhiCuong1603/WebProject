using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Models
{
    public class Process
    {
        [Key]
        public int ProcessID { get; set; }

        public DateTime BorrowedDate { get; set; }
        [NotMapped]
        public DateTime BorrowedTime { get; set; }

        public bool Complete { get; set; }

        [Display(Name = "Librarian")]
        public string LibrarianID { get; set; }

        [ForeignKey("LibrarianID")]
        public virtual ApplicationUser Librarian { get; set; }
        
        public int ReaderID { get; set; }

        [ForeignKey("ReaderID")]
        public virtual Reader Reader { get; set; }

        public ICollection<Borrowed> Borroweds { get; set; }

    }
}
