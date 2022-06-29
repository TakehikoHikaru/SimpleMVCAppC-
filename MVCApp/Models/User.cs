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
        public IList<Email> Email { get; set; }
        public PersonalPhone PersonalPhone { get; set; }
        public CommercialPhone CommercialPhone { get; set; }

    }
}
