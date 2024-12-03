using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessBeheerEFlayer.Model;

public class EquipmentEF
{
    [Key]
    public int EquipmentId { get; set; }
    public List <string> DeviceType { get; set; } //Loopband of fiets, tot nu toee.
    public bool IsAvailable { get; set; }
    public ICollection<ReservationEF> Reservations { get; set; }
}
