using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileProject.Models
{
    public class BodyDetail
    {
        public int BodyId { get; set; }
        
        public string BodyType { get; set; }
        
        public string BodyDescription { get; set; }
        
        public Guid CharBodyId { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
