using System;
using System.Collections.Generic;
using System.Linq;
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

    public void DeleteReservation(int id)
    {
        _reservationRepository.DeleteReservation(id);
    }

    private void ValidateReservation(Reservation reservation)
    {
        if (reservation.ReservationDate < DateOnly.FromDateTime(DateTime.Today))
        {
            throw new ReservationException("The reservation must be in the future.");
        }

        if (reservation.ReservationDate > DateOnly.FromDateTime(DateTime.Today.AddDays(7)))
        {
            throw new ReservationException("The reservation cannot be more than 7 days in the future.");
        }

        var memberReservations = _reservationRepository.GetReservationsByDateAndMember(
            reservation.ReservationDate,
            reservation.MemberId
        ) ?? new List<Reservation>();

        if (memberReservations.Count >= 4)
        {
            throw new ReservationException("A member can only reserve up to 4 time slots per day.");
        }

        if (memberReservations
            .Where(r => r.EquipmentId == reservation.EquipmentId)
            .Any(existingReservation => existingReservation.TimeSlot.OverlapsWith(reservation.TimeSlot)))
        {
            throw new ReservationException("This equipment is already reserved for the selected time slot.");
        }

        var allReservationsForDate = _reservationRepository.GetReservationsByDate(reservation.ReservationDate) ?? new List<Reservation>();

        var reservationsWithNew = allReservationsForDate.Concat(new[] { reservation }).ToList();

        if (!ValidateTimeSlot(reservationsWithNew))
        {
            throw new ReservationException("Cannot reserve more than 2 consecutive time slots for the same equipment.");
        }
    }

    public bool ValidateTimeSlot(List<Reservation> reservations)
    {
        var equipmentGroups = reservations
            .GroupBy(r => new { r.EquipmentId, r.ReservationDate })
            .ToList();

        foreach (var equipmentGroup in equipmentGroups)
        {
            var sortedTimeSlots = equipmentGroup
                .Select(r => r.TimeSlot)
                .OrderBy(s => s.StartTime)
                .ToList();

            int successiveTimeSlots = 1; 

            for (int i = 1; i < sortedTimeSlots.Count; i++)
            {
                var previousSlot = sortedTimeSlots[i - 1];
                var currentSlot = sortedTimeSlots[i];

                if (currentSlot.StartTime == previousSlot.StartTime.AddHours(1))
                {
                    successiveTimeSlots++;
                }
                else
                {
                    successiveTimeSlots = 1; 
                }

                if (successiveTimeSlots > 2)
                {
                    return false; 
                }
            }
        }

        return true;
    }

    public Reservation GetReservationById(int id)
    {
        return _reservationRepository.GetReservationById(id);
    }

    public void UpdateReservation(int id, Reservation existingReservation)
    {
        _reservationRepository.UpdateReservation(id, existingReservation);
    }
}
