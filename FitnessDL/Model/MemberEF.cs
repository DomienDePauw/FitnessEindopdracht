using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessBeheerEFlayer.Model;

public class MemberEF
{
    public MemberEF(int memberId, string firstName, string lastName, string email, string city, DateTime birthday,
        List<string>? interests, string memberType, ICollection<ProgramEF> fitnessPrograms, ICollection<ReservationEF> reservations, 
        ICollection<CyclingSessionEF> cyclingSessions, ICollection<RunningSessionEF> runningSessions)
    {
        MemberId = memberId;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        City = city;
        Birthday = birthday;
        Interests = interests;
        MemberType = memberType;
        FitnessPrograms = fitnessPrograms;
        Reservations = reservations;
        CyclingSessions = cyclingSessions;
        RunningSessions = runningSessions;
    }

    [Key]
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
    public List<string>? Interests { get; set; }
    [Required]
    public string MemberType { get; set; }
    public ICollection<ProgramEF> FitnessPrograms { get; set; }
    public ICollection<ReservationEF> Reservations { get; set; }
    public ICollection<CyclingSessionEF> CyclingSessions { get; set; }
    public ICollection<RunningSessionEF> RunningSessions { get; set; }
}
