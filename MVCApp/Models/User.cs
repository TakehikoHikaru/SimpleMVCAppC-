using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCApp.Models
{
    public class User
    {
        [Key]
        public String Id { get; set; }
        [Required(ErrorMessage = "Nome é um campo obrigatório")]
        public String Name { get; set; }
        public String Company { get; set; }
        public Email Email { get; set; }
        public int PersonalPhoneDDD { get; set; }
        [MaxLength(3)]
        public int PersonalPhoneDDI { get; set; }
        public int PersonalPhoneNumber { get; set; }
        public int CommercialPhoneDDD { get; set; }
        [MaxLength(3)]
        public int CommercialPhoneDDI { get; set; }
        public int CommercialPhoneNumber { get; set; }

    }
}
