using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Models.ViewModel
{
    public class ProcessViewModel
    {
        public List<Process> Processes { get; set; }

        public PagingInfo PagingInfo { get; set; }
    }
}
