using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessBeheerDomain.Interfaces;
using FitnessBeheerDomain.Model;

namespace FitnessBeheerDomain.Services;
public class FitnessProgramService
{
    private IFitnessProgramRepository _fitnessProgramRepository;

    public FitnessProgramService(IFitnessProgramRepository fitnessProgramRepository)
    {
        _fitnessProgramRepository = fitnessProgramRepository;
    }

    public void AddFitnessProgram(FitnessProgram fitnessProgram)
    {
        _fitnessProgramRepository.AddFitnessProgram(fitnessProgram);
    }

    public void UpdateFitnessProgram(int id,FitnessProgram fitnessProgram)
    {
        _fitnessProgramRepository.UpdateFitnessProgram(id, fitnessProgram);
    }
}
