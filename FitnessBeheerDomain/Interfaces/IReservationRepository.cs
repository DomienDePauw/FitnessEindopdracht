using FitnessBeheerDomain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessBeheerDomain.Interfaces;
public interface IReservationRepository
{
    List<Reservation> GetReservationsByDate(DateOnly date);
    List<Reservation> GetReservationsByDateAndMember(DateOnly date, int memberId);
    void AddReservation(Reservation reservation);
}
