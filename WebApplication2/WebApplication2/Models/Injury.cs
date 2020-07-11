using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class Injury
    {
        public int Id { get; set; }
        public string injury { get; set; }
        public string CeratedBy { get; set; }
        public string IsHidden { get; set; }
    }
}
