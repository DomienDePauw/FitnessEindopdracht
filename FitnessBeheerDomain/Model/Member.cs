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
    public string MemberType { get; set; }
    public List<Program> Programs { get; set; } = new List<Program>();
    public List<Reservation> Reservations { get; set; } = new List<Reservation>();
    public List<CyclingSession> CyclingSessions { get; set; } = new List<CyclingSession>();
    public List<RunningSession> RunningSessions { get; set; } = new List<RunningSession>();
}

