using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessBeheerDomain.Model;

namespace FitnessBeheerDomain.Interfaces;
public interface ICyclingSessionRepository
{
    CyclingSession GetCyclingSessionById(int id);
}
