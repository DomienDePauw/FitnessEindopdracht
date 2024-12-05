using FitnessBeheerDomain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessBeheerDomain.Model;
public class Reservation
{
    public int Id { get; private set; }
    public int MemberId { get; private set; }
    public int EquipmentId { get; private set; }
    public List<TimeSlot> TimeSlots { get; private set; } = new List<TimeSlot>();
    public DateOnly ReservationDate { get; private set; }

    public Reservation(int memberId, int equipmentId, List<TimeSlot> timeSlots, DateOnly reservationDate)
    {
        if (timeSlots.Count > 2)
            throw new ReservationException("A reservation cannot exceed 2 consecutive time slots.");

        MemberId = memberId;
        EquipmentId = equipmentId;
        TimeSlots = timeSlots.OrderBy(t => t.StartTime).ToList();
        ReservationDate = reservationDate;
    }

    public Reservation(int id, int memberId, int equipmentId, List<TimeSlot> timeSlots, DateOnly reservationDate)
    {
        var reservation = new Reservation(memberId, equipmentId, timeSlots, reservationDate);
            reservation.Id = id;
    }
}


