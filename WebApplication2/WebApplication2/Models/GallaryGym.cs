using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class GallaryGym
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int gallaryID { get; set; }
        public string imagePath { get; set; }
        public int playerID { get; set; }
        public int FileType { get; set; }

        [ForeignKey(nameof(playerID))]
        public Players Player { get; set; }
    }
}
