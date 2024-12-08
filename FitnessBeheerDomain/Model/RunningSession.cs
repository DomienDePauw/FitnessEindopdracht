namespace FitnessBeheerDomain.Model;
public class RunningSession
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public int Duration { get; set; }
    public int AvgSpeed { get; set; }
    public List<RunningSessionDetail> Details { get; set; } = new();
}

