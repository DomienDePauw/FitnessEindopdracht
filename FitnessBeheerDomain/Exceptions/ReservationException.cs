﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessBeheerDomain.Exceptions;
public class ReservationException : Exception
{
    public ReservationException(string message) : base(message)
    {
    }

    public ReservationException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
