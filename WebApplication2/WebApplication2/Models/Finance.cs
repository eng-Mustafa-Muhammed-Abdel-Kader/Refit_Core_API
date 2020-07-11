using WebApplication2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    public partial class Finance
    {
        [Key]
        public int FinanceId { get; set; }
        public int Idplayer { get; set; }
        public string FullName { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string CreateBy { get; set; }
        public double? WantedPrice { get; set; }
        public double? Dept { get; set; }
        public double? Payed { get; set; }
        public string DateofRemainingprice { get; set; }
        public string Notes { get; set; }
        [ForeignKey(nameof(Idplayer))]
        public Players Players { get; set; }
    }
}
