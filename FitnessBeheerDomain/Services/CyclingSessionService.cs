using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessBeheerDomain.Interfaces;
using FitnessBeheerDomain.Model;

namespace FitnessBeheerDomain.Services;
public class CyclingSessionService
{
    private ICyclingSessionRepository _cyclingSessionRepository;

    public CyclingSessionService(ICyclingSessionRepository cyclingSessionRepository)
    {
        _cyclingSessionRepository = cyclingSessionRepository;
    }

    public CyclingSession GetCyclingSessionById(int id)
    {
        return _cyclingSessionRepository.GetCyclingSessionById(id);
    }
}
