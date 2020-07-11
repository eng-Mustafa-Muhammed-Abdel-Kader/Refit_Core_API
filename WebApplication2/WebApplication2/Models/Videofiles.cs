using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public partial class Videofiles
    {
        [Key]
        public int Vid { get; set; }
        public string Vname { get; set; }
        public string Vpath { get; set; }
        public int? Idplayer { get; set; }
        public int? CreateBy { get; set; }
    }
}
