using FitnessBeheerDomain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessBeheerDomain.Interfaces;
public interface IReservationRepository
{
    void AddReservation(Reservation reservation);
    List<Reservation> GetReservationsByDate(DateOnly date);
}