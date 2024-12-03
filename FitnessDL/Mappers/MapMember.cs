using FitnessBeheerDomain.Model;
using FitnessBeheerEFlayer.Model;
using FitnessBeheerEFlayer.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace FitnessBeheerEFlayer.Mappers;
public static class MapMember 
{
    public static Member MapToDomain(MemberEF db) 
    {
		try
		{
            return new Member(
                db.MemberId,
                db.FirstName,
                db.LastName,
                db.Email,
                db.City,
                db.Birthday,
                db.Interests ?? new List<string>(), // Als Interests null is, zet een lege lijst
                db.MemberType,
                db.FitnessPrograms?.Select(MapProgram.MapToDomain).ToList() ?? new List<Program>(),
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
    public static Member MapToEF(Member domain) 
    {

    }
}
