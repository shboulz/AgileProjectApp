using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileProject.Models
{
    public class BodyCreate
    {
        [Required]
        [MinLength(3, ErrorMessage = "Must be one of the following: Fit, Muscular, Skinny, Round, Bulky")]
        [MaxLength(8, ErrorMessage = "Must be one of the following: Fit, Muscular, Skinny, Round, Bulky")]
        public string BodyType { get; set; }

        [MaxLength(8000)]
        public string BodyDescription { get; set; }

    }
}
