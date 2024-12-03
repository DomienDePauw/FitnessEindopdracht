using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessBeheerEFlayer.Model;
public class RunningSessionEF
{
    [Key]
    public int RunningSessionId { get; set; }
    public DateTime Date  { get; set; } 
    public int Duration { get; set; }
    public int Avg_Speed { get; set; }
    public MemberEF Member { get; set; }
    public ICollection<RunningSessionDetailEF> Details { get; set; }
}
