using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public partial class Sales
    {
        [Key]
        public int Id { get; set; }
        public string SalesName { get; set; }
        public string CeratedBy { get; set; }
        public string IsHidden { get; set; }
    }
}
