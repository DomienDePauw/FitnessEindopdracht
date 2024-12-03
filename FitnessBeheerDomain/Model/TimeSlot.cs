using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessBeheerDomain.Model;
public class TimeSlot
{
    public int Id { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string PartOfDay { get; set; }
    public List<Reservation> Reservations { get; set; } = new();
}

