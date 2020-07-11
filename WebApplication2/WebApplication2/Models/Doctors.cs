using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class Doctors
    {
        public int Id { get; set; }
        public string Drname { get; set; }
        public string CeratedBy { get; set; }
        public string IsHidden { get; set; }
    }
}
