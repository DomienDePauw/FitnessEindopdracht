using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessBeheerDomain.Model;
public class RunningSessionDetail
{
    public int Id { get; set; }
    public int SequenceNumber { get; set; }
    public int IntervalTime { get; set; }
    public int IntervalSpeed { get; set; }
    //public RunningSession RunningSession { get; set; }
}

