using WebApplication2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    public partial class Load
    {
        [Key]
        public string LoadId { get; set; }
        public int PlayerId { get; set; }
        public string CeratedBy { get; set; }
        public string LoadData { get; set; }

        [ForeignKey(nameof(PlayerId))]
        public Players Players { get; set; }
    }
}
