﻿using FitnessBeheerDomain.Exceptions;
using FitnessBeheerDomain.Interfaces;
using FitnessBeheerDomain.Model;
using FitnessBeheerEFlayer.Mappers;
using FitnessBeheerEFlayer.Model;
using Microsoft.EntityFrameworkCore;

namespace FitnessBeheerEFlayer.Repositories;
public class ReservationRepositoryEF : IReservationRepository
{
    private readonly FitnessContext _context;

    public ReservationRepositoryEF(FitnessContext ctx)
    {
        _context = ctx;
    }

    public void AddReservation(Reservation reservation)
    {
        _context.reservation.Add(MapReservation.MapToEF(reservation));
        _context.SaveChanges();
    }

    public List<Reservation> GetReservationsByDateAndMember(DateOnly date, int memberId)
    {
        var reservations = _context.reservation
            .Include(r => r.TimeSlot)
            .Where(r => r.Date == date && r.MemberId == memberId)
            .Select(r => MapReservation.MapToDomain(r))
            .ToList();
        return reservations;
    }

    public List<Reservation> GetReservationsByDate(DateOnly date)
    {
        var reservations = _context.reservation
            .Include(r => r.TimeSlot)
            .Where(r => r.Date == date)
            .Select(r => MapReservation.MapToDomain(r))
            .ToList();
        return reservations;
    }

    public void DeleteReservation(int id)
    {
        var reservation = _context.reservation
            .Include(r => r.TimeSlot)
            .FirstOrDefault(r => r.Id == id);

        if (reservation == null)
        {
            throw new ReservationException("Reservation not found.");
        }

        _context.reservation.Remove(reservation); 
        _context.SaveChanges();
    }

    public Reservation GetReservationById(int id)
    {
        var reservation = _context.reservation
            .Include(r => r.TimeSlot)
            .FirstOrDefault(r => r.Id == id);

        if (reservation == null)
        {
            throw new ReservationException("Reservation not found.");
        }

        return MapReservation.MapToDomain(reservation);
    }

    public void UpdateReservation(int id, Reservation updatedReservation)
    {
        var reservation = _context.reservation
            .Include(r => r.TimeSlot)
            .FirstOrDefault(r => r.Id == id);

        if (reservation == null)
        {
            throw new ReservationException("Reservation not found.");
        }

        reservation.MemberId = updatedReservation.MemberId;
        reservation.EquipmentId = updatedReservation.EquipmentId;
        reservation.Date = updatedReservation.ReservationDate;

        reservation.TimeSlot = MapTimeSlot.MapToEF(updatedReservation.TimeSlot);

        _context.SaveChanges();
    }
}
