using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessBeheerDomain.Model;
public class RunningSession
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public int Duration { get; set; }
    public int AvgSpeed { get; set; }
    //public Member Member { get; set; }
    //public List<RunningSessionDetail> Details { get; set; } = new();
}

