using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Models
{
    public class Client : EntityBase
    {
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(80)]
        public string Address { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string City { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int PostalCode { get; set; }

        [MinLength(3)]
        [MaxLength(60)]
        public string Country { get; set; }
    }
}
