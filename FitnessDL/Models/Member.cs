using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessDL.Models
{
    public class Member
    {
        public int MemberId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required] 
        public string City { get; set; }
        [Required]
        public DateTime Birthday { get; set; }
        public List<string> Interests { get; set; }
        [Required]
        public string MemberType { get; set; } //Hoe Label bepalen? Geen info in de opdracht? 
        public ICollection<FitnessProgram> FitnessPrograms { get; set; }
        public ICollection<Reservation> Reservations { get; set; }

    }
}
