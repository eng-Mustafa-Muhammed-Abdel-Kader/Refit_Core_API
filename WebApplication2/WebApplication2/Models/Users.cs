using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public partial class Users
    {
        [Key]
        public int Iduser { get; set; }
        public string FullName { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public string Mobile1 { get; set; }
        public string Mobile2 { get; set; }
        public int Privilage { get; set; }
        public string IsHidden { get; set; }
        public string CreateBy { get; set; }

        public ICollection<Attendance> Attendances{ get; set; }
        public ICollection<DoctorsAppointment> DoctorsAppointments { get; set; }
    }
}
