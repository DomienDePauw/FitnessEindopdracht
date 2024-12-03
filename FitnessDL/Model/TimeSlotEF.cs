using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessBeheerEFlayer.Model;

public class TimeSlotEF
{
    [Key]
    public int TimeSlotId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string PartOfDay { get; set; }
    public ICollection<ReservationEF> Reservations { get; set; }
}
