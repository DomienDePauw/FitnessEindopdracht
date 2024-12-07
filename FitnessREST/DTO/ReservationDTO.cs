using FitnessBeheerDomain.Model;

namespace FitnessREST.DTO;
public class ReservationDTO
{
    public int Id { get; set; }
    public int MemberId { get; set; }
    public int EquipmentId { get; set; } 
    public List<TimeSlotDTO> TimeSlots { get; set; }
    public DateOnly ReservationDate { get; set; }
}


