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

        public DateTime BorrowedDate { get; set; }
       
        
    }
}
