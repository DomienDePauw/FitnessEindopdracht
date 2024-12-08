using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessBeheerDomain.Model;
public class FitnessProgram
{
    public FitnessProgram()
    {
        
    }
    public FitnessProgram(int programCode,string name, string target, DateTime startDate, int maxMembers)
    {
        ProgramCode = programCode;
        Name = name;
        Target = target;
        StartDate = startDate;
        MaxMembers = maxMembers;
    }

    public int MemberId { get; set; }
    public int ProgramCode { get; set; }
    public string Name { get; set; }
    public string Target { get; set; }
    public DateTime StartDate { get; set; }
    public int MaxMembers { get; set; }
}
