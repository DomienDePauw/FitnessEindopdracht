using FitnessBeheerDomain.Interfaces;
using FitnessBeheerDomain.Model;
using FitnessBeheerEFlayer.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessBeheerEFlayer.Repositories;
public class EquipmentRepositoryEF : IEquipmentRepository
{
    private readonly FitnessContext _context;

    public EquipmentRepositoryEF(FitnessContext ctx)
    {
        _context = ctx;
    }

    public void AddEquipment(Equipment equipment)
    {
        var equipmentEF = MapEquipment.MapToEF(equipment);
        _context.equipment.Add(equipmentEF);
        _context.SaveChanges();
    }
}
