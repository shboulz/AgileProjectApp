using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileProject.Models
{
    public class FaceEdit
    {
        public int FaceId { get; set; }
        public Guid CharFaceId { get; set; }
        public string FaceShape { get; set; }
        public string EyeShape { get; set; }
        public string EyeColor { get; set; }
        public string EyebrowShape { get; set; }
        public string Nose { get; set; }
        public string Mouth { get; set; }
        public string EarHeight { get; set; }
    }
}
