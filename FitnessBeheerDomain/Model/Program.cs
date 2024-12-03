using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessBeheerDomain.Model;
public class Program
{
    public string ProgramCode { get; set; } // Uniek ID
    public string Name { get; set; }
    public string Target { get; set; }
    public DateTime StartDate { get; set; }
    public int MaxMembers { get; set; }
    public List<Member> Members { get; set; } = new List<Member>();
}
