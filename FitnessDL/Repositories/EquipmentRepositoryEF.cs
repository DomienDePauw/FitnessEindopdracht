using FitnessBeheerDomain.Interfaces;
using FitnessBeheerDomain.Model;
using FitnessBeheerEFlayer.Exceptions;
using FitnessBeheerEFlayer.Mappers;
using FitnessBeheerEFlayer.Model;
using Microsoft.EntityFrameworkCore;
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
    public Equipment GetEquipmentById(int equipmentId)
    {
        var equipmentEF = _context.equipment
            .Include(e => e.Type)
            .FirstOrDefault(e => e.Id == equipmentId);

        if (equipmentEF == null)
        {
            throw new Exception("Equipment not found.");
        }
        if (equipmentEF.Type == null)
        {
            equipmentEF.Type = new EquipmentTypeEF
            {
                Id = 0,
                Name = "",
                Description = ""
            };
        }

        return MapEquipment.MapToDomain(equipmentEF);
    }

    public void UpdateEquipment(int id,Equipment equipment)
    {
        var equipmentEF = _context.equipment.FirstOrDefault(e => e.Id == equipment.Id);
        if (equipmentEF == null)
        {
            throw new Exception("Equipment not found.");
        }

        equipmentEF.IsAvailable = equipment.IsAvailable;

        _context.SaveChanges();
    }

    public List<Equipment> GetAllAvailableEquipment()
    {
        var equipmentEF = _context.equipment
            .Include(e => e.Type)
            .Where(e => e.IsAvailable)
            .ToList();

        return equipmentEF.Select(e => MapEquipment.MapToDomain(e)).ToList();
    }
}
