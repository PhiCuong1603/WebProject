using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Models
{
    public class Book
    {
        [Key]
        public int BookID { get; set; }
        public string BookName { get; set; }
        public string BookImage { get; set; }

        public DateTime PublicationDate { get; set; }
       
        public string Note { get; set; }
       

        [ForeignKey("Author")]
        public int AuthorID { get; set; }
        public Author Author { get; set; }

        [ForeignKey("Category")]
        public int CategoryID { get; set; }
        public Category Category { get; set; }
       
    }
}
