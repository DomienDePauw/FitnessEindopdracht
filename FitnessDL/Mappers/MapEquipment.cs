using FitnessBeheerDomain.Model;
using FitnessBeheerEFlayer.Model;

namespace FitnessBeheerEFlayer.Mappers;
public static class MapEquipment
{
    public static Equipment MapToDomain(EquipmentEF db) => new Equipment
    {
        Id = db.Id,
        Type = MapEquipmentType.MapToDomain(db.Type),
        IsAvailable = db.IsAvailable,
        //Reservations = db.Reservations?.Select(MapReservation.MapToDomain).ToList() ?? new List<Reservation>()
    };
    public static EquipmentEF MapToEF(Equipment domain) => new EquipmentEF
    {
        Id = domain.Id,
        Type = MapEquipmentType.MapToEF(domain.Type),
        IsAvailable = domain.IsAvailable,
        //Reservations = domain.Reservations?.Select(MapReservation.MapToEF).ToList() ?? new List<ReservationEF>()
    };
}

