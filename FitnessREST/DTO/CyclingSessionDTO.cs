﻿using FitnessBeheerDomain.Model;

namespace FitnessREST.DTO;
public class CyclingSessionDTO
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public int Duration { get; set; }
    public int AvgWatt { get; set; }
    public int MaxWatt { get; set; }
    public int AvgCadence { get; set; }
    public int MaxCadence { get; set; }
    public string TrainingType { get; set; }
    public string Comment { get; set; }
    public Member Member { get; set; }
}
