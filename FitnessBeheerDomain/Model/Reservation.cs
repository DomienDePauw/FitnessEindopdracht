using FitnessBeheerDomain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FitnessBeheerDomain.Model;
public class Reservation
{
    public Reservation()
    {
        
    }
    public Reservation(int id, int memberId, int equipmentId, TimeSlot timeSlot, DateOnly reservationDate)
    {
        Id = id;
        MemberId = memberId;
        EquipmentId = equipmentId;
        TimeSlot = timeSlot;
        ReservationDate = reservationDate;
    }

    public int Id { get; private set; }
    public int MemberId { get; set; }
    public int EquipmentId { get;  set; }
    public TimeSlot TimeSlot { get; set; }
    public DateOnly ReservationDate { get; set; }
}


