using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessBeheerDomain.Model;
public class Reservation
{
    public int Id { get; set; }
    public Equipment Equipment { get; set; }
    public TimeSlot TimeSlot { get; set; }
    public DateTime Date { get; set; }
    public Member Member { get; set; }
}

