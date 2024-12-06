using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessBeheerDomain.Interfaces;
using FitnessBeheerDomain.Exceptions;
using FitnessBeheerDomain.Model;

namespace FitnessBeheerDomain.Services;
public class ReservationService
{
    private readonly IReservationRepository _reservationRepository;

    public ReservationService(IReservationRepository reservationRepository)
    {
        _reservationRepository = reservationRepository;
    }
    public void AddReservation(Reservation reservation)
    {
        ValidateReservation(reservation);
        _reservationRepository.AddReservation(reservation);
    }

    //public void DeleteReservation(int reservationId)
    //{
    //    throw new NotImplementedException();
    //}

    //public object GetReservationById(int reservationId)
    //{
    //    throw new NotImplementedException();
    //}

    public bool ValidateTimeSlot(List<Reservation> reservations)
    {
        var equipmentGroups = reservations.ToDictionary(r => r.EquipmentId, r => r.TimeSlots);
        foreach (var equipmentGroup in equipmentGroups)
        {
            TimeOnly? previousStartTime = null;
            var successiveTimeSlots = 1;
            foreach (var timeslot in equipmentGroup.Value.OrderBy(s => s.StartTime))
            {
                if (previousStartTime == null)
                {
                    previousStartTime = timeslot.StartTime;
                }
                else
                {
                    if (timeslot.StartTime == previousStartTime?.AddHours(1))
                    {
                        successiveTimeSlots++;

                        if (successiveTimeSlots > 2)
                        {
                            return false;
                        }
                    }
                    else successiveTimeSlots = 1;
                }
            }
        }
        return true;
    }
    private void ValidateReservation(Reservation reservation)
    {
        if (reservation.ReservationDate < DateOnly.FromDateTime(DateTime.Now)) 
        {
            throw new ReservationException("Moet in de toekomst liggen");
        }
        if (reservation.ReservationDate > DateOnly.FromDateTime(DateTime.Now).AddDays(7))
        {
            throw new ReservationException("Mag maximaal 7 dagen in de toekomst liggen");
        }
        var existingReservations = _reservationRepository
            .GetReservationsByDate(reservation.ReservationDate);

        var memberReservations = existingReservations
            .Where(r => r.MemberId == reservation.MemberId);

        var totalReservations = memberReservations.ToList();
        totalReservations.Add(reservation);

        if (!ValidateTimeSlot(totalReservations)) 
        {
            throw new ReservationException("");
        }

        var totalSlotsForMember = memberReservations
            .SelectMany(r => r.TimeSlots)
            .Count();

        if (totalSlotsForMember + reservation.TimeSlots.Count > 4)
        {
            throw new ReservationException("A member can only reserve up to 4 time slots per day.");
        }

        foreach (var existing in existingReservations.Where(r => r.EquipmentId == reservation.EquipmentId))
        {
            foreach (var slot in reservation.TimeSlots)
            {
                if (existing.TimeSlots.Any(existingSlot => slot.OverlapsWith(existingSlot)))
                {
                    throw new ReservationException("This equipment is already reserved for the selected time slot.");
                }
            }
        }
    }
}

