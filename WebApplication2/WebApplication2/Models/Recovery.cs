using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public partial class Recovery
    {
        [Key]
        public string RecoveryId { get; set; }
        public string PlayerId { get; set; }
        public string CreateBy { get; set; }
        public string Massage { get; set; }
        public string Sauna { get; set; }
        public string Steam { get; set; }
        public string Jacouzy { get; set; }
        public string IceBath { get; set; }
    }
}
