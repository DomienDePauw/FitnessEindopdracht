using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessDL.Models
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public ICollection<Equipment> Equipments { get; set; } //Relatie met Equipement
        public ICollection<TimeSlot> TimeSlots { get; set; } //Relatie met TimeSlot
        public DateTime Date { get; set; }
        public ICollection<Members> Members { get; set; } //Relatie met Memebers, Klanten kunnen reservaties maken


    }
}
