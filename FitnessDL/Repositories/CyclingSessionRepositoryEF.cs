using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessBeheerDomain.Exceptions;
using FitnessBeheerDomain.Interfaces;
using FitnessBeheerDomain.Model;
using FitnessBeheerEFlayer.Mappers;
using Microsoft.EntityFrameworkCore;

namespace FitnessBeheerEFlayer.Repositories;
public class CyclingSessionRepositoryEF : ICyclingSessionRepository
{
    private readonly FitnessContext _context;

    public CyclingSessionRepositoryEF(FitnessContext ctx)
    {
        _context = ctx;
    }

    public CyclingSession GetCyclingSessionById(int id) 
    {
        var cyclingSession = _context.cyclingsession
             .FirstOrDefault(r => r.Id == id);

        if (cyclingSession == null)
        {
            throw new Exception("Session not found.");
        }

        return MapCyclingSession.MapToDomain(cyclingSession);
    }
}