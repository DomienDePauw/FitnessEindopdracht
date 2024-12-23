using FitnessBeheerDomain.Model;
using FitnessBeheerEFlayer.Mappers;
using FitnessBeheerEFlayer.Model;

public static class MapCyclingSession
{
    public static CyclingSession MapToDomain(CyclingSessionEF db) => new CyclingSession
    {
        Id = db.Id,
        Date = db.Date,
        Duration = db.Duration,
        AvgWatt = db.Avg_Watt,
        MaxWatt = db.Max_Watt,
        AvgCadence = db.Avg_Cadence,
        MaxCadence = db.Max_Cadence,
        TrainingType = db.TrainingType,
        Comment = db.Comment,
    };

    public static CyclingSessionEF MapToEF(CyclingSession domain) => new CyclingSessionEF
    {
        Id = domain.Id,
        Date = domain.Date,
        Duration = domain.Duration,
        Avg_Watt = domain.AvgWatt,
        Max_Watt = domain.MaxWatt,
        Avg_Cadence = domain.AvgCadence,
        Max_Cadence = domain.MaxCadence,
        TrainingType = domain.TrainingType,
        Comment = domain.Comment,
    };
}
