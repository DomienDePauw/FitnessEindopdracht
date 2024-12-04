using FitnessBeheerDomain.Model;
using FitnessBeheerEFlayer.Model;

namespace FitnessBeheerEFlayer.Mappers;
public static class MapEquipment
{
    public static Equipment MapToDomain(EquipmentEF ef) => new Equipment
    {
        Id = ef.Id,
        DeviceTypes = ef.DeviceType.ToList(),
        IsAvailable = ef.IsAvailable,
        //Reservations = ef.Reservations?.Select(MapReservation.MapToDomain).ToList() ?? new List<Reservation>()
    };

    public static EquipmentEF MapToEF(Equipment domain) => new EquipmentEF
    {
        Id = domain.Id,
        DeviceType = domain.DeviceTypes.ToList(),
        IsAvailable = domain.IsAvailable,
        //Reservations = domain.Reservations?.Select(MapReservation.MapToEF).ToList()
    };
}
