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
    public int Id { get; set; }
    public EquipmentTypeEF Type { get; set; }
    public bool IsAvailable { get; set; }
    public ICollection<ReservationEF> Reservations { get; set; }
}
