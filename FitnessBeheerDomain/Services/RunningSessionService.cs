using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessBeheerDomain.Interfaces;
using FitnessBeheerDomain.Model;

namespace FitnessBeheerDomain.Services;
public class RunningSessionService
{
    private IRunningSessionRepository _runningSessionRepository;

    public RunningSessionService(IRunningSessionRepository runningSessionRepository)
    {
        _runningSessionRepository = runningSessionRepository;
    }

    public RunningSession GetRunningSessionById(int id)
    {
        return _runningSessionRepository.GetRunningSessionById(id);
    }
}
