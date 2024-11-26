using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessDL.Models;

public class Equipment
{
    [Key]
    public int EquipmentId { get; set; }
    public string DeviceType { get; set; } //Loopband of fiets, moet dit geen list zijn? 
    public bool IsAvailable { get; set; }
    public ICollection<Reservation> Reservations { get; set; }

}
