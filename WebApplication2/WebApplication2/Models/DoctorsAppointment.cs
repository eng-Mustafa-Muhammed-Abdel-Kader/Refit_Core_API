using WebApplication2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class DoctorsAppointment
    {

        public int ID { get; set; }
        public string DrName { get; set; }
        public string Date { get; set; }
        public int IDPlayer { get; set; }
        public int Trainer { get; set; }

        [ForeignKey(nameof(IDPlayer))]
        public Players Players { get; set; }

        [ForeignKey(nameof(Trainer))]
        public Users Users { get; set; }
    }
}
