namespace FitnessREST.DTO;

public class CyclingSessionDTO
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public double Duration { get; set; }
    public double AvgWatt { get; set; }
    public double MaxWatt { get; set; }
    public double AvgCadence { get; set; }
    public double MaxCadence { get; set; }
    public string TrainingType { get; set; }
    public string Impact { get; set; }
}
