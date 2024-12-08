using FitnessBeheerDomain.Model;

namespace FitnessREST.DTO;

public class SessionDTO
{
    public List<RunningSession> runningSessions { get; set; } = new();
    public List<CyclingSession> cyclingSessions { get; set; } = new();
}
