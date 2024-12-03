using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessBeheerEFlayer.Model;
public class RunningSessionDetailEF
{
    [Key]
    public int Id { get; set; }
    public int Seq_nr { get; set; }
    public int Interval_Time { get; set; }
    public int Interval_Speed { get; set; }
    public RunningSessionEF RunningSession { get; set; }
}
