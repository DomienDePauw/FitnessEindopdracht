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
        db.EquipmentId,
        db.Id,
        db.MemberId,
        MapTimeSlot.MapToDomain(db.TimeSlot),
        db.Date);

    public static ReservationEF MapToEF(Reservation reservation)
    {
        return new ReservationEF
        {
            Id = reservation.Id,
            EquipmentId = reservation.EquipmentId,
            MemberId = reservation.MemberId,
            Date = reservation.ReservationDate,
            TimeSlot = MapTimeSlot.MapToEF(reservation.TimeSlot)
        };
    }
}


