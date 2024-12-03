using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessBeheerEFlayer.Model;

public class FitnessProgramEF
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string ProgramCode { get; set; }
    public string Name { get; set; }
    public string Target { get; set; }
    public DateTime StartDate { get; set; }
    public int MaxMembers { get; set; }
    public ICollection<MemberEF> Members { get; set; }
}
