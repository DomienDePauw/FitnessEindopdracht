using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessBeheerDomain.Interfaces;
using FitnessBeheerDomain.Model;
using FitnessBeheerEFlayer.Mappers;
using Microsoft.EntityFrameworkCore;

namespace FitnessBeheerEFlayer.Repositories;
public class RunningSessionRepositoryEF : IRunningSessionRepository
{
    private readonly FitnessContext _context;

    public RunningSessionRepositoryEF(FitnessContext ctx)
    {
        _context = ctx;
    }

    public RunningSession GetRunningSessionById(int id)
    {
        var runningSession = _context.runningsession_main
             .Include(r => r.Details)
             .FirstOrDefault(r => r.Id == id);

        if (runningSession == null)
        {
            throw new Exception("Session not found.");
        }

        return MapRunningSession.MapToDomain(runningSession);
    }
}
