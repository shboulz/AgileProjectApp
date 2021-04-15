using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileProject.Models
{
    public class FaceCreate
    {
        [Required]
        [MinLength(4, ErrorMessage = "Must be one of the following face shapes: oval, round, heart, square.")]
        [MaxLength(6, ErrorMessage = "Must be one of the following face shapes: oval, round, heart, square.")]
        public string FaceShape { get; set;
        }
        [Required]
        [MinLength(4, ErrorMessage = "Must be one of the following eye shapes: oval, round, large, shallow, or small.")]
        [MaxLength(7, ErrorMessage = "Must be one of the following eye shapes: oval, round, large, shallow, or small.")]
        public string EyeShape { get; set; }

        [Required]
        [MinLength(4, ErrorMessage = "Must be one of the following eye colors: blue, green, brown, or black.")]
        [MaxLength(5, ErrorMessage = "Must be one of the following eye colors: blue, green, brown, or black.")]
        public string EyeColor { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "Must be one of the following eyebrow shapes: arched, straight, thick, short-arhced, short-straight, short-thick.")]
        [MaxLength(13, ErrorMessage = "Must be one of the following eyebrow shapes: arched, straight, thick, short-arhced, short-straight, short-thick.")]
        public string EyebrowShape { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Must be one of the following nose shapes: long, short, arched, pig, crooked.")]
        [MaxLength(7, ErrorMessage = "Must be one of the following nose shapes: long, short, arched, pig, crooked.")]
        public string Nose { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "Must be one of the following mouth shapes: large, small, sensual, manly.")]
        [MaxLength(7, ErrorMessage = "Must be one of the following mouth shapes: large, small, sensual, manly.")]
        public string Mouth { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Must be one of the following ear locations: low, medium, high.")]
        [MaxLength(6, ErrorMessage = "Must be one of the following ear locations: low, medium, high.")]
        public string EarHeight { get; set; }

    }
}
