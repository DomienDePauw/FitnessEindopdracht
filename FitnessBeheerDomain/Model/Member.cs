using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FitnessBeheerDomain.Model;
public class Member
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string City { get; set; }
    public DateTime Birthday { get; set; }
    public List<string>? Interests { get; set; }
    public MemberType MemberType { get; set; }
    public List<FitnessProgram> FitnessPrograms { get; set; } = new List<FitnessProgram>();
    public List<Reservation> Reservations { get; set; } = new List<Reservation>();
    public List<CyclingSession> CyclingSessions { get; set; } = new List<CyclingSession>();
    public List<RunningSession> RunningSessions { get; set; } = new List<RunningSession>();

    public Member(
        int id,
        string firstName,
        string lastName,
        string email,
        string city,
        DateTime birthday,
        List<string> interests,
        MemberType memberType,
        List<FitnessProgram> fitnessPrograms,
        List<Reservation> reservations,
        List<CyclingSession> cyclingSessions,
        List<RunningSession> runningSessions)
    {
        Id = id;
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
}

public enum MemberType
{
    Bronze,
    Silver,
    Gold
}


