using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessDL.Models
{
    public class Equipment
    {
        public int Id { get; set; }
        public ICollection<DeviceType> DeviceTypes { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
        public string Description { get; set; }

    }
}
