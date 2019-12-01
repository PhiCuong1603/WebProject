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

        public string ReaderName { get; set; }
        public string ReaderPhoneNumber { get; set; }
        public string ReaderEmail { get; set; }

        public bool Complete { get; set; }

      
        //public string LibrarianID { get; set; }

        //[ForeignKey("LibrarianID")]
        //public virtual ApplicationUser Librarian { get; set; }

        //[ForeignKey("Reader")]
        //public int ReaderID { get; set; }       
        //public ICollection<Borrowed> Borrowed { get; set; }
       
    }
}
