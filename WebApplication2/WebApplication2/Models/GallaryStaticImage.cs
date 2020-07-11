using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class GallaryStaticImage
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idGallary { get; set; }
        public string imageURL { get; set; }
        public string shortDescreption { get; set; }
        public string Title { get; set; }
    }
}
