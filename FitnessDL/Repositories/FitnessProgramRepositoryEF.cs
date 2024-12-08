using FitnessBeheerDomain.Interfaces;
using FitnessBeheerDomain.Model;
using FitnessBeheerEFlayer.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessBeheerEFlayer.Repositories;
public class FitnessProgramRepositoryEF : IFitnessProgramRepository
{
    private readonly FitnessContext _context;

    public FitnessProgramRepositoryEF(FitnessContext ctx)
    {
        _context = ctx;
    }

    public void AddFitnessProgram(FitnessProgram fitnessProgram)
    {
        var fitnessProgramEF = MapFitnessProgram.MapToEF(fitnessProgram);
        _context.program.Add(fitnessProgramEF);
        _context.SaveChanges();
    }

    public void UpdateFitnessProgram(int Id, FitnessProgram updatedProgram)
    {
        var fitnessProgramEF = MapFitnessProgram.MapToEF(updatedProgram);
        var fitnessProgram = _context.program.FirstOrDefault(p => p.ProgramCode == Id);
        if (fitnessProgram != null)
        {
            fitnessProgram.Name = fitnessProgramEF.Name;
            fitnessProgram.Target = fitnessProgramEF.Target;
            fitnessProgram.StartDate = fitnessProgramEF.StartDate;
            fitnessProgram.MaxMembers = fitnessProgramEF.MaxMembers;
            _context.SaveChanges();
        }
    }
}
