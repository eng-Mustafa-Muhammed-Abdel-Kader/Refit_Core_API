using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    public partial class WarmUp
    {
        [Key]
        public string WarmUpId { get; set; }
        public string PlayerId { get; set; }
        public string CeratedBy { get; set; }
        public string BikeTime { get; set; }
        public string HandBike { get; set; }
        public string TreadMaile { get; set; }
        public string StepperTime { get; set; }
        public string StebmasterTime { get; set; }
    }
}
