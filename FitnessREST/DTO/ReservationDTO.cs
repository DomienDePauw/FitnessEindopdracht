using FitnessBeheerDomain.Model;

namespace FitnessREST.DTO;
public class ReservationDTO
{
    public int Id { get; set; }
    public Equipment Equipment { get; set; }
    public TimeSlot TimeSlot { get; set; }
    public DateTime Date { get; set; }
    public Member Member { get; set; }
}
