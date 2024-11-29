namespace FitnessBL.DTO;
public class ReservationDTO
{
    public int MemberId { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public DateTime Date { get; set; }
    public List<TimeSlotDTO> TimeSlots { get; set; }
}
