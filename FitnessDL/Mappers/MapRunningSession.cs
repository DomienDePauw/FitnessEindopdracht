using FitnessBeheerDomain.Model;
using FitnessBeheerEFlayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessBeheerEFlayer.Mappers;
public static class MapRunningSession
{
    public static RunningSession MapToDomain(RunningSessionEF ef) => new RunningSession
    {
        Id = ef.Id,
        Date = ef.Date,
        Duration = ef.Duration,
        AvgSpeed = ef.Avg_Speed,
        Details = ef.Details?.Select(MapRunningSessionDetail.MapToDomain).ToList() ?? new List<RunningSessionDetail>()
    };

    public static RunningSessionEF MapToEF(RunningSession domain) => new RunningSessionEF
    {
        Id = domain.Id,
        Date = domain.Date,
        Duration = domain.Duration,
        Avg_Speed = domain.AvgSpeed,
        Details = domain.Details?.Select(MapRunningSessionDetail.MapToEF).ToList()
    };
}

