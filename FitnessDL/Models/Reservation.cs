using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessDL.Models
{
    public class Reservation
    {
        [Key]
        public int ReservationId { get; set; }
        public int MemberId { get; set; }
        public Member Member { get; set; }
        public int EquipmentId { get; set; }
        public Equipment Equipment { get; set; }
        public int TimeSlotId { get; set; }
        public TimeSlot TimeSlot { get; set; }
        public DateTime Date { get; set; }
    }
}
