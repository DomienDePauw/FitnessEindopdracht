namespace FitnessBeheerDomain.Model;
public class RunningSession
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public double Duration { get; set; }
    public double AvgSpeed { get; set; }
    public List<RunningSessionDetail> Details { get; set; } = new();
}

