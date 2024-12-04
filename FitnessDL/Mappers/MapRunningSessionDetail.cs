using FitnessBeheerDomain.Model;
using FitnessBeheerEFlayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessBeheerEFlayer.Mappers;
public static class MapRunningSessionDetail
{
    public static RunningSessionDetail MapToDomain(RunningSessionDetailEF db)
    {
        return new RunningSessionDetail
        {
            Id = db.Id,
            SequenceNumber = db.Seq_nr,
            IntervalTime = db.Interval_Time,
            IntervalSpeed = db.Interval_Speed,
            //RunningSession = db.RunningSession != null
            //    ? MapRunningSession.MapToDomain(db.RunningSession)
            //    : null
        };
    }

    public static RunningSessionDetailEF MapToEF(RunningSessionDetail domain)
    {
        return new RunningSessionDetailEF
        {
            Id = domain.Id,
            Seq_nr = domain.SequenceNumber,
            Interval_Time = domain.IntervalTime,
            Interval_Speed = domain.IntervalSpeed,
            //RunningSession = domain.RunningSession != null
            //    ? MapRunningSession.MapToEF(domain.RunningSession)
            //    : null
        };
    }
}
