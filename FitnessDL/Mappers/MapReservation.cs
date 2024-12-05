using FitnessBeheerDomain.Model;
using FitnessBeheerEFlayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessBeheerEFlayer.Mappers;
public static class MapReservation
{
    public static Reservation MapToDomain(ReservationEF db) =>
        new Reservation(
        db.Id,
        db.MemberId,
        db.EquipmentId,
        db.TimeSlots.Select(MapTimeSlot.MapToDomain).ToList(),
        db.Date);

    public static ReservationEF MapToEF(Reservation domain) => new ReservationEF
    {
        Id = domain.Id,
        MemberId = domain.MemberId,
        EquipmentId = domain.EquipmentId,
        TimeSlots = domain.TimeSlots.Select(MapTimeSlot.MapToEF).ToList(),
        Date = domain.ReservationDate
    };
}


