using FitnessBeheerDomain.Model;
using FitnessBeheerEFlayer.Model;
using FitnessBeheerEFlayer.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FitnessBeheerEFlayer.Mappers;

public static class MapMember
{
    public static Member MapToDomain(MemberEF db)
    {
        try
        {
            return new Member(
                db.Id,
                db.FirstName,
                db.LastName,
                db.Email,
                db.City,
                db.Birthday,
                db.Interests ?? new List<string>(),
                Enum.Parse<MemberType>(db.MemberType), // Aangezien dit nu een string is in EF en enum in domein
                db.FitnessPrograms?.Select(MapFitnessProgram.MapToDomain).ToList() ?? new List<FitnessProgram>(),
                db.Reservations?.Select(MapReservation.MapToDomain).ToList() ?? new List<Reservation>(),
                db.CyclingSessions?.Select(MapCyclingSession.MapToDomain).ToList() ?? new List<CyclingSession>(),
                db.RunningSessions?.Select(MapRunningSession.MapToDomain).ToList() ?? new List<RunningSession>()
            );
        }
        catch (Exception ex)
        {
            throw new MapException("MapMember - MapToDomain", ex);
        }
    }

    public static MemberEF MapToEF(Member domain)
    {
        try
        {
            return new MemberEF
            {
                Id = domain.Id,
                FirstName = domain.FirstName,
                LastName = domain.LastName,
                Email = domain.Email,
                City = domain.City,
                Birthday = domain.Birthday,
                Interests = domain.Interests,
                MemberType = domain.MemberType.ToString(), // Enum naar string
                FitnessPrograms = domain.FitnessPrograms?.Select(MapFitnessProgram.MapToEF).ToList() ?? new List<FitnessProgramEF>(),
                Reservations = domain.Reservations?.Select(MapReservation.MapToEF).ToList() ?? new List<ReservationEF>(),
                CyclingSessions = domain.CyclingSessions?.Select(MapCyclingSession.MapToEF).ToList() ?? new List<CyclingSessionEF>(),
                RunningSessions = domain.RunningSessions?.Select(MapRunningSession.MapToEF).ToList() ?? new List<RunningSessionEF>()
            };
        }
        catch (Exception ex)
        {
            throw new MapException("MapMember - MapToEF", ex);
        }
    }
}
