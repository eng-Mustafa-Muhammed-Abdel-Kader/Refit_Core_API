using WebApplication2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    public partial class Attendance
    {
        [Key]
        public int AttendanceId { get; set; }
        public int? Idplayer { get; set; }
        public int? Iduser { get; set; }
        public string AttendanceDate { get; set; }

        [ForeignKey(nameof(Iduser))]
        public Users Users { get; set; }

        [ForeignKey(nameof(Idplayer))]
        public Players Players { get; set; }
    }
}
