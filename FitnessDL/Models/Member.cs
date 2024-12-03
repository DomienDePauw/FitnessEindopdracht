using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessDL.Models;

public class Member
{
    public Member()
    {
        
    }
    public Member(string firstName, string lastName, string email, string city, DateTime birthday, List<string>? interests, MemberType memberType, ICollection<FitnessProgram> fitnessPrograms, ICollection<Reservation> reservations, ICollection<CyclingSession> cyclingSessions, ICollection<RunningSession> runningSessions)
    {
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

    public Member(int memberId, string firstName, string lastName, string email, string city, DateTime birthday, List<string>? interests, MemberType memberType, ICollection<FitnessProgram> fitnessPrograms, ICollection<Reservation> reservations, ICollection<CyclingSession> cyclingSessions, ICollection<RunningSession> runningSessions)
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
    public MemberType MemberType { get; set; } //Hoe Label bepalen? Geen info in de opdracht? 
    public ICollection<FitnessProgram> FitnessPrograms { get; set; }
    public ICollection<Reservation> Reservations { get; set; }
    public ICollection<CyclingSession> CyclingSessions { get; set; } //Member owned Cyclingsessions
    public ICollection<RunningSession> RunningSessions { get; set; }
}
