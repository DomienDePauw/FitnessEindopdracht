using FitnessBeheerDomain.Model;

namespace FitnessREST.DTO;

public class FitnessProgramDTO
{
    public string ProgramCode { get; set; }
    public string Name { get; set; }
    public string Target { get; set; }
    public DateTime StartDate { get; set; }
    public int MaxMembers { get; set; }
    public List<Member> Members { get; set; } = new List<Member>();
}
