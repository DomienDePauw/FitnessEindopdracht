using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessDL.Models
{
    public class FitnessProgram
    {
        [Key]
        public string ProgramCode { get; set; }
        public string ProgramName { get; set; }
        public string Target { get; set; }
        public DateTime StartDate { get; set; }
        public int MaxMembers { get; set; }
        public ICollection<Members> Members { get; set; }
    }
}
