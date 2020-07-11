using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class News
    {
        [Key]
        public int IDNews { get; set; }
        public string contentNews { get; set; }
        [Column("publishNews", TypeName = "Date")]
        public DateTime PublishNews { get; set; }
        public string imageNews { get; set; }
        public int isShow { get; set; }

        [ForeignKey(nameof(isShow))]
        public ShowNewsType ShowNewsType { get; set; }

    }
}
