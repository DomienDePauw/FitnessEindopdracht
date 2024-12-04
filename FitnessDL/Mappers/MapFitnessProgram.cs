using FitnessBeheerDomain.Model;
using FitnessBeheerEFlayer.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessBeheerEFlayer.Mappers;
public static class MapFitnessProgram
{
    public static FitnessProgram MapToDomain(FitnessProgramEF db)
    {
        return new FitnessProgram
        {
            ProgramCode = db.ProgramCode,
            Name = db.Name,
            Target = db.Target,
            StartDate = db.StartDate,
            MaxMembers = db.MaxMembers,
            //Members = db.Members?.Select(MapMember.MapToDomain).ToList() ?? new List<Member>()
        };
    }

    public static FitnessProgramEF MapToEF(FitnessProgram domain)
    {
        return new FitnessProgramEF
        {
            ProgramCode = domain.ProgramCode,
            Name = domain.Name,
            Target = domain.Target,
            StartDate = domain.StartDate,
            MaxMembers = domain.MaxMembers,
            //Members = domain.Members?.Select(MapMember.MapToEF).ToList() ?? new List<MemberEF>()
        };
    }
}
