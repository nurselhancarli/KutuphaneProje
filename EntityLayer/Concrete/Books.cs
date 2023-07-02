using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Books
    {
        [Key]
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string Outhor { get; set; }
        public string Photo { get; set; }
        public int StatusId { get; set; }
        public Status Status { get; set; }
    }
}
