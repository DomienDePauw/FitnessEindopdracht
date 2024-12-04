using FitnessBeheerDomain.Model;

namespace FitnessREST.DTO;
public class RunningSessionDTO
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public int Duration { get; set; }
    public int AvgSpeed { get; set; }
    public Member Member { get; set; }
    public List<RunningSessionDetail> Details { get; set; } = new();
}
