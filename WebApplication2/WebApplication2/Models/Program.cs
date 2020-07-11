using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public partial class Program
    {
        [Key]
        public int Idprogram { get; set; }
        public string PlayerId { get; set; }
        public string DateProgram { get; set; }
        public string CreateBy { get; set; }
        public string IsHidden { get; set; }
        public string MeasurementId { get; set; }
        public string FitnessTestId { get; set; }
        public string ProgramFormId { get; set; }
        public string LoadId { get; set; }
        public string WarmUpId { get; set; }
        public string UpperMachiensId { get; set; }
        public string LowerMachiensId { get; set; }
        public string ExtraId { get; set; }
        public string FootWorkId { get; set; }
        public string RecoveryId { get; set; }
        public string PoolId { get; set; }
        public string FinishId { get; set; }
    }
}
