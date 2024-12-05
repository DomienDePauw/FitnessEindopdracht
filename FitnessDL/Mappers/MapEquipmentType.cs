using FitnessBeheerDomain.Model;
using FitnessBeheerEFlayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessBeheerEFlayer.Mappers;
public class MapEquipmentType
{
    public static EquipmentType MapToDomain(EquipmentTypeEF db) => new EquipmentType
    {
        Id = db.Id,
        Name = db.Name,
        Description = db.Description,
    };

    public static EquipmentTypeEF MapToEF(EquipmentType domain) => new EquipmentTypeEF
    {
        Id = domain.Id,
        Name = domain.Name,
        Description = domain.Description,
    };
}
