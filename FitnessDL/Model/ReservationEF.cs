using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessBeheerEFlayer.Model;

public class ReservationEF
{
    [Key]
    public int Id { get; set; }
    public int EquipmentId { get; set; }
    public EquipmentEF Equipment { get; set; }
    public TimeSlotEF TimeSlot { get; set; }
    public DateOnly Date { get; set; }
    public int MemberId { get; set; }
    public MemberEF Member { get; set; }
}

