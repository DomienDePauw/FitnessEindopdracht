using FitnessBeheerDomain.Model;
using FitnessBeheerEFlayer.Exceptions;
using FitnessBeheerEFlayer.Model;

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
                Enum.Parse<MemberType>(db.MemberType),
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
                MemberType = domain.MemberType.ToString(),
                Reservations = domain.Reservations
                                .Select(MapReservation.MapToEF)
                                .ToList(),
                CyclingSessions = domain.CyclingSessions
                                .Select(MapCyclingSession.MapToEF)
                                .ToList(),
                RunningSessions = domain.RunningSessions
                                .Select(MapRunningSession.MapToEF)
                                .ToList(),
            };
        }
        catch (Exception ex)
        {
            throw new MapException("MapMember - MapToEF", ex);
        }
    }
}
