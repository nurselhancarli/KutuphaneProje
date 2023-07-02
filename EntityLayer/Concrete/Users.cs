﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Users
    {
        [Key] 
        public int UserId { get; set; } 
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int BookId { get; set; }
        public Books Book { get; set; }
    }
}
