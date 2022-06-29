using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCApp.Models
{
    public class Phone
    {
        [Key]
        public String Id { get; set; }
        public int DDD { get; set; }
        public int DDI { get; set; }
        public int Number { get; set; }

    }
}
