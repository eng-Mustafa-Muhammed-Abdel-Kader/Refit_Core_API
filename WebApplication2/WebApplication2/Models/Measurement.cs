using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class Measurement
    {
        public string MeasurementId { get; set; }
        public string PlayerId { get; set; }
        public string CeratedBy { get; set; }
        public string Weight { get; set; }
        public string Hight { get; set; }
        public string Mucles { get; set; }
        public string Fat { get; set; }
        public string Water { get; set; }
        public string Bmr { get; set; }
        public string MaxHr { get; set; }
        public string MinHr { get; set; }
        public string R1 { get; set; }
        public string R2 { get; set; }
        public string L1 { get; set; }
        public string L2 { get; set; }
        public string R1injure { get; set; }
        public string R2injure { get; set; }
        public string L1injure { get; set; }
        public string L2r1injure { get; set; }
    }
}
