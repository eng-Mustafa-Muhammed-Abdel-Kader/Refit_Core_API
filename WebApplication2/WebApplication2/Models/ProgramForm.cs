using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public partial class ProgramForm
    {
        [Key]
        public string ProgramFormId { get; set; }
        public string PlayerId { get; set; }
        public string CeratedBy { get; set; }
        public string Edurance { get; set; }
        public string Power { get; set; }
        public string Speed { get; set; }
        public string Agility { get; set; }
        public string Relex { get; set; }
        public string Flexbility { get; set; }
    }
}
