using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessBeheerDomain.Model;
public class Equipment
{
    public int Id { get; set; }
    public List<string> DeviceTypes { get; set; } = new ();
    public bool IsAvailable { get; set; }
    public List<Reservation> Reservations { get; set; } = new();
}

