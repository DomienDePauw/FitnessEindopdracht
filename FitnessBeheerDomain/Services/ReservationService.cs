﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessBeheerDomain.Services;
public class ReservationService
{
    //Splits de createreserv method op in stukjes zodat het niet te onoverzichtelinjk wordt.

    public void CreateReservation()
    {

    }

    private void ValidateReservationDate(DateTime reservationDate)
    {
        if (reservationDate < DateTime.Now.Date)
        {
            throw new ArgumentException("Reservaties moeten in de toekomst liggen");
        }
        if (reservationDate > DateTime.Now.AddDays(7).Date)
        {
            throw new ArgumentException("Reservaties kunnen max. 1 week op voorhand gemaakt worden");
        }
    }

    private void ValidateDailyTimeSlotLimit(int clientId, DateTime reservationDate)
    {
        //var dailyReservations = _context.Reservation.Where(r => r.ClientId == clientId)
    }
}