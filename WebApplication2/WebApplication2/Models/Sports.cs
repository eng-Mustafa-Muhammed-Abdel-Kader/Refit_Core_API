using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public partial class Sports
    {
        [Key]
        public int Id { get; set; }
        public string SportName { get; set; }
        public string IsHidden { get; set; }
    }
}
