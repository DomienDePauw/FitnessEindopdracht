using FitnessBeheerDomain.Model;
using FitnessBeheerEFlayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessBeheerEFlayer.Mappers;
public static class MapTimeSlot
{
    public static TimeSlot MapToDomain(TimeSlotEF db) => new TimeSlot(db.Id, db.StartTime);

    public static TimeSlotEF MapToEF(TimeSlot domain) => new TimeSlotEF
    {
        StartTime = domain.StartTime,
        EndTime = domain.EndTime,
        PartOfDay = domain.PartOfDay
    };
}



