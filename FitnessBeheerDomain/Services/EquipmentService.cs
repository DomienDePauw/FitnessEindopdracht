﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessBeheerDomain.Interfaces;
using FitnessBeheerDomain.Model;

namespace FitnessBeheerDomain.Services;
public class EquipmentService
{
    private IEquipmentRepository _equipmentRepository;

    public EquipmentService(IEquipmentRepository equipmentRepository)
    {
        _equipmentRepository = equipmentRepository;
    }

    public void AddEquipment(Equipment equipment)
    {
        _equipmentRepository.AddEquipment(equipment);
    }
}