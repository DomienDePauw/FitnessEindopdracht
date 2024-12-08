using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessBeheerDomain.Model;
public class Equipment
{
    public Equipment()
    {
        
    }
    public Equipment(int id, EquipmentType type)
    {
        Id = id;
        Type = type;
    }

    public int Id { get; set; }
    public EquipmentType Type { get; set; }
    public bool IsAvailable { get; set; }
}

