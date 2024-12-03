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
    public static Reservation MapToDomain(ReservationEF db) => new Reservation
    {
        Id = db.ReservationId,
        Equipment = MapEquipment.MapToDomain(db.Equipment),
        TimeSlot = MapTimeSlot.MapToDomain(db.TimeSlot),
        Date = db.Date,
        Member = MapMember.MapToDomain(db.Member)
    };

    public static ReservationEF MapToEF(Reservation domain) => new ReservationEF
    {
        ReservationId = domain.Id,
        Equipment = MapEquipment.MapToEF(domain.Equipment),
        TimeSlot = MapTimeSlot.MapToEF(domain.TimeSlot),
        Date = domain.Date,
        Member = MapMember.MapToEF(domain.Member)
    };
}

