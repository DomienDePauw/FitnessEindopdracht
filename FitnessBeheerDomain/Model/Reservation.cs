﻿using FitnessBeheerDomain.Exceptions;
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
    public Reservation(int id, int memberId, int equipmentId, List<TimeSlot> timeSlots, DateOnly reservationDate)
    {
        Id = id;
        MemberId = memberId;
        EquipmentId = equipmentId;
        TimeSlots = timeSlots;
        ReservationDate = reservationDate;
    }

    public int Id { get; private set; }
    public int MemberId { get; set; }
    public int EquipmentId { get;  set; }
    public List<TimeSlot> TimeSlots { get; set; } = new List<TimeSlot>();
    public DateOnly ReservationDate { get; set; }
}


