using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessBeheerEFlayer.Model;

public class CyclingSessionEF
{
    [Key]
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public int Duration { get; set; }
    public int Avg_Watt { get; set; }
    public int Max_Watt { get; set; }
    public int Avg_Cadence { get; set; }
    public int Max_Cadence { get; set; }
    public string TrainingType { get; set; }
    public string? Comment { get; set; }
    public MemberEF Member { get; set; }
}
