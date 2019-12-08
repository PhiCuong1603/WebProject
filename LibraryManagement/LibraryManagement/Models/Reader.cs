using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Models
{
    public class Reader
    {
        [Key]
        public int ReaderID { get; set; }
        public string Status { get; set; }
        public string ReaderName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
