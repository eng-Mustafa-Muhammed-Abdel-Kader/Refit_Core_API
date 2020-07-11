using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Players
    {

        [Key]
        public int IDPlayer { get; set; } = 1;
#nullable enable
        [Required]
        public string? FullName { get; set; }
#nullable enable
        public string? Mail { get; set; }
#nullable enable
        public string? DateOfBearth { get; set; }
#nullable enable
        public string? Age { get; set; }
#nullable enable
        public string? StartDate { get; set; }
#nullable enable
        public string? Condition { get; set; }
#nullable enable
        public int? ConditionID { get; set; }
#nullable enable
        public string? Mobile1 { get; set; }
#nullable enable
        public string? Mobile2 { get; set; }
#nullable enable
        [MinLength(10, ErrorMessage = "Please Write Your Full Name")]
        public string? PlayerJob { get; set; }
#nullable enable
        [DefaultValue("null")]
        public string? Sport { get; set; }
#nullable enable
        public string? Clup { get; set; }
#nullable enable
        public string? Doctor { get; set; }
#nullable enable
        [Required]
        public string? DateOfRehabe { get; set; }
#nullable enable
        [Required]
        public string? DateOfOpration { get; set; }
#nullable enable
        public string? Opration { get; set; }
#nullable enable
        public string? SallesID { get; set; }
#nullable enable
        public string? NameKnown { get; set; }
#nullable enable
        public string? Image { get; set; }
#nullable enable
        [Required]
        public string? CreateBy { get; set; }
#nullable enable
        public string? IsHidden { get; set; }
#nullable enable
        public bool? HaveFinance { get; set; }
        [Required]
#nullable enable
        public bool? HaveDept { get; set; }

        public ICollection<Attendance> Attendances { get; set; }
        public ICollection<DoctorsAppointment> DoctorsAppointments { get; set; }
        public ICollection<Finance> Finances { get; set; }
        public ICollection<Load> Loads { get; set; }
        public ICollection<GallaryGym> GallaryGyms { get; set; }
    }
}
