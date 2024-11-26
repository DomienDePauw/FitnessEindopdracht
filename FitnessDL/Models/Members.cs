using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessDL.Models
{
    public class Members
    {
        [Key] 
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public DateTime Birthday { get; set; }
        public ICollection<Interests> Interests { get; set; }
        [Required]
        public string MemberType { get; set; }
        public ICollection<FitnessProgram> FitnessPrograms { get; set; }
        public ICollection<Reservation> Reservations { get; set; }

    }
}
