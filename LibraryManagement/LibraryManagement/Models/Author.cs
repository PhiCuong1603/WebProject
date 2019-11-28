﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Models
{
    public class Author
    {

        [Key]
        public int AuthorID { get; set; }
        [Required]
        public string AuthorName { get; set; }
        public string Note { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
