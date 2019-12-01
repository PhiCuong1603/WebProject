using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Models
{
    public class Borrowed
    {
        [Key]
        public int BorrowedID { get; set; }

        [ForeignKey("Process")]
        public int ProcessID { get; set; }
        public virtual Process Process { get; set; }

        [ForeignKey("Book")]
        public int BookID { get; set; }
        public virtual Book Books { get; set; }
       
       
        
    }
}
