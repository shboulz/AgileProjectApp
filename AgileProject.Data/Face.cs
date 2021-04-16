using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileProject.Data
{
    public class Face
    {
        [Key]
        public int FaceId { get; set; }

        [Required]
        public Guid CharFaceId { get; set; }

        [Required]
        public string FaceShape { get; set; }

        [Required]
        public string EyeShape { get; set; }

        [Required]
        public string EyeColor { get; set; }

        [Required]
        public string EyebrowShape { get; set; }

        [Required]
        public string Nose { get; set; }

        [Required]
        public string Mouth { get; set; }

        [Required]
        public string EarHeight { get; set; }





    }
}
