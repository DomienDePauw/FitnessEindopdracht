using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessDL.Models;

public class CyclingSession
{
    //Required datanotations
    [Key]
    public int CyclingSessionId { get; set; }
    public DateTime Date { get; set; }
    public int Duration { get; set; }
    public int Avg_Watt { get; set; }
    public int Max_Watt { get; set; }
    public int Avg_Cadence { get; set; }
    public int MAx_Cadence { get; set; }
    public string TrainingType { get; set; }
    public string Comment { get; set; }

}
