using FitnessBeheerDomain.Model;

namespace FitnessREST.DTO;
public class ReservationDTO
{
    public int MemberId { get; set; }
    public int EquipmentId { get; set; } 
    public TimeSlotDTO TimeSlot { get; set; }
    public DateOnly ReservationDate { get; set; }
}


