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
    public static TimeSlot MapToDomain(TimeSlotEF db) => new TimeSlot
    {
        Id = db.TimeSlotId,
        StartTime = db.StartTime,
        EndTime = db.EndTime,
        PartOfDay = db.PartOfDay,
        Reservations = db.Reservations?.Select(MapReservation.MapToDomain).ToList() ?? new List<Reservation>()
    };

    public static TimeSlotEF MapToEF(TimeSlot domain) => new TimeSlotEF
    {
        TimeSlotId = domain.Id,
        StartTime = domain.StartTime,
        EndTime = domain.EndTime,
        PartOfDay = domain.PartOfDay,
        Reservations = domain.Reservations?.Select(MapReservation.MapToEF).ToList()
    };
}

