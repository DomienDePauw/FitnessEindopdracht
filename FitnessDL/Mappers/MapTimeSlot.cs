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

    public static TimeSlotEF MapToEF(TimeSlot timeSlot)
    {
        return new TimeSlotEF
        {
            Id = timeSlot.Id,
            StartTime = timeSlot.StartTime,
            EndTime = timeSlot.EndTime,
            PartOfDay = timeSlot.PartOfDay
        };
    }
}



