using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileProject.Data
{
    public class Body
    {
        [Key]
        public int BodyId { get; set; }

        [Required]
        public string BodyType { get; set; }

        [Required]
        public string BodyDescription { get; set; }

        [Required]
        public Guid CharBodyId { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }

    }
}
