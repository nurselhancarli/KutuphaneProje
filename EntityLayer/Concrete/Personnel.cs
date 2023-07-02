using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Personnel
    {
        [Key]
        public int PersonnelId { get; set; }
        public string PersonnelName { get; set; }
        public string PersonnelSurname { get; set; }
        public string PersonnelMail{ get; set;}
        public string PersonnelPassword { get; set;}
        public string PersonnelUsername { get; set;}
    }
}
