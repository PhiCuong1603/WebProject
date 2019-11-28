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

        [ForeignKey("Borrowed")]
        public int BorrowedID { get; set; }
        public Borrowed Borrowed { get; set; }
        [ForeignKey("Book")]
        public int BookID { get; set; }
        public Book Book { get; set; }
        public bool Complete { get; set; }

        public DateTime CompleteDate { get; set; }
        public string Note { get; set; }
    }
}
