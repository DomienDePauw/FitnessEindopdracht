using FitnessBeheerDomain.Model;

namespace FitnessREST.DTO;

public class SessionsWithImpact
{
    public int Month { get; set; }
    public List<CyclingSessionDTO> cyclingSessions { get; set; } = new();
}
public enum Impact
{
    Low,
    Medium,
    High
}

