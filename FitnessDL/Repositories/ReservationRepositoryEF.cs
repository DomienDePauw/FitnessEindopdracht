using FitnessBeheerDomain.Interfaces;
using FitnessBeheerDomain.Model;
using FitnessBeheerEFlayer.Mappers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            .Include(r => r.TimeSlots)
            .Where(r => r.Date == date && r.MemberId == memberId) 
            .Select(r => MapReservation.MapToDomain(r))
            .ToList();
        return reservations;
    }

    public List<Reservation> GetReservationsByDate(DateOnly date)
    {
        var reservations = _context.reservation
            .Include(r => r.TimeSlots)
            .Where(r => r.Date == date)
            .Select(r => MapReservation.MapToDomain(r))
            .ToList();
        return reservations;
    }
}
