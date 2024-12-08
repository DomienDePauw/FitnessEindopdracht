namespace FitnessREST.DTO;

public class StatisticSessionsDTO
{
    public int TotalSessionCount { get; set; }
    public double TotalDurationInHours { get; set; }
    public double LongestSessionDuration { get; set; }
    public double ShortestSessionDuration { get; set; }
    public double AverageSessionDuration { get; set; }
}
