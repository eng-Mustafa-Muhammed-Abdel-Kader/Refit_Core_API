using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public partial class UpperMachiens
    {
        [Key]
        public string UpperMachiensId { get; set; }
        public string PlayerId { get; set; }
        public string CeratedBy { get; set; }
        public string General { get; set; }
        public string Chest { get; set; }
        public string Shoulderpress { get; set; }
        public string Back { get; set; }
        public string Biceps { get; set; }
        public string Triceps { get; set; }
        public string PuchUp { get; set; }
        public string PullUp { get; set; }
    }
}
