using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class ShowNewsType
    {
        [Key]
        public int typeID { get; set; }
        public string typeValue { get; set; }
        public ICollection<News> News { get; set; }
    }
}
